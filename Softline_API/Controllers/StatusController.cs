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
    /// Обработка Put, Get, Post, Delete запросов над статусами.
    /// </summary>
    [Route("api/[controller]")]
    public class StatusController : Controller
    {
        /// <summary>
        /// Сообщение ошибки о пустом статусе.
        /// </summary>
        private const string OutOfStatusExceptionMessage = "Status can't be null";

        /// <summary>
        /// Репозиторий статусов.
        /// </summary>
        private readonly IRepo<Status> _repo;

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
        public StatusController(IRepo<Status> repo, IMapper mapper)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo), "Repository can't be null");
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Mapper can't be null");
        }

        /// <summary>
        /// Получение всех статусов.
        /// </summary>
        /// <returns>Список статусов.</returns>
        [HttpGet]
        public async Task<ActionResult<List<StatusVM>>> GetAll()
        {
            var goals = _mapper.Map<List<StatusVM>>(await _repo.GetAllAsync());

            return Ok(goals);
        }

        /// <summary>
        /// Создание нового статуса.
        /// </summary>
        /// <param name="status">Статус.</param>
        /// <returns>Количество добавленных статусов.</returns>
        /// <exception cref="ArgumentNullException">Пустой статус.</exception>
        [HttpPost]
        public async Task<ActionResult<int>> CreateStatus([FromBody] StatusVM status)
        {
            if (status is null)
            {
                throw new ArgumentNullException(nameof(status), OutOfStatusExceptionMessage);
            }

            var goalDto = _mapper.Map<Status>(status);
            var entitiesChanged = await _repo.AddAsync(goalDto);

            return Ok(entitiesChanged);
        }

        /// <summary>
        /// Изменение статуса.
        /// </summary>
        /// <param name="status">Статус.</param>
        /// <returns>Количество измененных статусов.</returns>
        /// <exception cref="ArgumentNullException">Пустой статус.</exception>
        [HttpPut]
        public async Task<ActionResult<int>> EditStatus([FromBody] StatusVM status)
        {
            if (status is null)
            {
                throw new ArgumentNullException(nameof(status), OutOfStatusExceptionMessage);
            }

            var goalDto = _mapper.Map<Status>(status);
            var entitiesChanged = await _repo.UpdateAsync(goalDto);

            return Ok(entitiesChanged);
        }

        /// <summary>
        /// Удаление статуса.
        /// </summary>
        /// <param name="status">Статус.</param>
        /// <returns>Количество удаленных статусов.</returns>
        /// <exception cref="ArgumentNullException">Пустой статус.</exception>
        [HttpDelete]
        public async Task<ActionResult<int>> DeleteStatus(StatusVM status)
        {
            if (status is null)
            {
                throw new ArgumentNullException(nameof(status), OutOfStatusExceptionMessage);
            }

            var goalDto = _mapper.Map<Status>(status);
            var entitiesChanged = await _repo.DeleteAsync(goalDto);

            return Ok(entitiesChanged);
        }
    }
}
