using Questions.Contracts.Dtos;
using Shared.Abstractions;

namespace Questions.Application.Features.GetQuestionsWithFiltersQuery;

public record GetQuestionsWithFiltersQuery(GetQuestionsDto Dto) : IQuery;