using Shared.Exceptions;

namespace Questions.Application.Fails.Exceptions;

public class ToManyQuestionsException : BadRequestException
{
    public ToManyQuestionsException()
        : base([Errors.Questions.ToManyQuestions()])
    {
    }
}