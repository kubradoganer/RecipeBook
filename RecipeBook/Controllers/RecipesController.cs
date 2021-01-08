﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Context;
using DataAccess.Entities;

namespace RecipeBook.Controllers
{
    public class RecipesController : Controller
    {
        private readonly RecipeBookContext _context;

        public RecipesController(RecipeBookContext context)
        {
            _context = context;
        }

        // GET: Recipes
        public async Task<IActionResult> Index()
        {
            var recipeBookContext = _context.Recipes.Include(r => r.CreatedUser)
                .Include(r => r.RecipeType)
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.IngredientType)
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.MeasurementType)
                .Include(r => r.RecipeTags)
                .ThenInclude(rt => rt.Tag);
            return View(await recipeBookContext.ToListAsync());
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .Include(r => r.CreatedUser)
                .Include(r => r.RecipeType)
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.IngredientType)
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.MeasurementType)
                .Include(r => r.RecipeTags)
                .ThenInclude(rt => rt.Tag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            ViewData["CreatedUserId"] = new SelectList(_context.Users, "Id", "FullName");
            ViewData["RecipeTypeId"] = new SelectList(_context.RecipeTypes, "Id", "Name");
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,RecipeTypeId,CreatedUserId,Id,CreateDate,UpdateDate")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatedUserId"] = new SelectList(_context.Users, "Id", "FullName", recipe.CreatedUserId);
            ViewData["RecipeTypeId"] = new SelectList(_context.RecipeTypes, "Id", "Name", recipe.RecipeTypeId);
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            ViewData["CreatedUserId"] = new SelectList(_context.Users, "Id", "FullName", recipe.CreatedUserId);
            ViewData["RecipeTypeId"] = new SelectList(_context.RecipeTypes, "Id", "Name", recipe.RecipeTypeId);
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,RecipeTypeId,CreatedUserId,Id,CreateDate,UpdateDate")] Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.Id))
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
            ViewData["CreatedUserId"] = new SelectList(_context.Users, "Id", "FullName", recipe.CreatedUserId);
            ViewData["RecipeTypeId"] = new SelectList(_context.RecipeTypes, "Id", "Name", recipe.RecipeTypeId);
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .Include(r => r.CreatedUser)
                .Include(r => r.RecipeType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.Id == id);
        }
    }
}
