using Microsoft.EntityFrameworkCore;
using Softline_API.Abstractions;
using Softline_API.Domain.Models;

namespace Softline_API.Domain
{
    /// <summary>
    /// Контекст базы данных.
    /// </summary>
    public class SoftlineContext : DbContext
    {
        /// <summary>
        /// Создание экземпляра с указанием опций.
        /// </summary>
        /// <param name="options">Опции.</param>
        public SoftlineContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Таблица задач.
        /// </summary>
        public virtual DbSet<Goal> Goals { get; set; }

        /// <summary>
        /// Таблица статусов.
        /// </summary>
        public virtual DbSet<Status> Statuses { get; set; }
    }
}
