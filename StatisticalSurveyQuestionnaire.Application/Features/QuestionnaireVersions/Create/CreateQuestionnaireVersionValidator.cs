using FluentValidation;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionnaireVersions.Create;

public sealed class CreateQuestionnaireVersionValidator
    : AbstractValidator<CreateQuestionnaireVersionCommand>
{
    public CreateQuestionnaireVersionValidator()
    {
        RuleFor(x => x.QuestionnaireId)
            .GreaterThan(0)
            .WithMessage("پرسشنامه انتخاب نشده است.");

        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("عنوان نسخه الزامی است.")
            .MaximumLength(100)
            .WithMessage("عنوان نسخه نمی‌تواند بیشتر از ۱۰۰ کاراکتر باشد.");

        RuleFor(x => x.EffectiveDate)
            .NotEmpty()
            .WithMessage("تاریخ شروع نسخه الزامی است.");
    }
}
