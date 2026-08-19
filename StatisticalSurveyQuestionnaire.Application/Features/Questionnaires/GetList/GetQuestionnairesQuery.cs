using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.GetList;
public sealed record GetQuestionnairesQuery
(
    PaginationRequest Pagination
) : IRequest<Result<GetQuestionnairesResponse>>;
