namespace StatisticalSurveyQuestionnaire.Application.Features.Questions.GetById;

public sealed class GetQuestionByIdResponse
{
    public int Id { get; init; }
    
    public int QuestionnaireVersionId { get; init; }

    public string Text { get; init; } = null!;
    
    public int QuestionTypeId { get; init; }
    
    public string QuestionTypeTitle { get; init; } = null!;
    
    public int Order { get; init; }
}
