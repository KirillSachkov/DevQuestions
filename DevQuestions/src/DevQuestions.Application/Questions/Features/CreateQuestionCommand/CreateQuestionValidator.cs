using DevQuestion.Contracts.Questions.Dtos;
using FluentValidation;

namespace DevQuestions.Application.Questions.Features.CreateQuestionCommand;

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