using StatisticalSurveyQuestionnaire.Domain.Common;
using StatisticalSurveyQuestionnaire.Domain.Enums;

namespace StatisticalSurveyQuestionnaire.Domain.Entities;

/// <summary>
/// عضو خانوار
/// </summary>

//TODO: Create PersonConfiguration.cs
public class Person: BaseEntity<int>
{
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public string NationalCode { get; set; } = null!;
    
    public Gender Gender { get; set; }
    
    public DateTime BirthDate { get; set; }

    //TODO:محاسبه و پر کند Age فیلد ،BirthDate خود سیستم بعد از مشخص شدن فیلد
    public int Age { get; set; }
    
    public int EducationLevelId { get; set; }
    
    public int? JobId { get; set; }
    
    //وضعیت تاهل
    public int MaritalStatusId { get; set; }
    
    public int HouseholdId { get; set; }
    
    public Household Household { get; set; }
    
    public EducationLevel EducationLevel { get; set; }

    public Job? Job { get; set; }
    
    public MaritalStatus MaritalStatus { get; set; } 
}
