using StatisticalSurveyQuestionnaire.Domain.Common;

namespace StatisticalSurveyQuestionnaire.Domain.Entities;

public class QuestionnaireVersionStatusType : LookupEntity
{
    public ICollection<QuestionnaireVersion> QuestionnaireVersions { get; set; } = new List<QuestionnaireVersion>();
}