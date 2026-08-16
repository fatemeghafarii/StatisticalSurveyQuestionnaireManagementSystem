using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionnaireVersions.Close;
public sealed record CloseQuestionnaireVersionCommand
(
    int Id
) : IRequest<Result<CloseQuestionnaireVersionResponse>>;
