using MediatR;
using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Application.Common.Constants;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Results;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionnaireVersions.Close;

public sealed class CloseQuestionnaireVersionCommandHandler
    : IRequestHandler<
        CloseQuestionnaireVersionCommand,
        Result<CloseQuestionnaireVersionResponse>>
{
    private readonly IApplicationDbContext _context;

    public CloseQuestionnaireVersionCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Result<CloseQuestionnaireVersionResponse>> Handle(CloseQuestionnaireVersionCommand request, CancellationToken cancellationToken)
    {
        var questionnaireVersion =
              await _context.QuestionnaireVersions
                  .SingleOrDefaultAsync(
                      x => x.Id == request.Id,
                      cancellationToken);

        if (questionnaireVersion is null)
        {
            return Result<CloseQuestionnaireVersionResponse>
                .Failure(
                    "نسخه مورد نظر پیدا نشد.");
        }

        var publishedStatusType =
            await _context.QuestionnaireVersionStatusTypes
                .SingleOrDefaultAsync(
                    x => x.Code == QuestionnaireVersionStatusCodes.Published,
                    cancellationToken);

        if (publishedStatusType is null)
        {
            return Result<CloseQuestionnaireVersionResponse>
                .Failure(
                    "وضعیت منتشر شده پیدا نشد.");
        }

        if (questionnaireVersion.StatusId != publishedStatusType.Id)
        {
            return Result<CloseQuestionnaireVersionResponse>
                .Failure(
                    "فقط نسخه منتشر شده قابل بستن است.");
        }

        var closedStatus =
            await _context.QuestionnaireVersionStatusTypes
                .SingleOrDefaultAsync(
                    x => x.Code == QuestionnaireVersionStatusCodes.Closed,
                    cancellationToken);

        if (closedStatus is null)
        {
            return Result<CloseQuestionnaireVersionResponse>
                .Failure(
                    "وضعیت بسته شده پیدا نشد.");
        }

        questionnaireVersion.StatusId = closedStatus.Id;
        questionnaireVersion.IsActive = false;

        await _context.SaveChangesAsync(cancellationToken);

        return Result<CloseQuestionnaireVersionResponse>
            .Success(
                new CloseQuestionnaireVersionResponse
                {
                    Id = questionnaireVersion.Id,
                    QuestionnaireId = questionnaireVersion.Id,
                    VersionNumber = questionnaireVersion.VersionNumber,
                    Title = questionnaireVersion.Title,
                    EffectiveDate = questionnaireVersion.EffectiveDate,
                    StatusId = closedStatus.Id,
                    StatusTitle = closedStatus.Title,
                    IsActive = closedStatus.IsActive,
                });
    }
}
