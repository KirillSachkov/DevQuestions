using Questions.Contracts.Dtos;

namespace Questions.Contracts.Responses;

public record QuestionResponse(IEnumerable<QuestionDto> Questions, long TotalCount);