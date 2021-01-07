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
    public class RecipeTagsController : Controller
    {
        private readonly RecipeBookContext _context;

        public RecipeTagsController(RecipeBookContext context)
        {
            _context = context;
        }

        // GET: RecipeTags/Create
        [HttpGet("{recipeId}/RecipeTags/Create", Name = "recipetagcreate")]
        public async Task<IActionResult> Create(int? recipeId)
        {
            if (recipeId == null || !RecipeExists(recipeId.Value))
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FirstOrDefaultAsync(i => i.Id == recipeId);
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Name");
            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Name");

            var recipeItem = new RecipeTag
            {
                Recipe = recipe
            };

            return View(recipeItem);
        }


        // POST: RecipeTags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateAntiForgeryToken]
        [HttpPost("{recipeId}/RecipeTags/Create", Name = "recipetagcreate")]
        public async Task<IActionResult> Create(int? recipeId, [Bind("RecipeId,TagId")] RecipeTag recipeTag)
        {
            if (recipeId == null || !RecipeExists(recipeId.Value))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                recipeTag.RecipeId = recipeId.Value;
                _context.Add(recipeTag);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Recipes", new { id = recipeId });
            }
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Name", recipeTag.RecipeId);
            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Name", recipeTag.TagId);
            return View(recipeTag);
        }

        // GET: RecipeTags/Delete/5
        [HttpGet("{recipeId}/RecipeTags/Delete/{id}", Name = "recipetagdelete")]
        public async Task<IActionResult> Delete(int? recipeId, int? id)
        {
            if (id == null || recipeId == null)
            {
                return NotFound();
            }

            var recipeTag = await _context.RecipeTags
                .Include(m => m.Recipe)
                .Include(m => m.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipeTag == null)
            {
                return NotFound();
            }

            return View(recipeTag);
        }

        // POST: RecipeTags/Delete/5
        [HttpPost("{recipeId}/RecipeTags/Delete/{id}", Name = "recipetagdelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int recipeId, int id)
        {
            var recipeTag = await _context.RecipeTags.FindAsync(id);
            _context.RecipeTags.Remove(recipeTag);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Recipes", new { id = recipeId });
        }

        private bool RecipeExists(int recipeId)
        {
            return _context.Recipes.Any(e => e.Id == recipeId);
        }
    }
}
