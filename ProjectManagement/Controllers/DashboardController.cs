using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            int currentYear = DateTime.Now.Year;
            DashboardVM dashboardVM = new DashboardVM();


            dashboardVM.ConsultantByClientVM = new ConsultantByClientVM();
            dashboardVM.RevenueByRecruiterVM = new RevenueByRecruiterVM();
            dashboardVM.RevenueByClientVM = new RevenueByClientVM();
            dashboardVM.ConsultantByClientVM.ClientByConsultantList = new List<ClientConsultantsByMonth>();
            dashboardVM.RevenueByRecruiterVM.RecruiterByProfitList = new List<RecruiterProfitByMonth>();
            dashboardVM.RevenueByClientVM.ClientByProfitList = new List<ClientProfitByMonth>();

            dashboardVM.ConsultantByClientVM = GetConsultantByClientVM(currentYear);
            dashboardVM.RevenueByRecruiterVM = GetRevenueByRecruiterVM(currentYear);
            dashboardVM.RevenueByClientVM = RevenueByClientVM(currentYear);

            ViewData["Year"] = new SelectList(Constants.YearDropdown, currentYear);

            return View(dashboardVM);
        }

        public IActionResult ConsultantByClientPartial(int year)
        {
            ViewData["Year"] = new SelectList(Constants.YearDropdown, year);
            return PartialView("_ConsultantByClient", GetConsultantByClientVM(year));
        }

        #region Private Methods
        private ConsultantByClientVM GetConsultantByClientVM(int year)
        {
            ConsultantByClientVM consultantByClientVM = new ConsultantByClientVM();
            IQueryable<MonthData> timesheets = _unitOfWork.MonthData.GetAllIncluding(t => t.TimeSheet, t => t.TimeSheet.Consultant, t => t.TimeSheet.Consultant.Client);
            var active = timesheets.Where(x => x.Hours != null && x.Hours != 0).Where(y => y.TimeSheet.Year == year).ToList();

            var results = active.GroupBy(n => new { n.TimeSheet.Consultant.Client, n.MonthInt })
                .Select(g => new ClientConsultantsByMonth
                {
                    Client = g.Key.Client,
                    Month = g.Key.MonthInt,
                    ActiveConsultants = g.Count()
                });
            consultantByClientVM.ClientByConsultantList = results.ToList();
            return consultantByClientVM;
        }

        private RevenueByRecruiterVM GetRevenueByRecruiterVM(int year)
        {
            RevenueByRecruiterVM revenueByRecruiterVM = new RevenueByRecruiterVM();
            ///Calculate Profit by Recruiter for each month
            var recruiterMonthlyData = _unitOfWork.MonthData
                .GetAllIncluding(t => t.TimeSheet,
                t => t.TimeSheet.Consultant.Recruiter)
                .Where(x => x.Hours != null && x.Hours != 0).Where(y => y.TimeSheet.Year == year).ToList();

            var recruiterResults = recruiterMonthlyData.GroupBy(n => new { n.TimeSheet.Consultant.Recruiter, n.MonthInt })
                .Select(g => new RecruiterProfitByMonth
                {
                    Recruiter = g.Key.Recruiter,
                    Month = g.Key.MonthInt,
                    NetProfitByRecruiter = g.Sum(x => x.NetProfit)
                });
            revenueByRecruiterVM.RecruiterByProfitList = recruiterResults.ToList();
            return revenueByRecruiterVM;
        }

        private RevenueByClientVM RevenueByClientVM(int year)
        {
            RevenueByClientVM revenueByClientVM = new RevenueByClientVM();
            ///Calculate Profit by Client for each month
            var clientMonthlyData = _unitOfWork.MonthData
                .GetAllIncluding(t => t.TimeSheet,
                t => t.TimeSheet.Consultant.Client)
                .Where(x => x.Hours != null && x.Hours != 0).Where(y => y.TimeSheet.Year == year).ToList();

            var clientResults = clientMonthlyData.GroupBy(n => new { n.TimeSheet.Consultant.Client, n.MonthInt })
                .Select(g => new ClientProfitByMonth
                {
                    Client = g.Key.Client,
                    Month = g.Key.MonthInt,
                    NetProfitByClient = g.Sum(x => x.NetProfit)
                });
            revenueByClientVM.ClientByProfitList = clientResults.ToList();
            return revenueByClientVM;
        } 
        #endregion


    }
}
