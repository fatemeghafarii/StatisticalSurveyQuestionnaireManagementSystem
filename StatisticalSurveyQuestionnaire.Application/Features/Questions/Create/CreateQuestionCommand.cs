using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Results;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questions.Create;
public sealed record CreateQuestionCommand
(
    int QuestionnaireVersionId,
    string Text,
    int QuestionTypeId
) : IRequest<Result<CreateQuestionResponse>>;
