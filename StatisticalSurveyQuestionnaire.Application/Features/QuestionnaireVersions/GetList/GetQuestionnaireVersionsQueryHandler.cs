using MediatR;
using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Results;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionnaireVersions.GetList;

public sealed class GetQuestionnaireVersionsQueryHandler
    : IRequestHandler<GetQuestionnaireVersionsQuery,
        Result<List<GetQuestionnaireVersionsResponse>>>
{
    private readonly IApplicationDbContext _context;

    public GetQuestionnaireVersionsQueryHandler(IApplicationDbContext context) => _context = context;

    public async Task<Result<List<GetQuestionnaireVersionsResponse>>> Handle(GetQuestionnaireVersionsQuery request, CancellationToken cancellationToken)
    {
        var questionnaireExists =
            await _context.Questionnaires
                .AnyAsync(
                    x => x.Id == request.QuestionnaireId,
                    cancellationToken);

        if (!questionnaireExists)
        {
            return Result<List<GetQuestionnaireVersionsResponse>>.Failure("پرسشنامه مورد نظر پیدا نشد.");
        }

        return Result<List<GetQuestionnaireVersionsResponse>>
            .Success(await _context.QuestionnaireVersions
            .AsNoTracking()
            .Where(x => x.QuestionnaireId == request.QuestionnaireId)
            .OrderByDescending(x => x.VersionNumber)
            .Select(x => new GetQuestionnaireVersionsResponse
            {
                Id = x.Id,
                QuestionnaireId = x.QuestionnaireId,
                VersionNumber = x.VersionNumber,
                Title = x.Title,
                EffectiveDate = x.EffectiveDate,
                StatusId = x.StatusId,
                StatusTitle = x.Status.Title,
                IsActive = x.IsActive,
            })
            .ToListAsync(cancellationToken));
    }
}
