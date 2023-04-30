using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using ProjectManagement.Data.UnitOfWorks;
using ProjectManagement.Models;
using ProjectManagement.Models.Utilities;
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
            var records = new List<dynamic>();

            if (timeSheets.Count != 0)
            {
                foreach (var timeSheet in timeSheets)
                {
                    dynamic record = new ExpandoObject();
                    record.UniqueConsultantId = timeSheet.Consultant.UniqueConsultantId;
                    record.ConsultantName = timeSheet.Consultant.Name;
                    record.Year = timeSheet.Year;
                    record.January = timeSheet.MonthData?.Where(x => x.MonthInt == 1).FirstOrDefault()?.Hours;
                    record.February = timeSheet.MonthData?.Where(x => x.MonthInt == 2).FirstOrDefault()?.Hours;
                    record.March = timeSheet.MonthData?.Where(x => x.MonthInt == 3).FirstOrDefault()?.Hours;
                    record.April = timeSheet.MonthData?.Where(x => x.MonthInt == 4).FirstOrDefault()?.Hours;
                    record.May = timeSheet.MonthData?.Where(x => x.MonthInt == 5).FirstOrDefault()?.Hours;
                    record.June = timeSheet.MonthData?.Where(x => x.MonthInt == 6).FirstOrDefault()?.Hours;
                    record.July = timeSheet.MonthData?.Where(x => x.MonthInt == 7).FirstOrDefault()?.Hours;
                    record.August = timeSheet.MonthData?.Where(x => x.MonthInt == 8).FirstOrDefault()?.Hours;
                    record.September = timeSheet.MonthData?.Where(x => x.MonthInt == 9).FirstOrDefault()?.Hours;
                    record.October = timeSheet.MonthData?.Where(x => x.MonthInt == 10).FirstOrDefault()?.Hours;
                    record.November = timeSheet.MonthData?.Where(x => x.MonthInt == 11).FirstOrDefault()?.Hours;
                    record.December = timeSheet.MonthData?.Where(x => x.MonthInt == 12).FirstOrDefault()?.Hours;
                    records.Add(record);
                }

                using (var writer = new StringWriter())
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(records);

                    return File(Encoding.UTF8.GetBytes(writer.ToString()), "text/csv", "TimeSheets.csv");
                }
            }

            return View("Error");
        }

        [HttpGet]
        public IActionResult DownloadImportTemplate()
        {
            var records = new List<dynamic>();

            dynamic record = new ExpandoObject();
            record.UniqueConsultantId = "";
            record.ConsultantName = "";
            record.Hours = "";
            record.PaidAmount = "";
            record.MonthNumber = "";
            record.Year = "";
            records.Add(record);

            using (var writer = new StringWriter())
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);

                return File(Encoding.UTF8.GetBytes(writer.ToString()), "text/csv", "Import Template.csv");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ImportTimesheet(IFormFile file)
        {
            try
            {
                var fileextension = Path.GetExtension(file.FileName);

                if (fileextension == ".csv")
                {
                    List<Consultant> newConsultants = new List<Consultant>();
                    List<Consultant> existingConsultants = new List<Consultant>();
                    using (var reader = new StreamReader(file.OpenReadStream()))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        //csv.Context.TypeConverterOptionsCache.GetOptions<DateTime>().NullValues.AddRange(new[] { "NULL", "0" });
                        csv.Context.TypeConverterOptionsCache.GetOptions<decimal?>().NullValues.Add("0");
                        csv.Context.RegisterClassMap<TimesheetCsvMap>();

                        var records = csv.GetRecords<TimesheetCsv>();
                        foreach (var record in records)
                        {

                            Consultant consultant = _unitOfWork.Consultants.GetAll().Where(x => x.UniqueConsultantId == record.UniqueConsultantId).FirstOrDefault();
                            if (consultant == null)
                            {
                                return NotFound($"Consultant with Id {record.UniqueConsultantId} not found! ");
                            }

                            TimeSheet timeSheet = _unitOfWork.TimeSheets.GetAllIncluding(x => x.MonthData)
                                .Where(x => x.ConsultantId == consultant.Id)
                                .Where(y => y.Year == record.Year).FirstOrDefault();


                            if (timeSheet == null)
                            {
                                timeSheet = new TimeSheet()
                                {
                                    ConsultantId = consultant.Id,
                                    Year = record.Year
                                };
                                timeSheet.MonthData = new List<MonthData>();
                                for (int i = 1; i <= 12; i++)
                                {
                                    if (i == record.MonthNumber)
                                    {
                                        MonthData monthData = new MonthData()
                                        {
                                            Hours = record.Hours,
                                            PaidAmount = record.PaidAmount,
                                            MonthInt = record.MonthNumber,
                                            Month = DateTimeFormatInfo.CurrentInfo.GetMonthName(record.MonthNumber),
                                            InvoiceAmount = consultant.BillingRate * record.Hours,
                                            ConsultantPay = consultant.PayRate * record.Hours,
                                            Variation = record.Variation,
                                            NetProfit = consultant.NetMargin * record.Hours

                                        };
                                        timeSheet.MonthData.Add(monthData);
                                    }
                                    else
                                    {
                                        var monthdata = new MonthData() { Month = DateTimeFormatInfo.CurrentInfo.GetMonthName(i), MonthInt = i };
                                        timeSheet.MonthData.Add(monthdata);
                                    }
                                }
                                _unitOfWork.TimeSheets.Add(timeSheet);
                                await _unitOfWork.Complete();
                            }
                            else
                            {
                                var existingMonthData = timeSheet.MonthData
                                     .Where(x => x.MonthInt == record.MonthNumber)
                                     .FirstOrDefault();
                                if (existingMonthData == null)
                                {
                                    MonthData monthData = new MonthData()
                                    {
                                        Hours = record.Hours,
                                        PaidAmount = record.PaidAmount,
                                        MonthInt = record.MonthNumber,
                                        TimesheetId = timeSheet.Id,
                                        InvoiceAmount = consultant.BillingRate * record.Hours,
                                        ConsultantPay = consultant.PayRate * record.Hours,
                                        Variation = record.Variation,
                                        NetProfit = consultant.NetMargin * record.Hours

                                    };
                                    timeSheet.MonthData.Add(monthData);
                                }
                                else
                                {
                                    existingMonthData.Hours = record.Hours;
                                    existingMonthData.PaidAmount = record.PaidAmount;
                                    existingMonthData.InvoiceAmount = consultant.BillingRate * record.Hours;
                                    existingMonthData.ConsultantPay = consultant.PayRate * record.Hours;
                                    existingMonthData.Variation = record.Variation;
                                    existingMonthData.NetProfit = consultant.NetMargin * record.Hours;
                                }
                                _unitOfWork.TimeSheets.Update(timeSheet);
                            }

                        }
                    }


                    await _unitOfWork.Complete();
                }
                else
                {
                    return Problem("Please select a file with .csv extension");
                }

            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
            //return View("LoadData");
            return Ok("Upload Complete");
        }
    }
}
