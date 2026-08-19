using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.GetById;
public sealed record GetQuestionnaireByIdQuery
(
    int Id
) : IRequest<Result<GetQuestionnaireByIdResponse>>;

