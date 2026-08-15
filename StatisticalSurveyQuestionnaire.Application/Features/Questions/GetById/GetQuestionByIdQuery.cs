using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Results;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questions.GetById;
public sealed record GetQuestionByIdQuery
(
    int Id
) : IRequest<Result<GetQuestionByIdResponse>>;
