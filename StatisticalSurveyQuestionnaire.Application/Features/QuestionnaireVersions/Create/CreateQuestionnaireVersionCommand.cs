using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionnaireVersions.Create;
public sealed record CreateQuestionnaireVersionCommand
(
    int QuestionnaireId,
    string Title,
    DateTime EffectiveDate

): IRequest<Result<CreateQuestionnaireVersionResponse>>;

// TODO:we implement PublishQuestionnaireVersionCommand