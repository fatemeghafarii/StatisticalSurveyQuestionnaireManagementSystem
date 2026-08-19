using FluentValidation;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.Update;

public sealed class UpdateQuestionnaireCommandValidator
    : AbstractValidator<UpdateQuestionnaireCommand>
{
    public UpdateQuestionnaireCommandValidator()
    {
        RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage(
                    "شناسه پرسشنامه باید بزرگ‌تر از صفر باشد.");

        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("عنوان پرسشنامه الزامی است.")
            .MaximumLength(200)
            .WithMessage("عنوان پرسشنامه نمی‌تواند بیشتر از ۲۰۰ کاراکتر باشد.");

        RuleFor(x => x.Description)
            .MaximumLength(1000)
            .WithMessage("توضیحات پرسشنامه نمی‌تواند بیشتر از ۱۰۰۰ کاراکتر باشد.");
    }
}
