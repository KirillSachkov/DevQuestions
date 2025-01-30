namespace Questions.Contracts.Dtos;

public record QuestionDto(
    Guid Id,
    string Title,
    string Text,
    Guid UserId,
    string? ScreenshotUrl,
    Guid? SolutionId,
    IEnumerable<string> Tags,
    string Status);