using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyAgenda.Models
{
    public class DailyAgenda
    {
        [Key]
        public int DailyAgendaId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public bool IsCompleted { get; set; }

    }
}
