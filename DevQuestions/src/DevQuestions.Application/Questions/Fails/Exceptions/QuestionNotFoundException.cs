using DevQuestions.Application.Exceptions;
using Shared;

namespace DevQuestions.Application.Questions.Fails.Exceptions;

public class QuestionNotFoundException : NotFoundException
{
    protected QuestionNotFoundException(Error[] errors)
        : base(errors)
    {
    }
}