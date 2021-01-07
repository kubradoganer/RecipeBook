using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Context;
using DataAccess.Entities;

namespace RecipeBook.Controllers
{
    public class RecipeBooksController : Controller
    {
        private readonly RecipeBookContext _context;

        public RecipeBooksController(RecipeBookContext context)
        {
            _context = context;
        }

        // GET: RecipeBooks
        public async Task<IActionResult> Index()
        {
            var recipeBookContext = _context.RecipeBooks.Include(r => r.User).Include(r => r.RecipeBookItems);
            return View(await recipeBookContext.ToListAsync());
        }

        // GET: RecipeBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeBook = await _context.RecipeBooks
                .Include(r => r.User)
                .Include(r => r.RecipeBookItems)
                .ThenInclude(rb => rb.Recipe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipeBook == null)
            {
                return NotFound();
            }

            return View(recipeBook);
        }

        // GET: RecipeBooks/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName");
            return View();
        }

        // POST: RecipeBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,UserId,Id,CreateDate,UpdateDate")] DataAccess.Entities.RecipeBook recipeBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipeBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", recipeBook.UserId);
            return View(recipeBook);
        }

        // GET: RecipeBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeBook = await _context.RecipeBooks.FindAsync(id);
            if (recipeBook == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", recipeBook.UserId);
            return View(recipeBook);
        }

        // POST: RecipeBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,UserId,Id,CreateDate,UpdateDate")] DataAccess.Entities.RecipeBook recipeBook)
        {
            if (id != recipeBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipeBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeBookExists(recipeBook.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", recipeBook.UserId);
            return View(recipeBook);
        }

        // GET: RecipeBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeBook = await _context.RecipeBooks
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipeBook == null)
            {
                return NotFound();
            }

            return View(recipeBook);
        }

        // POST: RecipeBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipeBook = await _context.RecipeBooks.FindAsync(id);
            _context.RecipeBooks.Remove(recipeBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeBookExists(int id)
        {
            return _context.RecipeBooks.Any(e => e.Id == id);
        }
    }
}
