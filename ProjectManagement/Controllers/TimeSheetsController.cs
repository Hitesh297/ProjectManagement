using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using ProjectManagement.Models;
using ProjectManagement.Models.ViewModels;

namespace ProjectManagement.Controllers
{
    public class TimeSheetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TimeSheetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TimeSheets
        public async Task<IActionResult> Index(int consultantId = 0, int year = 0)
        {
            ViewData["ConsultantId"] = new SelectList(_context.Consultants, "Id", "Name");
            IQueryable<TimeSheet> applicationDbContext = _context.Timesheets.Include(t => t.Consultant);
            if (consultantId != 0)
            {
                applicationDbContext = applicationDbContext.Where(x => x.Consultant.Id == consultantId);
            }

            if (year != -1)
            {
                if (year == 0)
                {
                    year = DateTime.Now.Year;
                }
                applicationDbContext = applicationDbContext.Where(x => x.Year == year);
            }
            
            ViewData["ConsultantId"] = new SelectList(_context.Consultants, "Id", "Name", consultantId);
            ViewData["Year"] = new SelectList(Constants.YearDropdown, year);

            var data = await applicationDbContext.Include(x => x.MonthData).OrderBy(x=>x.ConsultantId).OrderBy(y=>y.Year).ToListAsync();
            

            return View(data);
        }

        // GET: TimeSheets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Timesheets == null)
            {
                return NotFound();
            }

            var timeSheet = await _context.Timesheets
                .Include(t => t.Consultant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeSheet == null)
            {
                return NotFound();
            }

            return View(timeSheet);
        }

        // GET: TimeSheets/Create
        public IActionResult Create()
        {
            ViewData["ConsultantId"] = new SelectList(_context.Consultants, "Id", "Name");
            ViewData["Year"] = new SelectList(Constants.YearDropdown, DateTime.Now.Year);
            ViewData["ConsultantsList"] = _context.Consultants.ToList();

            TimesheetsViewModel viewModel = new TimesheetsViewModel();
            viewModel.MonthData = new List<MonthData>();
            List<TimeSheet> newtimesheets = new List<TimeSheet>();
            for (int i = 1; i <= 12; i++)
            {
                var monthdata = new MonthData() { Month = DateTimeFormatInfo.CurrentInfo.GetMonthName(i), MonthInt = i };
                viewModel.MonthData.Add(monthdata);
            }

            return View(viewModel);
        }

        // POST: TimeSheets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm]TimesheetsViewModel timeSheetsForm)
        {

            TimeSheet newTimeSheet = new TimeSheet();
            newTimeSheet.Year = timeSheetsForm.Year;
            newTimeSheet.ConsultantId = timeSheetsForm.ConsultantId;
            newTimeSheet.MonthData = timeSheetsForm.MonthData;
            

            if (ModelState.IsValid)
            {
                _context.Add(newTimeSheet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConsultantId"] = new SelectList(_context.Consultants, "Id", "Name", timeSheetsForm.ConsultantId);
            ViewData["Year"] = new SelectList(Constants.YearDropdown, timeSheetsForm.Year);
            return View(timeSheetsForm);
        }

        // GET: TimeSheets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Timesheets == null)
            {
                return NotFound();
            }

            var timeSheet = await _context.Timesheets.FindAsync(id);
            if (timeSheet == null)
            {
                return NotFound();
            }
            ViewData["ConsultantId"] = new SelectList(_context.Consultants, "Id", "Name", timeSheet.ConsultantId);
            return View(timeSheet);
        }

        // POST: TimeSheets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ConsultantId,Year,JanBilling,FebBilling,MarBilling,AprBilling,MayBilling,JunBilling,JulBilling,AugBilling,SepBilling,OctBilling,NovBilling,DecBilling")] TimeSheet timeSheet)
        {
            if (id != timeSheet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeSheet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeSheetExists(timeSheet.Id))
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
            ViewData["ConsultantId"] = new SelectList(_context.Consultants, "Id", "Name", timeSheet.ConsultantId);
            return View(timeSheet);
        }

        // GET: TimeSheets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Timesheets == null)
            {
                return NotFound();
            }

            var timeSheet = await _context.Timesheets
                .Include(t => t.Consultant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeSheet == null)
            {
                return NotFound();
            }

            return View(timeSheet);
        }

        // POST: TimeSheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Timesheets == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Timesheets'  is null.");
            }
            var timeSheet = await _context.Timesheets.FindAsync(id);
            if (timeSheet != null)
            {
                _context.Timesheets.Remove(timeSheet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeSheetExists(int id)
        {
          return (_context.Timesheets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
