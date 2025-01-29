using DevQuestion.Contracts.Questions.Dtos;
using DevQuestions.Application.Abstractions;

namespace DevQuestions.Application.Questions.Features.CreateQuestionCommand;

public record CreateQuestionCommand(CreateQuestionDto QuestionDto) : ICommand;