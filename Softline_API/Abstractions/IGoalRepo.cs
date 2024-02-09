using System.Threading.Tasks;
using System;
using Softline_API.Domain.Models;

namespace Softline_API.Abstractions
{
    public interface IGoalRepo : IRepo<Goal>
    {
        /// <summary>
        /// Получение сущности по id.
        /// </summary>
        /// <returns>Сущность.</returns>
        Task<Goal> GetAsync(Guid id);

        /// <summary>
        /// Удалить сущность задачи по id.
        /// </summary>
        /// <returns>Количество удаленных сущностей.</returns>
        Task<int> DeleteAsync(Guid id);
    }
}
