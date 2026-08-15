using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Results;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questions.GetList;
public sealed record GetQuestionsQuery
(
    int QuestionnaireVersionId,
    int PageNumber = 1,
    int PageSize = 10
) : IRequest<Result<GetQuestionsResponse>>;


