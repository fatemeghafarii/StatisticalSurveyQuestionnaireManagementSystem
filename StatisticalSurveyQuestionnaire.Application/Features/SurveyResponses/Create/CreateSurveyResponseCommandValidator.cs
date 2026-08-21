using FluentValidation;

namespace StatisticalSurveyQuestionnaire.Application.Features.SurveyResponses.Create;

public sealed class CreateSurveyResponseCommandValidator
    : AbstractValidator<CreateSurveyResponseResponse>
{
    public CreateSurveyResponseCommandValidator()
    {
        RuleFor(x => x.HouseholdId)
                .GreaterThan(0)
                .WithMessage(
                    "شناسه خانوار باید بزرگ‌تر از صفر باشد.");

        RuleFor(x => x.QuestionnaireVersionId)
                .GreaterThan(0)
                .WithMessage(
                    "شناسه نسخه پرسشنامه باید بزرگ‌تر از صفر باشد.");

        RuleFor(x => x.ResponseStatusId)
                .GreaterThan(0)
                .WithMessage(
                    "شناسه دوره ی آماری باید بزرگ‌تر از صفر باشد.");
    }
}
