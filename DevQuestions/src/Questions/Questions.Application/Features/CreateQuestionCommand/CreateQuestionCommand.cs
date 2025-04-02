using CSharpFunctionalExtensions;
using Questions.Contracts.Dtos;
using Shared;
using Shared.Abstractions;

namespace Questions.Application.Features.CreateQuestionCommand;

public record CreateQuestionCommand(CreateQuestionDto QuestionDto) : ICommand<Result<Guid, Failure>>;