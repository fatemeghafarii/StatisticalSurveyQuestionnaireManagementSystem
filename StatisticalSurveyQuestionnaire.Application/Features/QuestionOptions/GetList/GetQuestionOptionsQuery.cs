using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionOptions.GetList;
public sealed record GetQuestionOptionsQuery
(
    int QuestionId
) : IRequest<Result<GetQuestionOptionsResponse>>;
