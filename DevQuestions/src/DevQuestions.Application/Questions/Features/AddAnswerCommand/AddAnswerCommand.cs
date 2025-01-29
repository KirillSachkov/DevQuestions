using DevQuestion.Contracts.Questions.Dtos;
using DevQuestions.Application.Abstractions;

namespace DevQuestions.Application.Questions.Features.AddAnswerCommand;

public record AddAnswerCommand(Guid QuestionId, AddAnswerDto AddAnswerDto) : ICommand;