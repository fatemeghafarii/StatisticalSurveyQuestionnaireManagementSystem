using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.GetList;
public sealed record GetQuestionnairesQuery
(
    PaginationRequest Pagination
) : IRequest<Result<GetQuestionnairesResponse>>;
public sealed class GetQuestionnairesQueryHandler
    : IRequestHandler<
        GetQuestionnairesQuery,
        Result<GetQuestionnairesResponse>>
{
    private readonly IApplicationDbContext _context;
    public GetQuestionnairesQueryHandler(IApplicationDbContext context) => _context = context;

    public async Task<Result<GetQuestionnairesResponse>> Handle(GetQuestionnairesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Questionnaires
            .AsNoTracking();

        var items =
            await _context.Questionnaires
            .AsNoTracking()
            .OrderByDescending(x => x.CreateDate)
            .Skip((request.Pagination.PageNumber - 1) * request.Pagination.PageSize)
            .Take(request.Pagination.PageSize)
            .Select(x => new QuestionnaireItem
            {
                Id = x.Id,
                Title = x.Title,
                Code = x.Code,
                IsActive = x.IsActive,
                CreatedDate = x.CreateDate
            })
            .ToListAsync(cancellationToken);

        var totalCount = await query.CountAsync(cancellationToken);

        return Result<GetQuestionnairesResponse>
            .Success(new GetQuestionnairesResponse
            {
                Data = new PaginatedList<QuestionnaireItem>
                {
                    Items = items,
                    PageNumber = request.Pagination.PageNumber,
                    PageSize = request.Pagination.PageSize,
                    TotalCount = totalCount
                }
            });
    }
}
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
public sealed class GetQuestionnairesResponse
{
    public PaginatedList<QuestionnaireItem> Data { get; init; } = null!;
}
public sealed class QuestionnaireItem
{
    public int Id { get; init; }

    public string Title { get; init; } = null!;

    public string Code { get; set; } = null!;

    public bool IsActive { get; init; }

    public DateTime CreatedDate { get; init; }
}
