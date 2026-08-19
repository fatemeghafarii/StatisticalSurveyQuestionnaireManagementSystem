using MediatR;
using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.Update;

public sealed class UpdateQuestionnaireCommandHandler
    : IRequestHandler<
        UpdateQuestionnaireCommand,
        Result<UpdateQuestionnaireResponse>>
{
    private readonly IApplicationDbContext _context;

    public UpdateQuestionnaireCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Result<UpdateQuestionnaireResponse>> Handle(UpdateQuestionnaireCommand request, CancellationToken cancellationToken)
    {
        var questionnaire =
            await _context.Questionnaires
                .SingleOrDefaultAsync(x => x.Id == request.Id,
                cancellationToken);

        if (questionnaire is null)
        {
            return Result<UpdateQuestionnaireResponse>
                .Failure(
                    "پرسشنامه ی مورد نظر پیدا نشد.");
        }

        if (!request.IsActive && questionnaire.IsActive)
        {
            var hasActiveVersion =
                await _context.QuestionnaireVersions
                    .AnyAsync(
                    x => x.QuestionnaireId == questionnaire.Id &&
                         x.IsActive,
                    cancellationToken);

            if (hasActiveVersion)
            {
                return Result<UpdateQuestionnaireResponse>
                    .Failure(
                        "پرسشنامه دارای نسخه فعال است و تا زمان غیرفعال شدن نسخه فعال، نمی‌توان پرسشنامه را غیرفعال کرد.");
            }
        }
        questionnaire.Title = request.Title;
        questionnaire.Description = request.Description;
        questionnaire.IsActive = request.IsActive;

        await _context.SaveChangesAsync(cancellationToken);

        return Result<UpdateQuestionnaireResponse>
            .Success(
                new UpdateQuestionnaireResponse
                {
                    Id = questionnaire.Id,
                   
                    Title = questionnaire.Title,
                    
                    Description = questionnaire.Description,
                    
                    Code = questionnaire.Code,
                    
                    IsActive = questionnaire.IsActive
                });
    }
}
