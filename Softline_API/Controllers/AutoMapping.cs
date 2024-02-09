using AutoMapper;
using Softline_API.Controllers.Models;
using Softline_API.Domain.Models;

namespace Softline_API.Controllers
{
    /// <summary>
    /// Маппинг сущностей с моделями.
    /// </summary>
    public class AutoMapping : Profile
    {
        /// <summary>
        /// Создание с конфигурацией маппинга.
        /// </summary>
        public AutoMapping()
        {
            CreateMap<Goal, GoalVM>();
            CreateMap<Status, StatusVM>();
            CreateMap<StatusVM, Status>();
            CreateMap<GoalVM, Goal>();
        }
    }
}
