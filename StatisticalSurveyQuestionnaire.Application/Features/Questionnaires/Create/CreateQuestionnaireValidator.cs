using FluentValidation;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.Create;

public sealed class CreateQuestionnaireValidator
     : AbstractValidator<CreateQuestionnaireCommand>
{
    public CreateQuestionnaireValidator()
    {
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
