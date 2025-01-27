using Shared;

namespace DevQuestions.Application.Questions.Fails;

public partial class Errors
{
    public static class Questions
    {
        public static Error ToManyQuestions() =>
            Error.Failure("question.too.many", "Пользователь не может открыть больше 3 вопросов.");
    }
}