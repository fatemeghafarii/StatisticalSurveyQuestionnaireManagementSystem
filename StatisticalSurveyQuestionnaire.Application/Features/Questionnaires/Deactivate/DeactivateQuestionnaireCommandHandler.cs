using MediatR;
using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Results;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.Deactivate;

public sealed class DeactivateQuestionnaireCommandHandler
    : IRequestHandler<
        DeactivateQuestionnaireCommand,
        Result>
{
    private readonly IApplicationDbContext _context;

    public DeactivateQuestionnaireCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Result> Handle(DeactivateQuestionnaireCommand request, CancellationToken cancellationToken)
    {
        var questionnaire =
              await _context.Questionnaires
                  .SingleOrDefaultAsync(
                      x => x.Id == request.QuestionnaireId,
                      cancellationToken);

        if (questionnaire is null)
        {
            return Result
                .Failure(
                    "پرسشنامه مورد نظر پیدا نشد.");
        }

        if (!questionnaire.IsActive)
        {
            return Result
                .Failure(
                    "پرسشنامه در حال حاضر غیرفعال است.");
        }

        questionnaire.IsActive = false;

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
