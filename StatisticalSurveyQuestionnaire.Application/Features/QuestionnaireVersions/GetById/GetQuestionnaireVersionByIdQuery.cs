using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Results;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionnaireVersions.GetById;
public sealed record GetQuestionnaireVersionByIdQuery
(
    int Id
) : IRequest<Result<GetQuestionnaireVersionByIdResponse>>;
