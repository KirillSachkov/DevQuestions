namespace Questions.Contracts.Dtos;

public record GetQuestionsDto(string Search, Guid[] TagIds, int Page, int PageSize);