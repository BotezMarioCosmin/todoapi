using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    [Table("groups", Schema = "todoapp")]
    public class Group
    {
        public long id { get; set; }
        public string? nome { get; set; }

        public string? descrizione { get; set; }

    }
}