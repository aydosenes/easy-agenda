using Business.Services.Abstract;
using EasyAgenda.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class AgendaService : IAgendaService
    {
        private readonly AgendaContext _context;

        public AgendaService(AgendaContext context)
        {
            _context = context;
        }

        public async Task<DailyAgenda> AddActivity(DailyAgenda model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public bool AgendaExistence(int id)
        {
            var result = _context.DailyAgendas.Any(e => e.DailyAgendaId == id);

            return result;
        }

        public async Task<DailyAgenda> DeleteActivity(int? id)
        {
            var result = await _context.DailyAgendas.FirstOrDefaultAsync(m => m.DailyAgendaId == id);

            return result;
        }

        public async Task<DailyAgenda> DeleteConfirmed(int id)
        {
            var result = await _context.DailyAgendas.FindAsync(id);
            _context.DailyAgendas.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<DailyAgenda> Details(int? id)
        {
            var detail = await _context.DailyAgendas.FirstOrDefaultAsync(m => m.DailyAgendaId == id);

            return detail;
        }

        public async Task<DailyAgenda> EditActivity(int? id)
        {
            var result = await _context.DailyAgendas.FindAsync(id);

            return result;
        }

        public async Task<DailyAgenda> EditActivity(int? id, DailyAgenda model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<List<DailyAgenda>> ListSchedule()
        {
            var result = await _context.DailyAgendas.ToListAsync();

            return result;
        }

        public async Task<List<DailyAgenda>> ListScheduleOrderBySubject()
        {
            var result = await _context.DailyAgendas.OrderByDescending(x => x.Subject).ToListAsync();

            return result;
        }

        public async Task<List<DailyAgenda>> ListScheduleOrderByTime()
        {
            var result = await _context.DailyAgendas.OrderBy(x => x.Time).ToListAsync();

            return result;
        }
    }
}
