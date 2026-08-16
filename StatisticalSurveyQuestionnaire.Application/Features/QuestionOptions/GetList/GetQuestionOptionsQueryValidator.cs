using FluentValidation;
using StatisticalSurveyQuestionnaire.Application.Features.QuestionOptions.Create;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionOptions.GetList;

public sealed class GetQuestionOptionsQueryValidator
    : AbstractValidator<CreateQuestionOptionCommand>
{
    public GetQuestionOptionsQueryValidator()
    {
        RuleFor(x => x.QuestionId)
            .GreaterThan(0)
            .WithMessage(
                "شناسه سوال باید بزرگ ‌تر از صفر باشد.");
    }
}
