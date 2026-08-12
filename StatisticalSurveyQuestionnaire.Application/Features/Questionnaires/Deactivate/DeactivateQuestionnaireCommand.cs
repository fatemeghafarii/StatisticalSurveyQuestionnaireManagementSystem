using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Results;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.Deactivate;
public sealed record class DeactivateQuestionnaireCommand
(
    int QuestionnaireId
) : IRequest<Result>;
