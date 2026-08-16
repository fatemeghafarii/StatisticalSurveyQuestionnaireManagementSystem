using FluentValidation;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questions.GetList;

public sealed class GetQuestionsQueryValidator
    : AbstractValidator<GetQuestionsQuery>
{
    public GetQuestionsQueryValidator()
    {
        RuleFor(x => x.QuestionnaireVersionId)
            .GreaterThan(0)
            .WithMessage("شناسه نسخه پرسشنامه باید بزرگ ‌تر از صفر باشد.");

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
