using FluentValidation;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questions.Create;

public sealed class CreateQuestionCommandValidator
    : AbstractValidator<CreateQuestionCommand>
{
    public CreateQuestionCommandValidator()
    {
        RuleFor(x => x.QuestionnaireVersionId)
            .GreaterThan(0)
            .WithMessage("شناسه نسخه پرسشنامه باید بزرگ ‌تر از صفر باشد.");

        RuleFor(x => x.Text)
            .NotEmpty()
            .WithMessage("متن سوال الزامی است.")
            .MaximumLength(1000)
            .WithMessage("متن سوال نباید بیشتر از ۱۰۰۰ کاراکتر باشد.");

        RuleFor(x => x.QuestionTypeId)
            .GreaterThan(0)
            .WithMessage("شناسه نوع سوال باید بزرگ ‌تر از صفر باشد.");
    }
}
