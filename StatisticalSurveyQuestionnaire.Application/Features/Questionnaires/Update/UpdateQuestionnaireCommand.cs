using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.Update;
public sealed record class UpdateQuestionnaireCommand
(
    int Id,
    string Title,
    string? Description,
    bool IsActive
) : IRequest<Result<UpdateQuestionnaireResponse>>;
