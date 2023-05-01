using CsvHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;
using ProjectManagement.Data.UnitOfWorks;
using ProjectManagement.Models;
using ProjectManagement.Models.Utilities;
using System.Data;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Globalization;

namespace ProjectManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult LoadData()

        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> LoadTeamMembersFromFile(IFormFile file)
        {
            try
            {
                var fileextension = Path.GetExtension(file.FileName);

                if (fileextension == ".csv")
                {
                    List<TeamMember> membersFromFile = new List<TeamMember>();
                    using (var reader = new StreamReader(file.OpenReadStream()))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {

                        csv.Read();
                        csv.ReadHeader();
                        while (csv.Read())
                        {
                            var record = new TeamMember
                            {
                                Name = csv.GetField("Name"),
                                IsActive = true
                            };
                            membersFromFile.Add(record);
                        }

                    }
                    _unitOfWork.TeamMembers.AddRange(membersFromFile);
                    await _unitOfWork.Complete();

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return View("LoadData");
        }

        [HttpPost]
        public async Task<IActionResult> LoadClientsFromFile(IFormFile file)
        {
            try
            {
                var fileextension = Path.GetExtension(file.FileName);

                if (fileextension == ".csv")
                {
                    List<Client> clientsFromFile = new List<Client>();
                    using (var reader = new StreamReader(file.OpenReadStream()))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {

                        csv.Read();
                        csv.ReadHeader();
                        while (csv.Read())
                        {
                            var record = new Client
                            {
                                ClientName = csv.GetField("ClientName"),
                                IsActive = true
                            };
                            clientsFromFile.Add(record);
                        }

                    }
                    _unitOfWork.Clients.AddRange(clientsFromFile);
                    await _unitOfWork.Complete();

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return View("LoadData");
        }

        [HttpPost]
        public async Task<IActionResult> LoadConsultantFromFile(IFormFile file)
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
                        csv.Context.TypeConverterOptionsCache.GetOptions<DateTime>().NullValues.AddRange(new[] { "NULL", "0" });
                        csv.Context.TypeConverterOptionsCache.GetOptions<decimal?>().NullValues.Add("0");

                        var records = csv.GetRecords<ConsultantCsv>();
                        foreach (var record in records)
                        {
                            bool isExisting = true;
                            Consultant consultant = _unitOfWork.Consultants.GetAll().Where(x => x.UniqueConsultantId == record.UniqueConsultantId).FirstOrDefault();
                            if (consultant == null)
                            {
                                consultant = new Consultant();
                                isExisting = false;
                            }
                            consultant.Name = record.Name;
                            consultant.CompanyId = record.CompanyId;
                            consultant.UniqueConsultantId = record.UniqueConsultantId;
                            consultant.RecruiterMemberId = record.RecruiterMemberId;
                            consultant.TeamMemberId = record.TeamMemberId;
                            consultant.ClientId = record.ClientId;
                            consultant.StartDate = record.StartDate;
                            consultant.EndDate = record.EndDate;
                            consultant.BillingRate = record.BillingRate;
                            consultant.PayRate = record.PayRate;
                            consultant.TeamLeadFee = record.TeamLeadFee;
                            consultant.TeamLeadMemberId = record.TeamLeadMemberId;
                            consultant.MarketingFee = record.MarketingFee;
                            consultant.MarketingManagerMemberId = record.MarketingManagerMemberId;
                            consultant.ReferralFees = record.ReferralFees;
                            consultant.ReferredByMemberId = record.ReferredByMemberId;
                            consultant.PlacementFee = record.PlacementFee;
                            consultant.PlacedByMemberId = record.PlacedByMemberId;
                            consultant.CreditCardCost = record.CreditCardCost;
                            consultant.NetMargin = record.NetMargin;

                            if (isExisting)
                            {
                                existingConsultants.Add(consultant);
                            }
                            else
                            {
                                newConsultants.Add(consultant);
                            }

                        }
                    }
                    _unitOfWork.Consultants.AddRange(newConsultants);
                    _unitOfWork.Consultants.UpdateRange(existingConsultants);
                    await _unitOfWork.Complete();
                }
                else
                {
                    ViewData["ConsultantsUploadError"] = "Please select a file with .csv extension";
                }

            }
            catch (Exception e)
            {
                ViewData["ConsultantsUploadError"] = e.Message;    
            }
            return View("LoadData");
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}