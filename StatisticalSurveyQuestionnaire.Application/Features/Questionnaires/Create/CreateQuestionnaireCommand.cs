using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.Create;
public sealed record class CreateQuestionnaireCommand
(
    string Title,
    string? Description
) : IRequest<Result<CreateQuestionnaireResponse>>;
