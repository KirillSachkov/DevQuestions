namespace DevQuestions.Domain.Reports;

public class Report
{
    public Guid Id { get; set; }

    public required Guid UserId { get; set; }

    public required Guid ReportedUserId { get; set; }

    public Guid? ResolvedByUserId { get; set; }

    public required string Reason { get; set; }

    public Status Status { get; set; } = Status.Open;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}