using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.GetById;

public sealed class GetQuestionnaireByIdQueryHandler
    : IRequestHandler<
        GetQuestionnaireByIdQuery,
        Result<GetQuestionnaireByIdResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetQuestionnaireByIdQueryHandler(IApplicationDbContext context) => 
        _context = context;

    public async Task<Result<GetQuestionnaireByIdResponse>> Handle(GetQuestionnaireByIdQuery request, CancellationToken cancellationToken)
    {
        var questionnaire =
            await _context.Questionnaires
            .AsNoTracking()
            .Where(x =>
                x.Id == request.Id &&
                !x.IsDeleted)
            .Select(x => new GetQuestionnaireByIdResponse
            {
                Id = x.Id,
               
                Title = x.Title,
                
                Code = x.Code,
                
                IsActive = x.IsActive,
                
                CreatedAt = x.CreatedAt,
                
                Versions = x.QuestionnaireVersions
                    .OrderByDescending(v => v.VersionNumber)
                    .Select(v => new QuestionnaireVersionItem
                    {
                        Id = v.Id,
                       
                        VersionNumber = v.VersionNumber,
                        
                        Title = v.Title,
                        
                        EffectiveDate = v.EffectiveDate,
                        
                        StatusId = v.StatusId,
                        
                        StatusCode = v.Status.Code,

                        StatusTitle = v.Status.Title,   
                        
                        IsActive = v.IsActive
                    })
                    .ToList()
            })
            .SingleOrDefaultAsync(cancellationToken);

        if (questionnaire is null)
        {
            return Result<GetQuestionnaireByIdResponse>
                .Failure(
                    "پرسشنامه مورد نظر پیدا نشد.");
        }

        return Result<GetQuestionnaireByIdResponse>.Success(questionnaire);
    }
}
