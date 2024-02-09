using Microsoft.EntityFrameworkCore;
using Softline_API.Domain;
using Softline_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Softline_API.Abstractions
{
    public class GoalRepo : BaseRepo<Goal>, IGoalRepo
    {
        public GoalRepo(SoftlineContext context) : base(context)
        {
            
        }

        /// <summary>
        /// Получить все сущности задач.
        /// </summary>
        /// <returns>Список сущностей задач.</returns>
        public override async Task<List<Goal>> GetAllAsync()
        {
            return await _db.Goals.Include(x => x.Status).ToListAsync();
        }

        /// <summary>
        /// Получить сущность задачи по id.
        /// </summary>
        /// <returns>Сущность задачи.</returns>
        public async Task<Goal> GetAsync(Guid id)
        {
            return await _db.Goals.Include(x => x.Status).FirstOrDefaultAsync(x => x.ID == id);
        }

        /// <summary>
        /// Удалить сущность задачи по id.
        /// </summary>
        /// <returns>Количество удаленных сущностей.</returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            var goal = await _db.Goals.FirstOrDefaultAsync(x => x.ID == id);
            return await DeleteAsync(goal);
        }
    }
}
