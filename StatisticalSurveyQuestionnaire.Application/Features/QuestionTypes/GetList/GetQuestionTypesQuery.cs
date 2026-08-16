using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionTypes.GetList;
public sealed record GetQuestionTypesQuery
    : IRequest<Result<GetQuestionTypesResponse>>;

