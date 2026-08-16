using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionOptions.Update;
public sealed record UpdateQuestionOptionCommand
(
    int Id,
    string Text
) : IRequest<Result<UpdateQuestionOptionResponse>>;
