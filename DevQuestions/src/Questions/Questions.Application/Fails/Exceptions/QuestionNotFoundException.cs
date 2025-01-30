using Shared;
using Shared.Exceptions;

namespace Questions.Application.Fails.Exceptions;

public class QuestionNotFoundException : NotFoundException
{
    protected QuestionNotFoundException(Error[] errors)
        : base(errors)
    {
    }
}