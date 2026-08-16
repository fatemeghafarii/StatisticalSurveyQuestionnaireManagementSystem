using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionOptions.Delete;
public sealed record DeleteQuestionOptionCommand
(
    int Id
) : IRequest<Result<bool>>;
