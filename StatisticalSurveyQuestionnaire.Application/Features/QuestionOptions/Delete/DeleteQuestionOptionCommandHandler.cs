using MediatR;
using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Application.Common.Constants;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionOptions.Delete;

public sealed class DeleteQuestionOptionCommandHandler
    : IRequestHandler<
        DeleteQuestionOptionCommand,
        Result<bool>>
{
    private readonly IApplicationDbContext _context;

    public DeleteQuestionOptionCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Result<bool>> Handle(DeleteQuestionOptionCommand request, CancellationToken cancellationToken)
    {
        var option =
            await _context.QuestionOptions
            .Include(x => x.Question.QuestionnaireVersion)
            .ThenInclude(x => x.Status)
            .SingleOrDefaultAsync(
                x => x.Id == request.Id,
                cancellationToken);

        if (option is null)
        {
            return Result<bool>
                .Failure(
                    "گزینه مورد نظر پیدا نشد.");
        }

        if (option.Question.QuestionnaireVersion.Status.Code == QuestionnaireVersionStatusCodes.Draft)
        {
            return Result<bool>
            .Failure(
                "فقط گزینه‌های سوالات نسخه پیش‌ نویس قابل حذف هستند.");
        }

        var hasAnswers =
               await _context.Answers
                   .AnyAsync(
                       x => x.QuestionOptionId == option.Id,
                       cancellationToken);

        if (hasAnswers)
        {
            return Result<bool>
                .Failure(
                    "این گزینه دارای پاسخ است و قابل حذف نیست.");
        }

        _context.QuestionOptions.Remove(option);

        await _context.SaveChangesAsync(
            cancellationToken);

        return Result<bool>
            .Success(true);
    }
}
