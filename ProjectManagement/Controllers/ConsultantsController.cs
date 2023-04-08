using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using ProjectManagement.Data.UnitOfWorks;
using ProjectManagement.Models;

namespace ProjectManagement.Controllers
{
    public class ConsultantsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConsultantsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Consultants
        public async Task<IActionResult> Index(string searchKey = null)
        {
            string url = string.Empty;
            IEnumerable<Consultant> applicationDbContext = null ;
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                applicationDbContext = _unitOfWork.Consultants.GetAllIncluding(t => t.Client).Where(x => x.Name.ToLower().Contains(searchKey.ToLower()) || x.Client.ClientName.ToLower().Contains(searchKey.ToLower()));
            }
            else
            {
                applicationDbContext = _unitOfWork.Consultants.GetAllIncluding(t => t.Client);
            }
            
            return View(applicationDbContext.ToList());
        }

        // GET: Consultants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _unitOfWork.Consultants == null)
            {
                return NotFound();
            }

            var consultant = await _unitOfWork.Consultants.GetAllIncluding(
                c => c.MarketingManager,
                c => c.PlacedBy,
                c => c.Recruiter,
                c => c.ReferredBy,
                c => c.TeamLead,
                c => c.TeamMember,
                c => c.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultant == null)
            {
                return NotFound();
            }

            ViewData["MarketingManagerMemberId"] = new SelectList(_unitOfWork.TeamMembers.GetAll().ToList(), "Id", "Name", consultant.MarketingManagerMemberId);
            ViewData["PlacedByMemberId"] = new SelectList(_unitOfWork.TeamMembers.GetAll().ToList(), "Id", "Name", consultant.PlacedByMemberId);
            ViewData["RecruiterMemberId"] = new SelectList(_unitOfWork.TeamMembers.GetAll().ToList(), "Id", "Name", consultant.RecruiterMemberId);
            ViewData["ReferredByMemberId"] = new SelectList(_unitOfWork.TeamMembers.GetAll().ToList(), "Id", "Name", consultant.ReferredByMemberId);
            ViewData["TeamLeadMemberId"] = new SelectList(_unitOfWork.TeamMembers.GetAll().ToList(), "Id", "Name", consultant.TeamLeadMemberId);
            ViewData["TeamMemberId"] = new SelectList(_unitOfWork.TeamMembers.GetAll().ToList(), "Id", "Name", consultant.TeamMemberId);
            ViewData["ClientId"] = new SelectList(_unitOfWork.Clients.GetAll().ToList(), "Id", "ClientName", consultant.ClientId);

            return View(consultant);
        }

        // GET: Consultants/Create
        public IActionResult Create()
        {
            var selectListItems = new SelectList(_unitOfWork.TeamMembers.GetAll().ToList(), "Id", "Name");
            ViewData["MarketingManagerMemberId"] = selectListItems;
            ViewData["PlacedByMemberId"] = selectListItems;
            ViewData["RecruiterMemberId"] = selectListItems;
            ViewData["ReferredByMemberId"] = selectListItems;
            ViewData["TeamLeadMemberId"] = selectListItems;
            ViewData["TeamMemberId"] = selectListItems;
            ViewData["ClientId"] = new SelectList(_unitOfWork.Clients.GetAll().ToList(), "Id", "ClientName");
            return View();
        }

        // POST: Consultants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,RecruiterMemberId,TeamLeadMemberId,MarketingManagerMemberId,TeamMemberId,ReferredByMemberId,PlacedByMemberId,StartDate,EndDate,BillingRate,PayRate,TeamLeadFee,MarketingFee,ReferralFees,PlacementFee,CreditCardCost,NetMargin,UniqueConsultantId,ClientId")] Consultant consultant)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Consultants.Add(consultant);
                await _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarketingManagerMemberId"] = new SelectList(_unitOfWork.TeamMembers.GetAll().ToList(), "Id", "Name", consultant.MarketingManagerMemberId);
            ViewData["PlacedByMemberId"] = new SelectList(_unitOfWork.TeamMembers.GetAll().ToList(), "Id", "Name", consultant.PlacedByMemberId);
            ViewData["RecruiterMemberId"] = new SelectList(_unitOfWork.TeamMembers.GetAll().ToList(), "Id", "Name", consultant.RecruiterMemberId);
            ViewData["ReferredByMemberId"] = new SelectList(_unitOfWork.TeamMembers.GetAll().ToList(), "Id", "Name", consultant.ReferredByMemberId);
            ViewData["TeamLeadMemberId"] = new SelectList(_unitOfWork.TeamMembers.GetAll().ToList(), "Id", "Name", consultant.TeamLeadMemberId);
            ViewData["TeamMemberId"] = new SelectList(_unitOfWork.TeamMembers.GetAll().ToList(), "Id", "Name", consultant.TeamMemberId);
            ViewData["ClientId"] = new SelectList(_unitOfWork.Clients.GetAll().ToList(), "Id", "ClientName", consultant.ClientId);
            return View(consultant);
        }

        // GET: Consultants/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _unitOfWork.Consultants == null)
            {
                return NotFound();
            }

            var consultant = await _unitOfWork.Consultants.FindAsync(id);
            if (consultant == null)
            {
                return NotFound();
            }
            ViewData["MarketingManagerMemberId"] = new SelectList(_unitOfWork.TeamMembers.GetAll().ToList(), "Id", "Name", consultant.MarketingManagerMemberId);
            ViewData["PlacedByMemberId"] = new SelectList(_unitOfWork.TeamMembers.GetAll().ToList(), "Id", "Name", consultant.PlacedByMemberId);
            ViewData["RecruiterMemberId"] = new SelectList(_unitOfWork.TeamMembers.GetAll().ToList(), "Id", "Name", consultant.RecruiterMemberId);
            ViewData["ReferredByMemberId"] = new SelectList(_unitOfWork.TeamMembers.GetAll().ToList(), "Id", "Name", consultant.ReferredByMemberId);
            ViewData["TeamLeadMemberId"] = new SelectList(_unitOfWork.TeamMembers.GetAll().ToList(), "Id", "Name", consultant.TeamLeadMemberId);
            ViewData["TeamMemberId"] = new SelectList(_unitOfWork.TeamMembers.GetAll().ToList(), "Id", "Name", consultant.TeamMemberId);
            ViewData["ClientId"] = new SelectList(_unitOfWork.Clients.GetAll().ToList(), "Id", "ClientName", consultant.ClientId);
            return View(consultant);
        }

        // POST: Consultants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,RecruiterMemberId,TeamLeadMemberId,MarketingManagerMemberId,TeamMemberId,ReferredByMemberId,PlacedByMemberId,StartDate,EndDate,BillingRate,PayRate,TeamLeadFee,MarketingFee,ReferralFees,PlacementFee,CreditCardCost,NetMargin,UniqueConsultantId,ClientId")] Consultant consultant)
        {
            if (id != consultant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Consultants.Update(consultant);
                    await _unitOfWork.Complete();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultantExists(consultant.Id))
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
            ViewData["MarketingManagerMemberId"] = new SelectList(_unitOfWork.TeamMembers.GetAll().ToList(), "Id", "Name", consultant.MarketingManagerMemberId);
            ViewData["PlacedByMemberId"] = new SelectList(_unitOfWork.TeamMembers.GetAll().ToList(), "Id", "Name", consultant.PlacedByMemberId);
            ViewData["RecruiterMemberId"] = new SelectList(_unitOfWork.TeamMembers.GetAll().ToList(), "Id", "Name", consultant.RecruiterMemberId);
            ViewData["ReferredByMemberId"] = new SelectList(_unitOfWork.TeamMembers.GetAll().ToList(), "Id", "Name", consultant.ReferredByMemberId);
            ViewData["TeamLeadMemberId"] = new SelectList(_unitOfWork.TeamMembers.GetAll().ToList(), "Id", "Name", consultant.TeamLeadMemberId);
            ViewData["TeamMemberId"] = new SelectList(_unitOfWork.TeamMembers.GetAll().ToList(), "Id", "Name", consultant.TeamMemberId);
            ViewData["ClientId"] = new SelectList(_unitOfWork.Clients.GetAll().ToList(), "Id", "ClientName", consultant.ClientId);
            return View(consultant);
        }

        // GET: Consultants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _unitOfWork.Consultants == null)
            {
                return NotFound();
            }

            var consultant = await _unitOfWork.Consultants.GetAllIncluding(
                c => c.MarketingManager,
                c => c.PlacedBy,
                c => c.Recruiter,
                c => c.ReferredBy,
                c => c.TeamLead,
                c => c.TeamMember,
                c => c.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultant == null)
            {
                return NotFound();
            }

            return View(consultant);
        }

        // POST: Consultants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_unitOfWork.Consultants == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Consultants'  is null.");
            }
            var consultant = await _unitOfWork.Consultants.FindAsync(id);
            if (consultant != null)
            {
                _unitOfWork.Consultants.Remove(consultant);
            }

            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultantExists(int id)
        {
            return (_unitOfWork.Consultants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
