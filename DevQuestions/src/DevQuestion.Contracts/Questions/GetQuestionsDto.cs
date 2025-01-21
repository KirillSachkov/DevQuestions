namespace DevQuestion.Contracts.Questions;

public record GetQuestionsDto(string Search, Guid[] TagIds, int Page, int PageSize);