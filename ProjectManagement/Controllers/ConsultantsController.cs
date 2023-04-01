using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using ProjectManagement.Models;

namespace ProjectManagement.Controllers
{
    public class ConsultantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsultantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Consultants
        public async Task<IActionResult> Index(string searchKey = null)
        {
            string url = string.Empty;
            IQueryable<Consultant> applicationDbContext = null ;
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                applicationDbContext = _context.Consultants.Include(t=>t.Client).Where(x => x.Name.ToLower().Contains(searchKey.ToLower()) || x.Client.ClientName.ToLower().Contains(searchKey.ToLower()));
            }
            else
            {
                applicationDbContext = _context.Consultants.Include(t => t.Client);
            }
            
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Consultants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Consultants == null)
            {
                return NotFound();
            }

            var consultant = await _context.Consultants
                .Include(c => c.MarketingManager)
                .Include(c => c.PlacedBy)
                .Include(c => c.Recruiter)
                .Include(c => c.ReferredBy)
                .Include(c => c.TeamLead)
                .Include(c => c.TeamMember)
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultant == null)
            {
                return NotFound();
            }

            return View(consultant);
        }

        // GET: Consultants/Create
        public IActionResult Create()
        {
            var selectListItems = new SelectList(_context.TeamMembers, "Id", "Name");
            ViewData["MarketingManagerMemberId"] = selectListItems;
            ViewData["PlacedByMemberId"] = selectListItems;
            ViewData["RecruiterMemberId"] = selectListItems;
            ViewData["ReferredByMemberId"] = selectListItems;
            ViewData["TeamLeadMemberId"] = selectListItems;
            ViewData["TeamMemberId"] = selectListItems;
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "ClientName");
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
                _context.Add(consultant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarketingManagerMemberId"] = new SelectList(_context.TeamMembers, "Id", "Name", consultant.MarketingManagerMemberId);
            ViewData["PlacedByMemberId"] = new SelectList(_context.TeamMembers, "Id", "Name", consultant.PlacedByMemberId);
            ViewData["RecruiterMemberId"] = new SelectList(_context.TeamMembers, "Id", "Name", consultant.RecruiterMemberId);
            ViewData["ReferredByMemberId"] = new SelectList(_context.TeamMembers, "Id", "Name", consultant.ReferredByMemberId);
            ViewData["TeamLeadMemberId"] = new SelectList(_context.TeamMembers, "Id", "Name", consultant.TeamLeadMemberId);
            ViewData["TeamMemberId"] = new SelectList(_context.TeamMembers, "Id", "Name", consultant.TeamMemberId);
            ViewData["ClientId"] = new SelectList(_context.TeamMembers, "Id", "ClientName", consultant.ClientId);
            return View(consultant);
        }

        // GET: Consultants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Consultants == null)
            {
                return NotFound();
            }

            var consultant = await _context.Consultants.FindAsync(id);
            if (consultant == null)
            {
                return NotFound();
            }
            ViewData["MarketingManagerMemberId"] = new SelectList(_context.TeamMembers, "Id", "Name", consultant.MarketingManagerMemberId);
            ViewData["PlacedByMemberId"] = new SelectList(_context.TeamMembers, "Id", "Name", consultant.PlacedByMemberId);
            ViewData["RecruiterMemberId"] = new SelectList(_context.TeamMembers, "Id", "Name", consultant.RecruiterMemberId);
            ViewData["ReferredByMemberId"] = new SelectList(_context.TeamMembers, "Id", "Name", consultant.ReferredByMemberId);
            ViewData["TeamLeadMemberId"] = new SelectList(_context.TeamMembers, "Id", "Name", consultant.TeamLeadMemberId);
            ViewData["TeamMemberId"] = new SelectList(_context.TeamMembers, "Id", "Name", consultant.TeamMemberId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "ClientName", consultant.ClientId);
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
                    _context.Update(consultant);
                    await _context.SaveChangesAsync();
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
            ViewData["MarketingManagerMemberId"] = new SelectList(_context.TeamMembers, "Id", "Name", consultant.MarketingManagerMemberId);
            ViewData["PlacedByMemberId"] = new SelectList(_context.TeamMembers, "Id", "Name", consultant.PlacedByMemberId);
            ViewData["RecruiterMemberId"] = new SelectList(_context.TeamMembers, "Id", "Name", consultant.RecruiterMemberId);
            ViewData["ReferredByMemberId"] = new SelectList(_context.TeamMembers, "Id", "Name", consultant.ReferredByMemberId);
            ViewData["TeamLeadMemberId"] = new SelectList(_context.TeamMembers, "Id", "Name", consultant.TeamLeadMemberId);
            ViewData["TeamMemberId"] = new SelectList(_context.TeamMembers, "Id", "Name", consultant.TeamMemberId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "ClientName", consultant.ClientId);
            return View(consultant);
        }

        // GET: Consultants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Consultants == null)
            {
                return NotFound();
            }

            var consultant = await _context.Consultants
                .Include(c => c.MarketingManager)
                .Include(c => c.PlacedBy)
                .Include(c => c.Recruiter)
                .Include(c => c.ReferredBy)
                .Include(c => c.TeamLead)
                .Include(c => c.TeamMember)
                .Include(c => c.Client)
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
            if (_context.Consultants == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Consultants'  is null.");
            }
            var consultant = await _context.Consultants.FindAsync(id);
            if (consultant != null)
            {
                _context.Consultants.Remove(consultant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultantExists(int id)
        {
          return (_context.Consultants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
