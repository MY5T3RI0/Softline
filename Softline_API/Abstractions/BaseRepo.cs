using Microsoft.EntityFrameworkCore;
using Softline_API.Domain;
using Softline_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Softline_API.Abstractions
{
    /// <summary>
    /// CRUD операции над сущностями.
    /// </summary>
    /// <typeparam name="T">Тип сущности.</typeparam>
    public class BaseRepo<T> : IRepo<T> where T : class
    {
        /// <summary>
        /// Сообщение об ошибке пустой сущности.
        /// </summary>
        private const string OutOfEntityExceptionMessage = "Entity can't be null";

        /// <summary>
        /// Контекст базы данных.
        /// </summary>
        protected readonly SoftlineContext _db;

        /// <summary>
        /// Таблица сущностей.
        /// </summary>
        private readonly DbSet<T> _table;

        /// <summary>
        /// Создание экземпляра с указанием контекста базы данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <exception cref="ArgumentNullException">Пустой контекст базы данных.</exception>
        public BaseRepo(SoftlineContext context)
        {
            _db = context ?? throw new ArgumentNullException(nameof(context), "Context can't be null");
            _table = _db.Set<T>();
        }

        /// <summary>
        /// Добавление сущности.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Количество добавленных сущностей.</returns>
        /// <exception cref="ArgumentNullException">Пустая сущность.</exception>
        public async Task<int> AddAsync(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity), OutOfEntityExceptionMessage);
            }

            await _table.AddAsync(entity);

            return await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Удаление сущности.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Количество удаленных сущностей.</returns>
        /// <exception cref="ArgumentNullException">Пустая сущность.</exception>
        public async Task<int> DeleteAsync(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity), OutOfEntityExceptionMessage);
            }

            _table.Remove(entity);
            return await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Получить все сущности.
        /// </summary>
        /// <returns>Список сущностей.</returns>
        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        /// <summary>
        /// Изменить сущность.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Количество измененных сущностей.</returns>
        /// <exception cref="ArgumentNullException">Пустая сущность.</exception>
        public async Task<int> UpdateAsync(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity), OutOfEntityExceptionMessage);
            }

            _table.Update(entity);

            return await _db.SaveChangesAsync();
        }
    }
}
