using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionnaireVersions.GetList;
public sealed record GetQuestionnaireVersionsQuery
(
    int QuestionnaireId,
    PaginationRequest Pagination
) : IRequest<Result<GetQuestionnaireVersionsResponse>>;
