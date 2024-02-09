using System;
using System.ComponentModel;

namespace Softline_API.Controllers.Models
{
    /// <summary>
    /// Модель статуса.
    /// </summary>
    public class StatusVM
    {
        /// <summary>
        /// Создание без параметров.
        /// </summary>
        public StatusVM()
        {
        }

        /// <summary>
        /// Идентификатор статуса.
        /// </summary>
        public Guid Status_ID { get; set; }

        /// <summary>
        /// Название статуса.
        /// </summary>
        [DisplayName("Статус")]
        public string Status_name { get; set; }
    }
}
