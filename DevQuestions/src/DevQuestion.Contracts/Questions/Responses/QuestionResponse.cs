using DevQuestion.Contracts.Questions.Dtos;

namespace DevQuestion.Contracts.Questions.Responses;

public record QuestionResponse(IEnumerable<QuestionDto> Questions, long TotalCount);