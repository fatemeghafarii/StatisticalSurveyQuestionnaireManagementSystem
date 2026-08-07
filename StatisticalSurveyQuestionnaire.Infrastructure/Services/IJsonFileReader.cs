namespace StatisticalSurveyQuestionnaire.Infrastructure.Services;
public interface IJsonFileReader
{
    Task<T?> ReadAsync<T>(string fileName);
}
