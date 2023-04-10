using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using ProjectManagement.Data.UnitOfWorks;
using ProjectManagement.Models;
using ProjectManagement.Models.ViewModels;

namespace ProjectManagement.Controllers
{
    public class TimeSheetsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TimeSheetsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: TimeSheets
        public async Task<IActionResult> Index(int consultantId = 0, int year = 0)
        {
            ViewData["ConsultantId"] = new SelectList(_unitOfWork.Consultants.GetAll().ToList(), "Id", "Name");
            IQueryable<TimeSheet> applicationDbContext = _unitOfWork.TimeSheets.GetAllIncluding(t => t.Consultant);
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

            ViewData["ConsultantId"] = new SelectList(_unitOfWork.Consultants.GetAll().ToList(), "Id", "Name", consultantId);
            ViewData["Year"] = new SelectList(Constants.YearDropdown, year);

            var data = await applicationDbContext.Include(x => x.MonthData).OrderBy(x => x.ConsultantId).OrderBy(y => y.Year).ToListAsync();


            return View(data);
        }

        // GET: TimeSheets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _unitOfWork.TimeSheets.GetAll() == null)
            {
                return NotFound();
            }

            var timeSheet = await _unitOfWork.TimeSheets.GetAllIncluding
                (t => t.MonthData)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeSheet == null)
            {
                return NotFound();
            }

            TimesheetsViewModel timeSheetVm = new TimesheetsViewModel();
            timeSheetVm.Id = timeSheet.Id;
            timeSheetVm.Year = timeSheet.Year;
            timeSheetVm.ConsultantId = timeSheet.ConsultantId;
            timeSheetVm.MonthData = timeSheet.MonthData.ToList();

            ViewData["ConsultantId"] = new SelectList(_unitOfWork.Consultants.GetAllActive().ToList(), "Id", "Name", timeSheet.ConsultantId);
            ViewData["Year"] = new SelectList(Constants.YearDropdown, timeSheet.Year);

            return View(timeSheetVm);
        }

        // GET: TimeSheets/Create
        public IActionResult Create()
        {
            var defaultYear = DateTime.Now.Year;
            ViewData["ConsultantId"] = new SelectList(_unitOfWork.Consultants.GetAllActive().ToList(), "Id", "Name");
            ViewData["Year"] = new SelectList(Constants.YearDropdown, defaultYear);
            ViewData["ConsultantsList"] = _unitOfWork.Consultants.GetAll().ToList();

            TimesheetsViewModel viewModel = new TimesheetsViewModel();
            viewModel.Year = defaultYear;
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
        public async Task<IActionResult> Create([FromForm] TimesheetsViewModel timeSheetsForm)
        {

            TimeSheet newTimeSheet = new TimeSheet();
            newTimeSheet.Year = timeSheetsForm.Year;
            newTimeSheet.ConsultantId = timeSheetsForm.ConsultantId;
            newTimeSheet.MonthData = timeSheetsForm.MonthData;


            if (ModelState.IsValid)
            {
                _unitOfWork.TimeSheets.Add(newTimeSheet);
                await _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConsultantId"] = new SelectList(_unitOfWork.Consultants.GetAllActive().ToList(), "Id", "Name", timeSheetsForm.ConsultantId);
            ViewData["Year"] = new SelectList(Constants.YearDropdown, timeSheetsForm.Year);
            return View(timeSheetsForm);
        }

        // GET: TimeSheets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _unitOfWork.TimeSheets.GetAll() == null)
            {
                return NotFound();
            }

            var timeSheet = await _unitOfWork.TimeSheets.GetAllIncluding(x => x.MonthData).Where(x => x.Id == id).FirstAsync();

            if (timeSheet == null)
            {
                return NotFound();
            }

            TimesheetsViewModel timeSheetVm = new TimesheetsViewModel();
            timeSheetVm.Id = timeSheet.Id;
            timeSheetVm.Year = timeSheet.Year;
            timeSheetVm.ConsultantId = timeSheet.ConsultantId;
            timeSheetVm.MonthData = timeSheet.MonthData.ToList();

            ViewData["ConsultantsList"] = _unitOfWork.Consultants.GetAll().ToList();
            ViewData["ConsultantId"] = new SelectList(_unitOfWork.Consultants.GetAllActive().ToList(), "Id", "Name", timeSheet.ConsultantId);
            ViewData["Year"] = new SelectList(Constants.YearDropdown, timeSheet.Year);
            return View(timeSheetVm);
        }

        // POST: TimeSheets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] TimeSheet timeSheet)
        {
            if (id != timeSheet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.TimeSheets.Update(timeSheet);
                    await _unitOfWork.Complete();
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
            ViewData["ConsultantsList"] = _unitOfWork.Consultants.GetAll().ToList();
            ViewData["ConsultantId"] = new SelectList(_unitOfWork.Consultants.GetAllActive().ToList(), "Id", "Name", timeSheet.ConsultantId);
            ViewData["Year"] = new SelectList(Constants.YearDropdown, timeSheet.Year);
            return View(timeSheet);
        }

        // GET: TimeSheets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _unitOfWork.TimeSheets.GetAll() == null)
            {
                return NotFound();
            }

            var timeSheet = await _unitOfWork.TimeSheets.GetAllIncluding
                (t => t.Consultant)
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
            if (_unitOfWork.TimeSheets.GetAll() == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Timesheets'  is null.");
            }
            var timeSheet = await _unitOfWork.TimeSheets.FindAsync(id);
            if (timeSheet != null)
            {
                _unitOfWork.TimeSheets.Remove(timeSheet);
            }

            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeSheetExists(int id)
        {
            return (_unitOfWork.TimeSheets?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpGet]
        [Route("Timesheets/ExportAsCSV/{consultantId}/{year}")]
        public IActionResult ExportAsCSV(int consultantId, int year)
        {
            IQueryable<TimeSheet> applicationDbContext = _unitOfWork.TimeSheets.GetAllIncluding(t => t.Consultant);
            if (consultantId != 0)
            {
                applicationDbContext = applicationDbContext.Where(x => x.Consultant.Id == consultantId);
            }

            if (year != 0 && year != -1)
            {

                applicationDbContext = applicationDbContext.Where(x => x.Year == year);
            }

            var timeSheets = applicationDbContext.Include(x => x.MonthData).OrderBy(x => x.ConsultantId).OrderBy(y => y.Year).ToList();
            StringBuilder sb = new StringBuilder();
            if (timeSheets.Count != 0)
            {
                sb.Append($"Consultant Name,Year");
                foreach (var month in timeSheets[0].MonthData)
                {
                    sb.Append($",{month.Month}");
                }
                sb.Append("\r\n");
                foreach (var item in timeSheets)
                {
                    sb.Append($"{item.Consultant.Name},{item.Year}");
                    foreach (var timesheet in item.MonthData)
                    {
                        sb.Append($",{timesheet.Hours}");
                    }
                    sb.Append("\r\n");
                }
            }

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Grid.csv");
        }
    }
}
