using DevQuestion.Contracts.Questions;
using FluentValidation;

namespace DevQuestions.Application.Questions;

public class CreateQuestionValidator : AbstractValidator<CreateQuestionDto>
{
    public CreateQuestionValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Заголовок не может быть пустым.")
            .MaximumLength(500).WithMessage("Заголовок невалидный.");

        RuleFor(x => x.Text)
            .NotEmpty().WithMessage("Текст не может быть пустым.")
            .MaximumLength(5000).WithMessage("Текст невалидный.");

        RuleFor(x => x.UserId).NotEmpty();
    }
}