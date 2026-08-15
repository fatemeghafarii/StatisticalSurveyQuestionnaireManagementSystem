using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Results;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionnaireVersions.Close;
public sealed record CloseQuestionnaireVersionCommand
(
    int Id
) : IRequest<Result<CloseQuestionnaireVersionResponse>>;
