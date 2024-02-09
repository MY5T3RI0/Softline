using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Softline_API.Controllers.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Softline_APP.Controllers
{
    /// <summary>
    /// Управление представлениями задач.
    /// </summary>
    public class GoalController : Controller
    {
        /// <summary>
        /// Относительный путь к контроллеру задач.
        /// </summary>
        private const string GoalPath = "/Goal";

        /// <summary>
        /// Путь к API.
        /// </summary>
        private readonly string _baseUrl;

        /// <summary>
        /// Создание с использованием конфигурации.
        /// </summary>
        /// <param name="configuration">Конфигурация.</param>
        public GoalController(IConfiguration configuration)
        {
            _baseUrl = configuration.GetSection("ServiceAddress").Value;
        }

        /// <summary>
        /// Отображение представления с таблицей задач.
        /// </summary>
        /// <returns>Представление задач.</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(_baseUrl + GoalPath);

            if (response.IsSuccessStatusCode)
            {
                var goals = JsonConvert.DeserializeObject<List<GoalVM>>(
                await response.Content.ReadAsStringAsync());
                return View(goals);
            }

            return NotFound();
        }

        /// <summary>
        /// Отображение представления создания задачи.
        /// </summary>
        /// <returns>Представление создания задачи.</returns>
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var goalVm = new GoalVM();
            goalVm.Statuses = await GetStatuses();
            return View(goalVm);
        }

        /// <summary>
        /// Отображение представления редактирования задачи.
        /// </summary>
        /// <param name="id">Идентификатор задачи.</param>
        /// <returns>Представление редактирования задачи.</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(_baseUrl + GoalPath + $"/id?id={id}");

            if (response.IsSuccessStatusCode)
            {
                var goal = JsonConvert.DeserializeObject<GoalVM>(
                await response.Content.ReadAsStringAsync());
                goal.Statuses = await GetStatuses();
                return View(goal);
            }

            return NotFound();
        }

        /// <summary>
        /// Запрос на удаление задачи.
        /// </summary>
        /// <param name="id">Идентификатор задачи.</param>
        /// <returns>Возврат к представлению задач.</returns>
        public async Task<IActionResult> Delete(Guid id)
        {
            var client = new HttpClient();
            using var request = new HttpRequestMessage(HttpMethod.Delete,
                _baseUrl + GoalPath + $"/id?id={id}");

            var response = await client.SendAsync(request);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Запрос на создание задачи.
        /// </summary>
        /// <param name="goal">Задача.</param>
        /// <returns>Возврат к представлению задач / перезагрузка.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(GoalVM goal)
        {
            if(goal is null)
            {
                return RedirectToAction("Index");
            }

            if (goal.Status_ID == Guid.Empty)
            {
                ModelState.AddModelError("Status", "The Status field is required.");
                goal.Statuses = await GetStatuses();
                return View(goal);
            }

            goal.ID = Guid.NewGuid();
            var client = new HttpClient();
            using var request = new HttpRequestMessage(HttpMethod.Post,
                _baseUrl + GoalPath);
            request.Content = new StringContent(JsonConvert.SerializeObject(goal))
            {
                Headers = {
                  ContentType = MediaTypeHeaderValue.Parse("application/json"),
                }
            };

            await client.SendAsync(request);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Запрос на изменение задачи.
        /// </summary>
        /// <param name="goal">Задача.</param>
        /// <returns>Возврат к представлению задач / перезагрузка.</returns>
        public async Task<IActionResult> Edit(GoalVM goal)
        {
            if (goal is null)
            {
                return RedirectToAction("Index");
            }

            if (goal.Status_ID == Guid.Empty)
            {
                ModelState.AddModelError("Status", "The Status field is required.");
                goal.Statuses = await GetStatuses();
                return View(goal);
            }

            var client = new HttpClient();
            using var request = new HttpRequestMessage(HttpMethod.Put,
                _baseUrl + GoalPath);
            request.Content = new StringContent(JsonConvert.SerializeObject(goal))
            {
                Headers = {
                  ContentType = MediaTypeHeaderValue.Parse("application/json"),
                }
            };

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(goal);
        }

        /// <summary>
        /// Получение списка статусов.
        /// </summary>
        /// <returns>Список статусов.</returns>
        private async Task<List<StatusVM>> GetStatuses()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(_baseUrl + "/Status");

            if (response.IsSuccessStatusCode)
            {
                var statuses = JsonConvert.DeserializeObject<List<StatusVM>>(
                await response.Content.ReadAsStringAsync());
                return statuses;
            }

            return new List<StatusVM>();
        }
    }
}
