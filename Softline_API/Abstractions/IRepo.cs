using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Softline_API.Abstractions
{
    /// <summary>
    /// Абстракция репозитория.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepo<T> where T : class
    {
        /// <summary>
        /// Добавление сущности.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Количество добавленных сущностей.</returns>
        Task<int> AddAsync(T entity);

        /// <summary>
        /// Изменение сущности.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Количество измененных сущностей.</returns>
        Task<int> UpdateAsync(T entity);

        /// <summary>
        /// Удаление сущностей.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Количество удаляемых сущностей.</returns>
        Task<int> DeleteAsync(T entity);

        /// <summary>
        /// Получение всех сущностей.
        /// </summary>
        /// <returns>Список сущностей.</returns>
        Task<List<T>> GetAllAsync();
    }
}
