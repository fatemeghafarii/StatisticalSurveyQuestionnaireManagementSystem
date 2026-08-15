namespace StatisticalSurveyQuestionnaire.Application.Features.Questions.Create;

public sealed class CreateQuestionResponse
{
    public int Id { get; init; }
    
    public int QuestionnaireVersionId { get; init; }
    
    public string Text { get; init; } = null!;
    
    public int QuestionTypeId { get; init; }
    
    public int Order { get; init; }
}
