using DevQuestion.Contracts.Questions.Dtos;
using DevQuestions.Application.Abstractions;

namespace DevQuestions.Application.Questions.Features.GetQuestionsWithFiltersQuery;

public record GetQuestionsWithFiltersQuery(GetQuestionsDto Dto) : IQuery;