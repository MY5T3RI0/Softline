using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Softline_API.Domain.Models
{
    /// <summary>
    /// Сущность статус.
    /// </summary>
    [Table("Status")]
    public class Status
    {
        [Key]
        public Guid Status_ID { get; set; }
        public string Status_name { get; set; }

    }
}
