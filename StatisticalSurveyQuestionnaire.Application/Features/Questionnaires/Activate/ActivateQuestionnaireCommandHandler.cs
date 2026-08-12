using MediatR;
using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Results;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.Activate;

public sealed class ActivateQuestionnaireCommandHandler
    : IRequestHandler<ActivateQuestionnaireCommand,
        Result>
{
    private readonly IApplicationDbContext _context;

    public ActivateQuestionnaireCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Result> Handle(ActivateQuestionnaireCommand request, CancellationToken cancellationToken)
    {
        var questionnaire =
                    await _context.Questionnaires
                        .SingleOrDefaultAsync(
                            x => x.Id == request.QuestionnaireId,
                            cancellationToken);


        if (questionnaire is null)
        {
            return Result.Failure("پرسشنامه مورد نظر پیدا نشد.");
        }

        questionnaire.IsActive = true;

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
