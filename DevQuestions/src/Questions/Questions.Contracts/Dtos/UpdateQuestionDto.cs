namespace Questions.Contracts.Dtos;

public record UpdateQuestionDto(string Title, string Body, Guid[] TagIds);