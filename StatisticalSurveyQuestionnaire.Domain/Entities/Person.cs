using StatisticalSurveyQuestionnaire.Domain.Common;
using StatisticalSurveyQuestionnaire.Domain.Enums;

namespace StatisticalSurveyQuestionnaire.Domain.Entities;

/// <summary>
/// عضو خانوار
/// </summary>
public class Person: BaseEntity<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalCode { get; set; }
    public Gender Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public int Age { get; set; }
    public int EducationLevelId { get; set; }
    public string Job { get; set; }
    //وضعیت تاهل
    public int MaritalStatusId { get; set; }
    public int HouseholdId { get; set; }
    public Household Household { get; set; }
    public EducationLevel EducationLevel { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
}
