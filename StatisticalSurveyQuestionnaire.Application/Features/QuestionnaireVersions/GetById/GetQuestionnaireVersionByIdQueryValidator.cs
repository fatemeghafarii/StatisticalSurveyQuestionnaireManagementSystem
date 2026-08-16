using FluentValidation;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionnaireVersions.GetById;

public sealed class GetQuestionnaireVersionByIdQueryValidator
    : AbstractValidator<GetQuestionnaireVersionByIdQuery>
{
    public GetQuestionnaireVersionByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("شناسه سوال باید بزرگ ‌تر از صفر باشد.");
    }
}