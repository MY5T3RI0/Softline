using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Softline_API.Domain.Models
{
    /// <summary>
    /// Сущность задача.
    /// </summary>
    [Table("Goal")]
    public class Goal
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        [Key]
        public Guid ID { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Идентификатор статуса.
        /// </summary>
        public Guid Status_ID { get; set; }

        /// <summary>
        /// Статус.
        /// </summary>
        [ForeignKey("Status_ID")]
        public Status Status { get; set; }
    }
}
