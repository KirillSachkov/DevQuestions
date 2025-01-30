namespace Questions.Contracts.Dtos;

public record CreateQuestionDto(string Title, string Text, Guid UserId, Guid[] TagIds);