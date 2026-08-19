using MediatR;
using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionTypes.GetList;

public sealed class GetQuestionTypesQueryHandler
    : IRequestHandler<
        GetQuestionTypesQuery,
        Result<GetQuestionTypesResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetQuestionTypesQueryHandler(IApplicationDbContext context) => _context = context;

    public async Task<Result<GetQuestionTypesResponse>> Handle(GetQuestionTypesQuery request, CancellationToken cancellationToken)
    {
        var items =
            await _context.QuestionTypes
            .AsNoTracking()
            .Where(x => x.IsActive)
            .OrderBy(x => x.Order)
            .Select(x => new QuestionTypeItem
            {
                Id = x.Id,
               
                Title = x.Title,
                
                Order = x.Order,
                
                IsActive = x.IsActive
            })
            .ToListAsync(cancellationToken); ;

        return Result<GetQuestionTypesResponse>
            .Success(new GetQuestionTypesResponse
            {
                Items = items
            });
    }
}
