using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Softline_APP.Controllers
{
    /// <summary>
    /// Работа с представлениями домашней страницы.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Логгер.
        /// </summary>
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Создание с указанием логгирования.
        /// </summary>
        /// <param name="logger">Логгер.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Отображение представления домашней страницы.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
