using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudOperation.Data;
using CrudOperation.Models;

namespace CrudOperation.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            var students = await _context.Students
                .Include(s => s.Department)
                .ToListAsync();
            return View(students);
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Students == null)
                return NotFound();

            var student = await _context.Students
                .Include(s => s.Department)  // ✅ Fixed
                .FirstOrDefaultAsync(m => m.StudentId == id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // GET: Student/Create
        public async Task<IActionResult> Create()
        {
            var departments = await _context.Departments.ToListAsync();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "Name");
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,Name,Email,Course,EndrollementDate,DepartmentId")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var departments = await _context.Departments.ToListAsync();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "Name", student.DepartmentId);
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Students == null)
                return NotFound();

            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            // ✅ Fixed - pass departments to view
            var departments = await _context.Departments.ToListAsync();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "Name", student.DepartmentId);

            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,Name,Email,Course,EndrollementDate,DepartmentId")] Student student) // ✅ Fixed
        {
            if (id != student.StudentId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            var departments = await _context.Departments.ToListAsync();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "Name", student.DepartmentId);
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Students == null)
                return NotFound();

            var student = await _context.Students
                .Include(s => s.Department)  // ✅ Good practice
                .FirstOrDefaultAsync(m => m.StudentId == id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Students == null)
                return Problem("Entity set 'ApplicationDbContext.Students' is null.");

            var student = await _context.Students.FindAsync(id);
            if (student != null)
                _context.Students.Remove(student);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return (_context.Students?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
