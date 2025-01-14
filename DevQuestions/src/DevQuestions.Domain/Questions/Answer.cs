namespace DevQuestions.Domain.Questions;

public class Answer
{
    public Guid Id { get; set; }

    public required Guid UserId { get; set; }

    public required string Text { get; set; }

    public required Question Question { get; set; }

    public List<Guid> Comments { get; set; } = [];
}