using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.Activate;
public sealed record class ActivateQuestionnaireCommand
(
    int QuestionnaireId
) : IRequest<Result>;
