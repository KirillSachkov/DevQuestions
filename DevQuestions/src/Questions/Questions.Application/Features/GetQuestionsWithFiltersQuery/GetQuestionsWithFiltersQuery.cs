using Questions.Contracts.Dtos;
using Questions.Contracts.Responses;
using Shared.Abstractions;

namespace Questions.Application.Features.GetQuestionsWithFiltersQuery;

public record GetQuestionsWithFiltersQuery(GetQuestionsDto Dto) : IQuery<QuestionResponse>;