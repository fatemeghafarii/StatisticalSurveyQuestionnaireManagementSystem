using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questions.Create;
public sealed record CreateQuestionCommand
(
    int QuestionnaireVersionId,
    string Text,
    int QuestionTypeId
) : IRequest<Result<CreateQuestionResponse>>;
