using FluentValidation;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionOptions.Delete;

public sealed class DeleteQuestionOptionCommandValidator
    : AbstractValidator<DeleteQuestionOptionCommand>
{
    public DeleteQuestionOptionCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage(
                "شناسه گزینه باید بزرگ‌تر از صفر باشد.");
    }
}
