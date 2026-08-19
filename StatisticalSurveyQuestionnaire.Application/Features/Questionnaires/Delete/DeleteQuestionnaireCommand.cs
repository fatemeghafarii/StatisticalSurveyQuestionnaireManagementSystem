using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.Delete;

public sealed record class DeleteQuestionnaireCommand
(
    int Id
) : IRequest<Result<bool>>;
