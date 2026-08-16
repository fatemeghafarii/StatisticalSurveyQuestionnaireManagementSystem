using MediatR;
using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Application.Common.Constants;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionOptions.Update;

public sealed class UpdateQuestionOptionCommandHandler
    : IRequestHandler<
        UpdateQuestionOptionCommand,
        Result<UpdateQuestionOptionResponse>>
{
    private readonly IApplicationDbContext _context;
    public UpdateQuestionOptionCommandHandler(IApplicationDbContext context) => _context = context;
    public async Task<Result<UpdateQuestionOptionResponse>> Handle(UpdateQuestionOptionCommand request, CancellationToken cancellationToken)
    {
        var option =
            await _context.QuestionOptions
                .Include(x => x.Question)
                .ThenInclude(x => x.QuestionnaireVersion)
                .ThenInclude(x => x.Status)
                    .SingleOrDefaultAsync(x => x.Id == request.Id,
                    cancellationToken);

        if (option is null)
        {
            return Result<UpdateQuestionOptionResponse>
                .Failure(
                    "گزینه ی مورد نظر پیدا نشد.");
        }

        if (option.Question.QuestionnaireVersion.Status.Code != QuestionnaireVersionStatusCodes.Draft)
        {
            return Result<UpdateQuestionOptionResponse>
                .Failure(
                "فقط گزینه‌های سوالات نسخه پیش‌نویس قابل ویرایش هستند.");
        }

        option.Text = request.Text;

        await _context.SaveChangesAsync(cancellationToken);

        return Result<UpdateQuestionOptionResponse>
            .Success(
                new UpdateQuestionOptionResponse
                {
                    Id = option.Id,
                    QuestionId = option.QuestionId,
                    Text = option.Text,
                    Order = option.Order,
                });
    }
}
