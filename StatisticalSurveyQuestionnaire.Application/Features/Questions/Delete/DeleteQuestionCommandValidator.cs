using FluentValidation;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questions.Delete
{
    public sealed class DeleteQuestionCommandValidator
        : AbstractValidator<DeleteQuestionCommand>
    {
        public DeleteQuestionCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage(
                    "شناسه سوال باید بزرگ‌تر از صفر باشد.");
        }
    }
}
