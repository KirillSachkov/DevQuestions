using Shared;

namespace DevQuestions.Application.Questions.Fails;

public partial class Errors
{
    public static class General
    {
        public static Error NotFound(Guid id) =>
            Error.Failure("record.not.found", $"Запись по id - {id} не найдена");
    }

    public static class Questions
    {
        public static Error ToManyQuestions() =>
            Error.Failure("question.too.many", "Пользователь не может открыть больше 3 вопросов.");

        public static Failure NotEnoughRating()
            => Error.Failure("not.enough.rating", "Недостаточно рейтинга.");
    }
}