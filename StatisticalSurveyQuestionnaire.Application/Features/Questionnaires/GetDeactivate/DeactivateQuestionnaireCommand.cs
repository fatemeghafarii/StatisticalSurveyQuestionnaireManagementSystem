using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.GetDeactivate;
public sealed record class DeactivateQuestionnaireCommand
(
    int QuestionnaireId
) : IRequest<Result>;
