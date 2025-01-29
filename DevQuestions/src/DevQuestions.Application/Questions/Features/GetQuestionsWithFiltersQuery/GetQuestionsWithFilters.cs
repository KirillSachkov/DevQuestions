using Dapper;
using DevQuestion.Contracts.Questions.Dtos;
using DevQuestion.Contracts.Questions.Responses;
using DevQuestions.Application.Abstractions;
using DevQuestions.Application.Database;
using DevQuestions.Application.FilesStorage;
using DevQuestions.Application.Tags;
using DevQuestions.Domain.Questions;
using Microsoft.EntityFrameworkCore;

namespace DevQuestions.Application.Questions.Features.GetQuestionsWithFiltersQuery;

public class GetQuestionsWithFilters : IQueryHandler<QuestionResponse, GetQuestionsWithFiltersQuery>
{
    private readonly IFilesProvider _filesProvider;
    private readonly ITagsReadDbContext _tagsReadDbContext;
    private readonly IQuestionsReadDbContext _questionsDbContext;

    public GetQuestionsWithFilters(
        IFilesProvider filesProvider,
        ITagsReadDbContext tagsReadDbContext,
        IQuestionsReadDbContext questionsDbContext)
    {
        _filesProvider = filesProvider;
        _tagsReadDbContext = tagsReadDbContext;
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

        var tags = await _tagsReadDbContext.TagsRead
            .Where(t => questionTags.Contains(t.Id))
            .Select(t => t.Name)
            .ToListAsync(cancellationToken);

        var questionsDto = questions.Select(q => new QuestionDto(
            q.Id,
            q.Title,
            q.Text,
            q.UserId,
            q.ScreenshotId is not null ? filesDict[q.ScreenshotId.Value] : null,
            q.Solution?.Id,
            tags,
            q.Status.ToRussianString()));

        return new QuestionResponse(questionsDto, count);
    }
}