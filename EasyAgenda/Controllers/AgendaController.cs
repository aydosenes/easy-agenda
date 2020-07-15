using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EasyAgenda.Models;
using Business.Services.Abstract;

namespace EasyAgenda.Controllers
{
    public class AgendaController : Controller
    {
        private readonly AgendaContext _context;
        private readonly IAgendaService _agendaService;
        public AgendaController(AgendaContext context, IAgendaService agendaService)
        {
            _context = context;
            _agendaService = agendaService;
        }
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewBag.TimeSortParam = String.IsNullOrEmpty(sortOrder) ? "time_desc" : "";

            var result = await _agendaService.ListSchedule();

            switch (sortOrder)
            {
                case "time_desc":
                    result = await _agendaService.ListScheduleOrderByTime();
                    break;
                default:
                    result = await _agendaService.ListScheduleOrderBySubject();
                    break;
            }
            return View(result);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var detail = await _agendaService.Details(id);
            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DailyAgendaId,Subject,Description,Time,IsCompleted")] DailyAgenda dailyAgenda)
        {
            if (ModelState.IsValid)
            {
                await _agendaService.AddActivity(dailyAgenda);
                return RedirectToAction(nameof(Index));
            }
            return View(dailyAgenda);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _agendaService.EditActivity(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DailyAgendaId,Subject,Description,Time,IsCompleted")] DailyAgenda dailyAgenda)
        {
            if (id != dailyAgenda.DailyAgendaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _agendaService.EditActivity(id,dailyAgenda);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DailyAgendaExists(dailyAgenda.DailyAgendaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dailyAgenda);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _agendaService.DeleteActivity(id);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _agendaService.DeleteConfirmed(id);

            return RedirectToAction(nameof(Index));
        }

        private bool DailyAgendaExists(int id)
        {
            return _agendaService.AgendaExistence(id);
        }
    }
}
