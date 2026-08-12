using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Results;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.Activate;
public sealed record class ActivateQuestionnaireCommand
(
    int QuestionnaireId
) : IRequest<Result>;
