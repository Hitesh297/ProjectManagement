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
            DashboardVM dashboardVM = new DashboardVM();


            dashboardVM.ConsultantByClientVM  = new ConsultantByClientVM();
            dashboardVM.RevenueByRecruiterVM = new RevenueByRecruiterVM();
            dashboardVM.ConsultantByClientVM.ClientByMonthList = new List<ClientConsultantsByMonth>();
            dashboardVM.RevenueByRecruiterVM.RecruiterByProfitList = new List<RecruiterProfitByMonth>();

            IQueryable<MonthData> timesheets = _unitOfWork.MonthData.GetAllIncluding(t => t.TimeSheet, t => t.TimeSheet.Consultant, t => t.TimeSheet.Consultant.Client);
            var active = timesheets.Where(x => x.Hours != null && x.Hours != 0).Where(y=>y.TimeSheet.Year == 2023).ToList();

            var results = active.GroupBy(n => new { n.TimeSheet.Consultant.Client, n.MonthInt})
                .Select(g => new ClientConsultantsByMonth {
                    Client = g.Key.Client,
                     Month =  g.Key.MonthInt,
                   ActiveConsultants = g.Count() });

            dashboardVM.ConsultantByClientVM.ClientByMonthList = results.ToList();


            var monthlyData = _unitOfWork.MonthData
                .GetAllIncluding(t => t.TimeSheet, t => t.TimeSheet.Consultant, 
                t => t.TimeSheet.Consultant.Client,
                t => t.TimeSheet.Consultant.Recruiter)
                .Where(x => x.Hours != null && x.Hours != 0).ToList();

            var recruiterResults = monthlyData.GroupBy(n => new { n.TimeSheet.Consultant.Recruiter, n.MonthInt })
                .Select(g => new RecruiterProfitByMonth
                {
                    Recruiter = g.Key.Recruiter,
                    Month = g.Key.MonthInt,
                    NetProfitByRecruiter = g.Sum(x => x.NetProfit)
                });


            dashboardVM.RevenueByRecruiterVM.RecruiterByProfitList = recruiterResults.ToList();

            return View(dashboardVM);
        }
    }
}
