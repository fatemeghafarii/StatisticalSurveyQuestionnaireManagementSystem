using FluentValidation;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionnaireVersions.GetList;

public sealed class GetQuestionnaireVersionsQueryValidator
    : AbstractValidator<GetQuestionnaireVersionsQuery>
{
    public GetQuestionnaireVersionsQueryValidator()
    {
        //
        RuleFor(x => x.QuestionnaireId)
            .GreaterThan(0)
            .WithMessage("شناسه پرسشنامه باید بزرگ ‌تر از صفر باشد.");

        RuleFor(x => x.Pagination.PageNumber)
            .GreaterThan(0)
            .WithMessage(
                "شماره صفحه باید بزرگ‌تر از صفر باشد.");

        RuleFor(x => x.Pagination.PageSize)
            .InclusiveBetween(1, 100)
            .WithMessage(
                "تعداد موارد هر صفحه باید بین ۱ تا ۱۰۰ باشد.");
    }
}