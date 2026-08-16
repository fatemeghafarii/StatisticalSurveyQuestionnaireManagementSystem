using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionOptions.Create;
public sealed record CreateQuestionOptionCommand
(
    int QuestionId,
    string Text
) : IRequest<Result<CreateQuestionOptionResponse>>;
