using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questions.GetList;
public sealed record GetQuestionsQuery
(
    int QuestionnaireVersionId,
    PaginationRequest Pagination
) : IRequest<Result<GetQuestionsResponse>>;


