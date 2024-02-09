using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Softline_API.Controllers.Models
{
    /// <summary>
    /// Модель задачи.
    /// </summary>
    public class GoalVM
    {
        /// <summary>
        /// Создание экземпляра без параметров.
        /// </summary>
        public GoalVM()
        {
            Statuses = new List<StatusVM>();
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        [Required]
        [DisplayName("Наименование")]
        public string Name { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        [Required]
        [DisplayName("Описание")]
        public string Description { get; set; }

        /// <summary>
        /// Идентификатор статуса.
        /// </summary>
        [Required]
        public Guid Status_ID { get; set; }

        /// <summary>
        /// Статус.
        /// </summary>
        public StatusVM Status { get; set; }

        /// <summary>
        /// Список всех статусов.
        /// </summary>
        public List<StatusVM> Statuses { get; set; }
    }
}
