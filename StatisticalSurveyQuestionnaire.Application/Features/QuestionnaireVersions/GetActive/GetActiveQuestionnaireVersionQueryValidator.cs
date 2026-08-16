using FluentValidation;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionnaireVersions.GetActive;

public sealed class GetActiveQuestionnaireVersionQueryValidator
    : AbstractValidator<GetActiveQuestionnaireVersionQuery>
{
    public GetActiveQuestionnaireVersionQueryValidator()
    {
        RuleFor(x => x.QuestionnaireId)
            .GreaterThan(0)
            .WithMessage("شناسه پرسشنامه باید بزرگ ‌تر از صفر باشد.");
    }
}
