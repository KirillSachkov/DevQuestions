namespace DevQuestion.Contracts.Questions.Dtos;

public record CreateQuestionDto(string Title, string Text, Guid UserId, Guid[] TagIds);