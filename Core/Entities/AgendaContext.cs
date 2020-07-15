using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyAgenda.Models
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {

        }

        public DbSet<DailyAgenda> DailyAgendas { get; set; }

    }
}
