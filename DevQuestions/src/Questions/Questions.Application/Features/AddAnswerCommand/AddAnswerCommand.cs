using Questions.Contracts.Dtos;
using Shared.Abstractions;

namespace Questions.Application.Features.AddAnswerCommand;

public record AddAnswerCommand(Guid QuestionId, AddAnswerDto AddAnswerDto) : ICommand;