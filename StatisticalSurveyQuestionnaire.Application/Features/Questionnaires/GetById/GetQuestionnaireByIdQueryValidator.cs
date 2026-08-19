using FluentValidation;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.GetById;

public sealed class GetQuestionnaireByIdQueryValidator
    : AbstractValidator<GetQuestionnaireByIdQuery>
{

    public GetQuestionnaireByIdQueryValidator()
    {
        RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage(
                    "شناسه پرسشنامه باید بزرگ‌تر از صفر باشد.");
    }
}
