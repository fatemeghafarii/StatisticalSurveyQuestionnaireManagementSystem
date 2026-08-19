namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.Update;

public sealed class UpdateQuestionnaireResponse
{
    public int Id { get; init; }

    public string Title { get; init; } = null!;

    public string? Description { get; init; } = null!;

    public string Code { get; set; } = null!;

    public bool IsActive { get; init; }
}
