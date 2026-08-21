using MediatR;
using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.Delete;

public sealed class DeleteQuestionnaireCommandHandler
    : IRequestHandler<
        DeleteQuestionnaireCommand,
        Result<bool>>
{
    private readonly IApplicationDbContext _context;

    public DeleteQuestionnaireCommandHandler(IApplicationDbContext context) => 
        _context = context;

    public async Task<Result<bool>> Handle(DeleteQuestionnaireCommand request, CancellationToken cancellationToken)
    {
        var questionnaire =
            await _context.Questionnaires
            .SingleOrDefaultAsync(
                x => x.Id == request.Id,
                cancellationToken);

        if (questionnaire is null)
        {
            return Result<bool>
                .Failure(
                    "پرسشنامه مورد نظر پیدا نشد.");
        }

        if (questionnaire.IsDeleted)
        {
            return Result<bool>
                .Failure(
                    "پرسشنامه قبلاً حذف شده است.");
        }

        var versionExists =
                await _context.QuestionnaireVersions
                    .AnyAsync(
                        x => x.QuestionnaireId == request.Id &&
                        x.IsActive,
                        cancellationToken);

        if (versionExists)
        {
            return Result<bool>
                .Failure(
                    "این پرسشنامه دارای نسخه است و قابل حذف نیست.");
        }

        questionnaire.IsDeleted = true;
        questionnaire.IsActive = false;

        await _context.SaveChangesAsync(
            cancellationToken);

        return Result<bool>
            .Success(true);
    }
}
