using Questions.Contracts.Dtos;
using Shared.Abstractions;

namespace Questions.Application.Features.CreateQuestionCommand;

public record CreateQuestionCommand(CreateQuestionDto QuestionDto) : ICommand;