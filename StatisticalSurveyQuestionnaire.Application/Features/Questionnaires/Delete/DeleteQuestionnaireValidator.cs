using FluentValidation;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.Delete;

public sealed class DeleteQuestionnaireValidator
    : AbstractValidator<DeleteQuestionnaireCommand>
{
    public DeleteQuestionnaireValidator()
    {
        RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage(
                    "شناسه پرسشنامه باید بزرگ‌تر از صفر باشد.");
    }
}
