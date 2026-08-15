using FluentValidation;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questions.GetById;

public sealed class GetQuestionByIdQueryValidator
    : AbstractValidator<GetQuestionByIdQuery>
{
    public GetQuestionByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("شناسه سوال باید بزرگ ‌تر از صفر باشد.");
    }
}
