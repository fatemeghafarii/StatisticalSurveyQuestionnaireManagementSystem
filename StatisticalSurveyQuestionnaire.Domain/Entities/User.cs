using StatisticalSurveyQuestionnaire.Domain.Common;
using System.Security.Principal;

namespace StatisticalSurveyQuestionnaire.Domain.Entities;

//TODO: This raises an architectural question:
//Are you building your own authentication system, or are you going to use ASP.NET Core Identity?
//For a professional production application, I would strongly recommend ASP.NET Core Identity rather than implementing password authentication yourself.
// If you use ASP.NET Core Identity so User not be necessary
public class User: BaseEntity<int>
{
    public string Username { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public int RoleId { get; set; }
    public Role Role { get; set; } = null!; 
}
