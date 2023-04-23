using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data.UnitOfWorks;
using ProjectManagement.Models;
using ProjectManagement.Models.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace ProjectManagement.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            
            ConsultantByClientVM consultantByClientVM = new ConsultantByClientVM();
            consultantByClientVM.ClientByMonthList = new List<ClientByMonth>();

            IQueryable<MonthData> timesheets = _unitOfWork.MonthData.GetAllIncluding(t => t.TimeSheet, t => t.TimeSheet.Consultant, t => t.TimeSheet.Consultant.Client);
            var active = timesheets.Where(x => x.Hours != null && x.Hours != 0).Where(y=>y.TimeSheet.Year == 2023).ToList();

            var results = active.GroupBy(n => new { n.TimeSheet.Consultant.Client, n.MonthInt})
                .Select(g => new ClientByMonth {
                    Client = g.Key.Client,
                     Month =  g.Key.MonthInt,
                   ActiveConsultants = g.Count() });

            consultantByClientVM.ClientByMonthList = results.ToList();
            return View(consultantByClientVM);
        }
    }
}
