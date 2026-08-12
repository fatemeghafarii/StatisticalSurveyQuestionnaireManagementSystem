using StatisticalSurveyQuestionnaire.Domain.Common;

namespace StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
public interface IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>, new()
                                            where TKey : struct
{
        //Task AddAsync(...);

        //Task DeleteAsync(...);

        //Task SaveChangesAsync();
        //use singleordefault method for find one id 
}
