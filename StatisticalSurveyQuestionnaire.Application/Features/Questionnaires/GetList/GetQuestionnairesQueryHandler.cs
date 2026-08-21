using MediatR;
using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.GetList;

public sealed class GetQuestionnairesQueryHandler
    : IRequestHandler<
        GetQuestionnairesQuery,
        Result<GetQuestionnairesResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetQuestionnairesQueryHandler(IApplicationDbContext context) => 
        _context = context;

    public async Task<Result<GetQuestionnairesResponse>> Handle(GetQuestionnairesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Questionnaires
            .AsNoTracking();

        var items =
            await query
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .Skip((request.Pagination.PageNumber - 1) * request.Pagination.PageSize)
                .Take(request.Pagination.PageSize)
                .Select(x => new QuestionnaireItem
                {
                    Id = x.Id,
                   
                    Title = x.Title,
                    
                    Code = x.Code,
                    
                    IsActive = x.IsActive,
                    
                    CreatedAt = x.CreatedAt
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
