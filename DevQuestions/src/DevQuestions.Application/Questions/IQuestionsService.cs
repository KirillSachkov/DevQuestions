using CSharpFunctionalExtensions;
using DevQuestion.Contracts.Questions;
using DevQuestion.Contracts.Questions.Dtos;
using Shared;

namespace DevQuestions.Application.Questions;

public interface IQuestionsService
{
    /// <summary>
    /// Создание вопроса.
    /// </summary>
    /// <param name="questionDto">DTO для создания вопроса.</param>
    /// <param name="cancellationToken">Токен отметы.</param>
    /// <returns>Результат работы метода - либо ID созданного вопроса, либо список ошибок.</returns>
    Task<Result<Guid, Failure>> Create(CreateQuestionDto questionDto, CancellationToken cancellationToken);

    /// <summary>
    /// Добавление ответа на вопрос.
    /// </summary>
    /// <param name="questionId">ID вопроса.</param>
    /// <param name="addAnswerDto">DTO для добавления ответа на вопрос.</param>
    /// <param name="cancellationToken">Токен отметы.</param>
    /// <returns>Результат работы метода - либо ID созданного ответа, либо список ошибок.</returns>
    Task<Result<Guid, Failure>> AddAnswer(Guid questionId, AddAnswerDto addAnswerDto, CancellationToken cancellationToken);
}