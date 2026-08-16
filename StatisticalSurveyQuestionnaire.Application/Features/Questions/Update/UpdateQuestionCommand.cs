using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questions.Update;
public sealed record UpdateQuestionCommand
(
    int Id,
    string Text,
    int QuestionTypeId
) : IRequest<Result<UpdateQuestionResponse>>;
