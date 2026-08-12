using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Results;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionnaireVersions.GetList;
public sealed record GetQuestionnaireVersionsQuery
(
    int QuestionnaireId
) : IRequest<Result<List<GetQuestionnaireVersionsResponse>>>;
