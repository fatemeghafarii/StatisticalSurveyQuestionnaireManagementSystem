using FluentValidation;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionOptions.Update;

public sealed class UpdateQuestionOptionCommandValidator
    : AbstractValidator<UpdateQuestionOptionCommand>
{
    public UpdateQuestionOptionCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage(
                "شناسه گزینه ی سوال باید بزرگ ‌تر از صفر باشد.");

        RuleFor(x => x.Text)
            .NotEmpty()
            .WithMessage("متن گزینه الزامی است.")
            .MaximumLength(500)
            .WithMessage("متن گزینه نباید بیشتر از ۵۰۰ کاراکتر باشد.");
    }
}
