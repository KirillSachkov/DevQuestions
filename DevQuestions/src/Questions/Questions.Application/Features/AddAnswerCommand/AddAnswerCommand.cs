using CSharpFunctionalExtensions;
using Questions.Contracts.Dtos;
using Shared;
using Shared.Abstractions;

namespace Questions.Application.Features.AddAnswerCommand;

public record AddAnswerCommand(Guid QuestionId, AddAnswerDto AddAnswerDto) : ICommand<Result<Guid, Failure>>;