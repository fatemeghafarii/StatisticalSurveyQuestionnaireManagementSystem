using FluentValidation;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.GetList;

public sealed class GetQuestionnairesQueryValidator
    : AbstractValidator<GetQuestionnairesQuery>
{
    public GetQuestionnairesQueryValidator()
    {
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
