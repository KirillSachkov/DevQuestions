namespace DevQuestion.Contracts.Questions.Dtos;

public record GetQuestionsDto(string Search, Guid[] TagIds, int Page, int PageSize);