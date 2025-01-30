using Shared;
using Shared.Exceptions;

namespace Questions.Application.Fails.Exceptions;

public class QuestionValidationException : BadRequestException
{
    public QuestionValidationException(Error[] errors)
        : base(errors)
    {
    }
}