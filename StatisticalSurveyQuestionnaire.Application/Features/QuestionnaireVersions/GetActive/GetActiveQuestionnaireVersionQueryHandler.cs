using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionnaireVersions.GetActive;

public sealed class GetActiveQuestionnaireVersionQueryHandler
    : IRequestHandler<
        GetActiveQuestionnaireVersionQuery,
        Result<GetActiveQuestionnaireVersionResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetActiveQuestionnaireVersionQueryHandler(IApplicationDbContext context) => 
        _context = context;

    public async Task<Result<GetActiveQuestionnaireVersionResponse>> Handle(GetActiveQuestionnaireVersionQuery request, CancellationToken cancellationToken)
    {
        var version =
            await _context.QuestionnaireVersions
                .AsNoTracking()
                .Where(x =>
                    x.QuestionnaireId == request.QuestionnaireId &&
                    x.IsActive)
                .Select(x => new GetActiveQuestionnaireVersionResponse
                {
                    Id = x.Id,
                    
                    QuestionnaireId = x.QuestionnaireId,
                    
                    VersionNumber = x.VersionNumber,
                    
                    Title = x.Title,
                    
                    EffectiveDate = x.EffectiveDate,
                    
                    StatusId = x.StatusId,
                    
                    StatusCode = x.Status.Code,
                    
                    StatusTitle = x.Status.Title,
                
                    IsActive = x.IsActive
                })
                .FirstOrDefaultAsync(cancellationToken);

        if (version is null)
        {
            return Result<GetActiveQuestionnaireVersionResponse>
                .Failure(
                    "نسخه فعال برای این پرسشنامه پیدا نشد..");
        }

        return Result<GetActiveQuestionnaireVersionResponse>.Success(version);
    }
}
