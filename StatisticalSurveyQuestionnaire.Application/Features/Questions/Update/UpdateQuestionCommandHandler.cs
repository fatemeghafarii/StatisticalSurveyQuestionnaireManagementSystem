using MediatR;
using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Application.Common.Constants;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questions.Update;

public sealed class UpdateQuestionCommandHandler :
    IRequestHandler<
        UpdateQuestionCommand,
        Result<UpdateQuestionResponse>>
{
    private readonly IApplicationDbContext _context;
    public UpdateQuestionCommandHandler(IApplicationDbContext context) => _context = context;
    public async Task<Result<UpdateQuestionResponse>> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        var question =
            await _context.Questions
                .Include(x => x.QuestionnaireVersion)
                .ThenInclude(x => x.Status)
                    .SingleOrDefaultAsync(x => x.Id == request.Id,
                    cancellationToken);

        if (question is null)
        {
            return Result<UpdateQuestionResponse>
                .Failure(
                    "سوال مورد نظر پیدا نشد.");
        }

        if (question.QuestionnaireVersion.Status.Code != QuestionnaireVersionStatusCodes.Draft)
        {
            return Result<UpdateQuestionResponse>
               .Failure(
                   "فقط سوالات نسخه پیش‌ نویس قابل ویرایش هستند.");
        }

        var questionTypeExists =
            await _context.QuestionTypes
                .AnyAsync(
                    x => x.Id == request.QuestionTypeId,
                    cancellationToken);

        if (!questionTypeExists)
        {
            return Result<UpdateQuestionResponse>
                .Failure(
                    "نوع سوال مورد نظر پیدا نشد.");
        }

        question.Text = request.Text;
        question.QuestionTypeId = request.QuestionTypeId;

        await _context.SaveChangesAsync(cancellationToken);

        return Result<UpdateQuestionResponse>
            .Success(
                new UpdateQuestionResponse
                {
                    Id = question.Id,
                    QuestionnaireVersionId = question.QuestionnaireVersionId,
                    Text = question.Text,
                    QuestionTypeId = question.QuestionTypeId,
                    Order = question.Order,
                });
    }
}
