using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Softline_API.Abstractions;
using Softline_API.Controllers.Models;
using Softline_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Softline_API.Controllers
{
    /// <summary>
    /// Обработка Put, Get, Post, Delete запросов над задачами.
    /// </summary>
    [Route("api/[controller]")]
    public class GoalController : Controller
    {
        /// <summary>
        /// Сообщение ошибки о пустом статусе.
        /// </summary>
        private const string OutOfGoalExceptionMessage = "Goal can't be null";

        /// <summary>
        /// Репозиторий задач.
        /// </summary>
        private readonly IGoalRepo _repo;

        /// <summary>
        /// Маппер.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Создание с заданием маппера и репозитория.
        /// </summary>
        /// <param name="repo">Репозиторий.</param>
        /// <param name="mapper">Маппер.</param>
        /// <exception cref="ArgumentNullException">Пустой аргумент.</exception>
        public GoalController(IGoalRepo repo, IMapper mapper)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo), "Repository can't be null");
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Mapper can't be null");
        }

        /// <summary>
        /// Получение всех записей задач.
        /// </summary>
        /// <returns>Список записей задач.</returns>
        [HttpGet]
        public async Task<ActionResult<List<GoalVM>>> GetAll()
        {
            var goalsDto = await _repo.GetAllAsync();
            var goals = _mapper.Map<List<GoalVM>>(goalsDto);

            return Ok(goals);
        }

        /// <summary>
        /// Получение задачи по id.
        /// </summary>
        /// <returns>Задача.</returns>
        [HttpGet("id")]
        public async Task<ActionResult<GoalVM>> Get(Guid id)
        {
            var goalDto = await _repo.GetAsync(id);
            var goal = _mapper.Map<GoalVM>(goalDto);

            return Ok(goal);
        }

        /// <summary>
        /// Добавление новой задачи.
        /// </summary>
        /// <param name="goal">Задача.</param>
        /// <returns>Количество добавленных задач.</returns>
        /// <exception cref="ArgumentNullException">Пустой статус.</exception>
        [HttpPost]
        public async Task<ActionResult<int>> CreateGoal([FromBody] GoalVM goal)
        {
            if (goal is null)
            {
                throw new ArgumentNullException(nameof(goal), OutOfGoalExceptionMessage);
            }

            var goalDto = _mapper.Map<Goal>(goal);
            var entitiesChanged = await _repo.AddAsync(goalDto);

            return Ok(entitiesChanged);
        }

        /// <summary>
        /// Изменение задачи. 
        /// </summary>
        /// <param name="goal">Задача.</param>
        /// <returns>Количество измененных задач.</returns>
        ///  <exception cref="ArgumentNullException">Пустой статус.</exception>
        [HttpPut]
        public async Task<ActionResult<int>> EditGoal([FromBody] GoalVM goal)
        {
            if (goal is null)
            {
                throw new ArgumentNullException(nameof(goal), OutOfGoalExceptionMessage);
            }

            var goalDto = _mapper.Map<Goal>(goal);
            var entitiesChanged = await _repo.UpdateAsync(goalDto);

            return Ok(entitiesChanged);
        }

        /// <summary>
        /// Удаление задачи.
        /// </summary>
        /// <param name="goal">Задача.</param>
        /// <returns>Количество удаленных задач.</returns>
        ///  <exception cref="ArgumentNullException">Пустой статус.</exception>
        [HttpDelete]
        public async Task<ActionResult<int>> DeleteGoal(GoalVM goal)
        {
            if (goal is null)
            {
                throw new ArgumentNullException(nameof(goal), OutOfGoalExceptionMessage);
            }

            var goalDto = _mapper.Map<Goal>(goal);
            var entitiesChanged = await _repo.DeleteAsync(goalDto);

            return Ok(entitiesChanged);
        }

        /// <summary>
        /// Удаление задачи по id.
        /// </summary>
        /// <param name="goal">Id задачи.</param>
        /// <returns>Количество удаленных задач.</returns>
        [HttpDelete("id")]
        public async Task<ActionResult<int>> DeleteGoal(Guid id)
        {
            var entitiesChanged = await _repo.DeleteAsync(id);

            return Ok(entitiesChanged);
        }
    }
}
