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
    [Route("Recipes")]
    public class RecipeIngredientsController : Controller
    {
        private readonly RecipeBookContext _context;

        public RecipeIngredientsController(RecipeBookContext context)
        {
            _context = context;
        }

        // GET: RecipeIngredients/Create
        [HttpGet("{recipeId}/RecipeIngredients/Create", Name = "recipeingredientcreate")]
        public async Task<IActionResult> Create(int? recipeId)
        {
            if (recipeId == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FirstOrDefaultAsync(i => i.Id == recipeId);
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Name");
            ViewData["IngredientTypeId"] = new SelectList(_context.IngredientTypes, "Id", "Name");
            ViewData["MeasurementTypeId"] = new SelectList(_context.MeasurementTypes, "Id", "Name");

            var recipeIngredient = new RecipeIngredient
            {
                Recipe = recipe
            };

            return View(recipeIngredient);
        }

        // POST: RecipeIngredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateAntiForgeryToken]
        [HttpPost("{recipeId}/RecipeIngredients/Create", Name = "recipeingredientcreate")]
        public async Task<IActionResult> Create(int? recipeId, [Bind("IngredientTypeId,MeasurementTypeId,Amount")] RecipeIngredient recipeIngredient)
        {
            if (recipeId == null || !RecipeExists(recipeId.Value))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                recipeIngredient.RecipeId = recipeId.Value;
                _context.Add(recipeIngredient);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Recipes", new { id = recipeId });
            }

            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Name", recipeIngredient.RecipeId);
            ViewData["IngredientTypeId"] = new SelectList(_context.IngredientTypes, "Id", "Name", recipeIngredient.IngredientTypeId);
            ViewData["MeasurementTypeId"] = new SelectList(_context.MeasurementTypes, "Id", "Name", recipeIngredient.MeasurementTypeId);
            return View(recipeIngredient);
        }

        // GET: RecipeIngredients/Edit/5
        [HttpGet("{recipeId}/RecipeIngredients/Edit/{id}", Name = "recipeingredientedit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeIngredient = await _context.RecipeIngredients.Include(i => i.Recipe).FirstOrDefaultAsync(i => i.Id == id);
            if (recipeIngredient == null)
            {
                return NotFound();
            }
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Name", recipeIngredient.RecipeId);
            ViewData["IngredientTypeId"] = new SelectList(_context.IngredientTypes, "Id", "Name", recipeIngredient.IngredientTypeId);
            ViewData["MeasurementTypeId"] = new SelectList(_context.MeasurementTypes, "Id", "Name", recipeIngredient.MeasurementTypeId);
            return View(recipeIngredient);
        }

        // POST: RecipeIngredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateAntiForgeryToken]
        [HttpPost("{recipeId}/RecipeIngredients/Edit/{id}", Name = "recipeingredientedit")]
        public async Task<IActionResult> Edit(int recipeId, int id, [Bind("IngredientTypeId,MeasurementTypeId,RecipeId,Amount,Id")] RecipeIngredient recipeIngredient)
        {
            if (id != recipeIngredient.Id || recipeId != recipeIngredient.RecipeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipeIngredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeIngredientExists(recipeIngredient.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Recipes", new { id = recipeId });
            }
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Name", recipeIngredient.RecipeId);
            ViewData["IngredientTypeId"] = new SelectList(_context.IngredientTypes, "Id", "Name", recipeIngredient.IngredientTypeId);
            ViewData["MeasurementTypeId"] = new SelectList(_context.MeasurementTypes, "Id", "Name", recipeIngredient.MeasurementTypeId);
            return View(recipeIngredient);
        }

        // GET: RecipeIngredients/Delete/5
        [HttpGet("{recipeId}/RecipeIngredients/Delete/{id}", Name = "recipeingredientdelete")]
        public async Task<IActionResult> Delete(int? recipeId, int? id)
        {
            if (id == null || recipeId == null)
            {
                return NotFound();
            }

            var recipeIngredient = await _context.RecipeIngredients
                .Include(r => r.IngredientType)
                .Include(r => r.MeasurementType)
                .Include(r => r.Recipe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipeIngredient == null)
            {
                return NotFound();
            }

            return View(recipeIngredient);
        }

        // POST: RecipeIngredients/Delete/5
        [HttpPost("{recipeId}/RecipeIngredients/Delete/{id}", Name = "recipeingredientdelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int recipeId, int id)
        {
            var recipeIngredient = await _context.RecipeIngredients.FindAsync(id);
            _context.RecipeIngredients.Remove(recipeIngredient);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Recipes", new { id = recipeId });
        }

        private bool RecipeIngredientExists(int id)
        {
            return _context.RecipeIngredients.Any(e => e.Id == id);
        }

        private bool RecipeExists(int recipeId)
        {
            return _context.Recipes.Any(e => e.Id == recipeId);
        }
    }
}
