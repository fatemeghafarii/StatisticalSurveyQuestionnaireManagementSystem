using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.SurveyResponses.Create;
//TODO:NOT_STARTED — a response record exists, but answering hasn't begun.
//TODO:COMPLETED — all required answering is finished.
//TODO:CANCELED — the response was intentionally canceled.
//TODO:REJECTED — the response was rejected for a business reason.
public sealed record CreateSurveyResponseCommand
(
    int HouseholdId,
    int QuestionnaireVersionId,
    int SurveyPeriodId
) : IRequest<Result<CreateSurveyResponseResponse>>;
