using StatisticalSurveyQuestionnaire.Domain.Common;

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Seed;
public static class SeedEntityHelper
{
    public static void SetAuditFields<T>(T entity)
        where T : BaseEntity<int>
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.CreatedBy = "System";

        entity.ModifiedAt = DateTime.UtcNow;
        entity.ModifiedBy = "System";

        entity.IsDeleted = false;
    }
}