using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questions.Reorder;
public sealed record ReorderQuestionsCommand
(
    int QuestionnaireVersionId,
    IReadOnlyList<ReorderQuestionItem> Items
) : IRequest<Result<GetQuestionsResponse>>;
public sealed record ReorderQuestionItem
(
    int QuestionId,
    int Order
);
public sealed class ReorderQuestionsCommandHandler
    : IRequestHandler<
        ReorderQuestionsCommand,
        Result<GetQuestionsResponse>>
{
    private readonly IApplicationDbContext _context;
    public ReorderQuestionsCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Result<GetQuestionsResponse>> Handle(ReorderQuestionsCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
public sealed class GetQuestionsResponse
{
    public int QuestionnaireVersionId { get; init; }
    public IReadOnlyList<ReorderedQuestionItem> Items { get; init; } = new List<ReorderedQuestionItem>();
}
public sealed class ReorderedQuestionItem
{
    public int QuestionId { get; init; }
    public int Order { get; init; }
}