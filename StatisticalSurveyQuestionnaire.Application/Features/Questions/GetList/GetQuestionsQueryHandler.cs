using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Results;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questions.GetList;

public sealed class GetQuestionsQueryHandler
    : IRequestHandler<
        GetQuestionsQuery,
        Result<GetQuestionsResponse>>
{
    private readonly IApplicationDbContext _context;
    public GetQuestionsQueryHandler(IApplicationDbContext context) => _context = context;

    public async Task<Result<GetQuestionsResponse>> Handle(GetQuestionsQuery request, CancellationToken cancellationToken)
    {
        var questionnaireVersionExists =
            await _context.QuestionnaireVersions
                .AnyAsync(
                    x => x.Id == request.QuestionnaireVersionId,
                    cancellationToken);

        if (!questionnaireVersionExists)
        {
            return Result<GetQuestionsResponse>
                .Failure(
                    "نسخه مورد نظر پیدا نشد.");
        }

        var query = _context.Questions
            .AsNoTracking()
            .Where(x => x.QuestionnaireVersionId == request.QuestionnaireVersionId);

        var items = await query
            .OrderBy(x => x.Order)
            .Skip(
                (request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(x => new QuestionListItem
            {
                Id = x.Id,
                QuestionnaireVersionId = x.QuestionnaireVersionId,
                Text = x.Text,
                QuestionTypeId = x.QuestionTypeId,
                QuestionTypeTitle = x.QuestionType.Title,
                Order = x.Order,
            })
            .ToListAsync(cancellationToken);

        var totalCount = await query.CountAsync(cancellationToken);

        return Result<GetQuestionsResponse>
            .Success(new GetQuestionsResponse
            {
                Items = items,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = totalCount
            });

    }
}
