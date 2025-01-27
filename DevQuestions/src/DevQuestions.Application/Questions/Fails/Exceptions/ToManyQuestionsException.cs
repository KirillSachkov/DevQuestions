using DevQuestions.Application.Exceptions;

namespace DevQuestions.Application.Questions.Fails.Exceptions;

public class ToManyQuestionsException : BadRequestException
{
    public ToManyQuestionsException()
        : base([Errors.Questions.ToManyQuestions()])
    {
    }
}