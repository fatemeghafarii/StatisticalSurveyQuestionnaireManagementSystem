using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Results;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionnaireVersions.Create;
public sealed record CreateQuestionnaireVersionCommand
(
    int QuestionnaireId,
    string Title,
    DateTime EffectiveDate

): IRequest<Result<CreateQuestionnaireVersionResponse>>;

// TODO:we implement PublishQuestionnaireVersionCommand