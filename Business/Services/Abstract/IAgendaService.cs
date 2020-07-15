using EasyAgenda.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface IAgendaService
    {
        Task<List<DailyAgenda>> ListSchedule();
        Task<List<DailyAgenda>> ListScheduleOrderByTime();
        Task<List<DailyAgenda>> ListScheduleOrderBySubject();
        Task<DailyAgenda> Details(int? id);
        Task<DailyAgenda> AddActivity(DailyAgenda model);
        Task<DailyAgenda> EditActivity(int? id);
        Task<DailyAgenda> EditActivity(int? id, DailyAgenda model);
        Task<DailyAgenda> DeleteActivity(int? id);
        Task<DailyAgenda> DeleteConfirmed(int id);
        bool AgendaExistence(int id);

    }
}
