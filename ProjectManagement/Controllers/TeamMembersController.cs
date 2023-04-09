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
    public class TeamMembersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamMembersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: TeamMembers
        public async Task<IActionResult> Index()
        {
              return _unitOfWork.TeamMembers != null ? 
                          View(await _unitOfWork.TeamMembers.GetAllAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TeamMembers'  is null.");
        }

        // GET: TeamMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _unitOfWork.TeamMembers == null)
            {
                return NotFound();
            }

            var teamMember = await _unitOfWork.TeamMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teamMember == null)
            {
                return NotFound();
            }

            return View(teamMember);
        }

        // GET: TeamMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeamMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IsActive")] TeamMember teamMember)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TeamMembers.Add(teamMember);
                await _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(teamMember);
        }

        // GET: TeamMembers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _unitOfWork.TeamMembers == null)
            {
                return NotFound();
            }

            var teamMember = await _unitOfWork.TeamMembers.FindAsync(id);
            if (teamMember == null)
            {
                return NotFound();
            }
            return View(teamMember);
        }

        // POST: TeamMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,IsActive")] TeamMember teamMember)
        {
            if (id != teamMember.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.TeamMembers.Update(teamMember);
                    await _unitOfWork.Complete();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamMemberExists(teamMember.Id))
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
            return View(teamMember);
        }

        // GET: TeamMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _unitOfWork.TeamMembers == null)
            {
                return NotFound();
            }

            var teamMember = await _unitOfWork.TeamMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teamMember == null)
            {
                return NotFound();
            }

            return View(teamMember);
        }

        // POST: TeamMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_unitOfWork.TeamMembers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TeamMembers'  is null.");
            }
            var teamMember = await _unitOfWork.TeamMembers.FindAsync(id);
            if (teamMember != null)
            {
                _unitOfWork.TeamMembers.Remove(teamMember);
            }
            
            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamMemberExists(int id)
        {
          return (_unitOfWork.TeamMembers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
