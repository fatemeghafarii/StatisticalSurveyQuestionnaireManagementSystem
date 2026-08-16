using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionnaireVersions.GetActive;

/// <summary>
/// no pagination
/// business rule is only one active version per questionnaire
/// </summary>
public sealed record GetActiveQuestionnaireVersionQuery
(
    int QuestionnaireId
) : IRequest<Result<GetActiveQuestionnaireVersionResponse>>;
