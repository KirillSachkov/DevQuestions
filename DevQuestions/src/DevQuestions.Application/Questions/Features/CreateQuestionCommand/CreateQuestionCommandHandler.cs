using CSharpFunctionalExtensions;
using DevQuestion.Contracts.Questions.Dtos;
using DevQuestions.Application.Abstractions;
using DevQuestions.Application.Extensions;
using DevQuestions.Application.Questions.Fails;
using DevQuestions.Domain.Questions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Shared;

namespace DevQuestions.Application.Questions.Features.CreateQuestionCommand;

public class CreateQuestionCommandHandler : ICommandHandler<Guid, CreateQuestionCommand>
{
    private readonly ILogger<CreateQuestionCommandHandler> _logger;
    private readonly IQuestionsRepository _questionsRepository;
    private readonly IValidator<CreateQuestionDto> _validator;

    public CreateQuestionCommandHandler(
        ILogger<CreateQuestionCommandHandler> logger,
        IQuestionsRepository questionsRepository,
        IValidator<CreateQuestionDto> validator)
    {
        _logger = logger;
        _questionsRepository = questionsRepository;
        _validator = validator;
    }

    public async Task<Result<Guid, Failure>> Handle(CreateQuestionCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(command.QuestionDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            return validationResult.ToErrors();
        }

        int openUserQuestionsCount = await _questionsRepository
            .GetOpenUserQuestionsAsync(command.QuestionDto.UserId, cancellationToken);

        if (openUserQuestionsCount > 3)
        {
            return Errors.Questions.ToManyQuestions().ToFailure();
        }

        var questionId = Guid.NewGuid();

        var question = new Question(
            questionId,
            command.QuestionDto.Title,
            command.QuestionDto.Text,
            command.QuestionDto.UserId,
            null,
            command.QuestionDto.TagIds);

        await _questionsRepository.AddAsync(question, cancellationToken);

        _logger.LogInformation("Question created with id {questionId}", questionId);

        return questionId;
    }
}