using CSharpFunctionalExtensions;
using DevQuestion.Contracts.Questions;
using Shared;

namespace DevQuestions.Application.Questions;

public interface IQuestionsService
{
    Task<Result<Guid, Failure>> Create(CreateQuestionDto questionDto, CancellationToken cancellationToken);
}