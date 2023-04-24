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
            dashboardVM.RevenueByClientVM = new RevenueByClientVM();
            dashboardVM.ConsultantByClientVM.ClientByMonthList = new List<ClientConsultantsByMonth>();
            dashboardVM.RevenueByRecruiterVM.RecruiterByProfitList = new List<RecruiterProfitByMonth>();
            dashboardVM.RevenueByClientVM.ClientByProfitList = new List<ClientProfitByMonth>();

            IQueryable<MonthData> timesheets = _unitOfWork.MonthData.GetAllIncluding(t => t.TimeSheet, t => t.TimeSheet.Consultant, t => t.TimeSheet.Consultant.Client);
            var active = timesheets.Where(x => x.Hours != null && x.Hours != 0).Where(y=>y.TimeSheet.Year == 2023).ToList();

            var results = active.GroupBy(n => new { n.TimeSheet.Consultant.Client, n.MonthInt})
                .Select(g => new ClientConsultantsByMonth {
                    Client = g.Key.Client,
                     Month =  g.Key.MonthInt,
                   ActiveConsultants = g.Count() });

            dashboardVM.ConsultantByClientVM.ClientByMonthList = results.ToList();

            ///Calculate Profit by Recruiter for each month
            var recruiterMonthlyData = _unitOfWork.MonthData
                .GetAllIncluding(t => t.TimeSheet,
                t => t.TimeSheet.Consultant.Recruiter)
                .Where(x => x.Hours != null && x.Hours != 0).ToList();

            var recruiterResults = recruiterMonthlyData.GroupBy(n => new { n.TimeSheet.Consultant.Recruiter, n.MonthInt })
                .Select(g => new RecruiterProfitByMonth
                {
                    Recruiter = g.Key.Recruiter,
                    Month = g.Key.MonthInt,
                    NetProfitByRecruiter = g.Sum(x => x.NetProfit)
                });


            dashboardVM.RevenueByRecruiterVM.RecruiterByProfitList = recruiterResults.ToList();

            ///Calculate Profit by Client for each month
            var clientMonthlyData = _unitOfWork.MonthData
                .GetAllIncluding(t => t.TimeSheet,
                t => t.TimeSheet.Consultant.Client)
                .Where(x => x.Hours != null && x.Hours != 0).ToList();

            var clientResults = clientMonthlyData.GroupBy(n => new { n.TimeSheet.Consultant.Client, n.MonthInt })
                .Select(g => new ClientProfitByMonth
                {
                    Client = g.Key.Client,
                    Month = g.Key.MonthInt,
                    NetProfitByClient = g.Sum(x => x.NetProfit)
                });


            dashboardVM.RevenueByClientVM.ClientByProfitList = clientResults.ToList();

            return View(dashboardVM);
        }
    }
}
