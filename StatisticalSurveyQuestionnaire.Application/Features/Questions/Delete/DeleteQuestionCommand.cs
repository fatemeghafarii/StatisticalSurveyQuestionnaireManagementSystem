using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questions.Delete
{
    public sealed record DeleteQuestionCommand
    (
        int Id
    ) : IRequest<Result<bool>>;
}
