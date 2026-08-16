using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.GetActivate;
public sealed record class ActivateQuestionnaireCommand
(
    int QuestionnaireId
) : IRequest<Result>;
