using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questions.GetById;
public sealed record GetQuestionByIdQuery
(
    int Id
) : IRequest<Result<GetQuestionByIdResponse>>;
