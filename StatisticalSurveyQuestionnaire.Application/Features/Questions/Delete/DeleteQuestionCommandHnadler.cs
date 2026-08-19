using MediatR;
using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Application.Common.Constants;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questions.Delete
{
    public sealed class DeleteQuestionCommandHnadler
        : IRequestHandler<
            DeleteQuestionCommand,
            Result<bool>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteQuestionCommandHnadler(IApplicationDbContext context) => _context = context;

        public async Task<Result<bool>> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var question =
                await _context.Questions
                .Include(x => x.QuestionnaireVersion)
                .ThenInclude(x => x.Status)
                .SingleOrDefaultAsync(
                    x => x.Id == request.Id,
                    cancellationToken);

            if (question is null)
            {
                return Result<bool>
                    .Failure(
                        "سوال مورد نظر پیدا نشد.");
            }

            if(question.QuestionnaireVersion.Status.Code == QuestionnaireVersionStatusCodes.Draft)
            {
                return Result<bool>
                .Failure(
                    "فقط سوالات نسخه پیش ‌نویس قابل حذف هستند.");
            }

            var hasAnswers =
                await _context.Answers
                    .AnyAsync(
                        x => x.QuestionId == question.Id,
                        cancellationToken);

            if (hasAnswers)
            {
                return Result<bool>
                    .Failure(
                        "این سوال دارای پاسخ است و قابل حذف نیست.");
            }

            _context.Questions.Remove(question);

            await _context.SaveChangesAsync(
                cancellationToken);

            return Result<bool>
                .Success(true);
        }
    }
}
