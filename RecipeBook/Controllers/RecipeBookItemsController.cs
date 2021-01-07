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
    [Route("RecipeBooks")]
    public class RecipeBookItemsController : Controller
    {
        private readonly RecipeBookContext _context;

        public RecipeBookItemsController(RecipeBookContext context)
        {
            _context = context;
        }

        // GET: RecipeBookItems/Create
        [HttpGet("{recipeBookId}/RecipeBookItems/Create", Name = "recipebookitemcreate")]
        public async Task<IActionResult> Create(int? recipeBookId)
        {
            if (recipeBookId == null)
            {
                return NotFound();
            }

            var recipeBook = await _context.RecipeBooks.FirstOrDefaultAsync(i => i.Id == recipeBookId);
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Name");
            ViewData["RecipeBookId"] = new SelectList(_context.RecipeBooks, "Id", "Name");

            var recipebookItem = new RecipeBookItem
            {
                RecipeBook = recipeBook
            };

            return View(recipebookItem);
        }

        // POST: RecipeBookItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateAntiForgeryToken]
        [HttpPost("{recipeBookId}/RecipeBookItems/Create", Name = "recipebookitemcreate")]
        public async Task<IActionResult> Create(int? recipeBookId, [Bind("RecipeId")] RecipeBookItem recipebookItem)
        {
            if (recipeBookId == null || !RecipeBookExists(recipeBookId.Value))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                recipebookItem.RecipeBookId = recipeBookId.Value;
                _context.Add(recipebookItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "RecipeBooks", new { id = recipeBookId });
            }
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Name", recipebookItem.RecipeId);
            ViewData["RecipeBookId"] = new SelectList(_context.RecipeBooks, "Id", "Name", recipebookItem.RecipeBookId);
            return View(recipebookItem);
        }

        // GET: RecipeBookItems/Edit/5
        [HttpGet("{recipeBookId}/RecipeBookItems/Edit/{id}", Name = "recipebookitemedit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipebookItem = await _context.RecipeBookItems.Include(i => i.RecipeBook).FirstOrDefaultAsync(i => i.Id == id);
            if (recipebookItem == null)
            {
                return NotFound();
            }
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Name", recipebookItem.RecipeId);
            ViewData["RecipeBookId"] = new SelectList(_context.RecipeBooks, "Id", "Name", recipebookItem.RecipeBookId);
            return View(recipebookItem);
        }

        // POST: RecipeBookItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateAntiForgeryToken]
        [HttpPost("{recipeBookId}/RecipeBookItems/Edit/{id}", Name = "recipebookitemedit")]
        public async Task<IActionResult> Edit(int recipeBookId, int id, [Bind("RecipeBookId,RecipeId,Id")] RecipeBookItem recipebookItem)
        {
            if (id != recipebookItem.Id || recipeBookId != recipebookItem.RecipeBookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipebookItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeBookItemExists(recipebookItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "RecipeBooks", new { id = recipeBookId });
            }
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Name", recipebookItem.RecipeId);
            ViewData["RecipeBookId"] = new SelectList(_context.RecipeBooks, "Id", "Name", recipebookItem.RecipeBookId);
            return View(recipebookItem);
        }

        // GET: RecipeBookItems/Delete/5
        [HttpGet("{recipeBookId}/RecipeBookItems/Delete/{id}", Name = "recipebookitemdelete")]
        public async Task<IActionResult> Delete(int? recipeBookId, int? id)
        {
            if (id == null || recipeBookId == null)
            {
                return NotFound();
            }

            var recipebookItem = await _context.RecipeBookItems
                .Include(m => m.Recipe)
                .Include(m => m.RecipeBook)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipebookItem == null)
            {
                return NotFound();
            }

            return View(recipebookItem);
        }

        // POST: RecipeBookItems/Delete/5
        [HttpPost("{recipeBookId}/RecipeBookItems/Delete/{id}", Name = "recipebookitemdelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int recipeBookId, int id)
        {
            var recipebookItem = await _context.RecipeBookItems.FindAsync(id);
            _context.RecipeBookItems.Remove(recipebookItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "RecipeBooks", new { id = recipeBookId });
        }

        private bool RecipeBookItemExists(int id)
        {
            return _context.RecipeBookItems.Any(e => e.Id == id);
        }

        private bool RecipeBookExists(int recipeBookId)
        {
            return _context.RecipeBooks.Any(e => e.Id == recipeBookId);
        }
    }
}
