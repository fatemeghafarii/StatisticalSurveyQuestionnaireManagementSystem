namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.Create;

public sealed class CreateQuestionnaireResponse
{
    // TODO:بعدا چک کن اگه فیلدی اضافه بود حذف کن 
    public int Id { get; init; }
    
    public string Title { get; init; } = null!;
    
    public string Code { get; init; } = null!;
    
    public bool IsActive { get; init; }
}