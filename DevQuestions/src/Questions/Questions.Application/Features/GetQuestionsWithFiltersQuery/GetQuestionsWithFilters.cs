using Microsoft.EntityFrameworkCore;
using Questions.Contracts.Dtos;
using Questions.Contracts.Responses;
using Questions.Domain;
using Shared.Abstractions;
using Shared.FilesStorage;
using Tags.Contracts;
using Tags.Contracts.Dtos;

// using DevQuestions.Application.Tags;

namespace Questions.Application.Features.GetQuestionsWithFiltersQuery;

public class GetQuestionsWithFilters : IQueryHandler<QuestionResponse, GetQuestionsWithFiltersQuery>
{
    private readonly IFilesProvider _filesProvider;

    // private readonly ITagsContract _tagsContract;
    private readonly IQuestionsReadDbContext _questionsDbContext;

    public GetQuestionsWithFilters(
        IFilesProvider filesProvider,
        IQuestionsReadDbContext questionsDbContext)
    {
        _filesProvider = filesProvider;
        _questionsDbContext = questionsDbContext;
    }

    public async Task<QuestionResponse> Handle(
        GetQuestionsWithFiltersQuery query, CancellationToken cancellationToken)
    {
        var questions = await _questionsDbContext.ReadQuestions
            .Include(q => q.Solution)
            .Skip(query.Dto.Page * query.Dto.PageSize)
            .Take(query.Dto.PageSize)
            .ToListAsync(cancellationToken);

        long count = await _questionsDbContext.ReadQuestions.LongCountAsync(cancellationToken);

        var screenshotIds = questions
            .Where(q => q.ScreenshotId is not null)
            .Select(q => q.ScreenshotId!.Value);

        var filesDict = await _filesProvider.GetUrlsByIdsAsync(screenshotIds, cancellationToken);

        var questionTags = questions.SelectMany(q => q.Tags);

        // var tags = await _tagsContract.GetByIds(new GetByIdsDto(questionTags.ToArray()));

        var questionsDto = questions.Select(q => new QuestionDto(
            q.Id,
            q.Title,
            q.Text,
            q.UserId,
            q.ScreenshotId is not null ? filesDict[q.ScreenshotId.Value] : null,
            q.Solution?.Id,
            // tags.Select(t => t.Name),
            [],
            q.Status.ToRussianString()));

        return new QuestionResponse(questionsDto, count);
    }
}