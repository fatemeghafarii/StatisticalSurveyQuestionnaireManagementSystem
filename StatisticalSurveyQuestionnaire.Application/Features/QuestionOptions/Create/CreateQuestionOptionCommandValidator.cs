using FluentValidation;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionOptions.Create;

public sealed class CreateQuestionOptionCommandValidator
    : AbstractValidator<CreateQuestionOptionCommand>
{
    public CreateQuestionOptionCommandValidator()
    {
        RuleFor(x => x.QuestionId)
            .GreaterThan(0)
            .WithMessage(
                "شناسه سوال باید بزرگ ‌تر از صفر باشد.");

        RuleFor(x => x.Text)
            .NotEmpty()
            .WithMessage("متن گزینه الزامی است.")
            .MaximumLength(500)
            .WithMessage("متن گزینه نباید بیشتر از ۵۰۰ کاراکتر باشد.");
    }
}
