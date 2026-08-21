using MediatR;
using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionnaireVersions.GetById;

public sealed class GetQuestionnaireVersionByIdQueryHandler
    : IRequestHandler<
        GetQuestionnaireVersionByIdQuery,
        Result<GetQuestionnaireVersionByIdResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetQuestionnaireVersionByIdQueryHandler(IApplicationDbContext context) => 
        _context = context;

    public async Task<Result<GetQuestionnaireVersionByIdResponse>> Handle(GetQuestionnaireVersionByIdQuery request, CancellationToken cancellationToken)
    {
        var version =
            await _context.QuestionnaireVersions
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new GetQuestionnaireVersionByIdResponse
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
                .SingleOrDefaultAsync(cancellationToken);

        if (version is null)
        {
            return Result<GetQuestionnaireVersionByIdResponse>
                .Failure(
                    "نسخه مورد نظر پیدا نشد.");
        }

        return Result<GetQuestionnaireVersionByIdResponse>.Success(version);
    }
}
