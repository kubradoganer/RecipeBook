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
    [Route("Menus")]
    public class MenuItemsController : Controller
    {
        private readonly RecipeBookContext _context;

        public MenuItemsController(RecipeBookContext context)
        {
            _context = context;
        }


        // GET: MenuItems/Create
        [HttpGet("{menuId}/MenuItems/Create", Name = "menuitemcreate")]
        public async Task<IActionResult> Create(int? menuId)
        {
            if(menuId == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus.FirstOrDefaultAsync(i => i.Id == menuId);
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Name");
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Name");

            var menuItem = new MenuItem
            {
                Menu = menu
            };

            return View(menuItem);
        }

        // POST: MenuItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateAntiForgeryToken]
        [HttpPost("{menuId}/MenuItems/Create", Name = "menuitemcreate")]
        public async Task<IActionResult> Create(int? menuId, [Bind("RecipeId")] MenuItem menuItem)
        {
            if (menuId == null || !MenuExists(menuId.Value))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                menuItem.MenuId = menuId.Value;
                _context.Add(menuItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Menus", new { id = menuId });
            }
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Name", menuItem.MenuId);
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Name", menuItem.RecipeId);
            return View(menuItem);
        }

        // GET: MenuItems/Edit/5
        [HttpGet("{menuId}/MenuItems/Edit/{id}", Name = "menuitemedit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItem = await _context.MenuItems.Include(i => i.Menu).FirstOrDefaultAsync(i => i.Id == id);
            if (menuItem == null)
            {
                return NotFound();
            }
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Name", menuItem.MenuId);
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Name", menuItem.RecipeId);
            return View(menuItem);
        }

        // POST: MenuItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateAntiForgeryToken]
        [HttpPost("{menuId}/MenuItems/Edit/{id}", Name = "menuitemedit")]
        public async Task<IActionResult> Edit(int menuId, int id, [Bind("MenuId,RecipeId,Id")] MenuItem menuItem)
        {
            if (id != menuItem.Id || menuId != menuItem.MenuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuItemExists(menuItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Menus", new { id = menuId });
            }
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Name", menuItem.MenuId);
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Name", menuItem.RecipeId);
            return View(menuItem);
        }

        // GET: MenuItems/Delete/5
        [HttpGet("{menuId}/MenuItems/Delete/{id}", Name = "menuitemdelete")]
        public async Task<IActionResult> Delete(int? menuId, int? id)
        {
            if (id == null || menuId == null)
            {
                return NotFound();
            }

            var menuItem = await _context.MenuItems
                .Include(m => m.Recipe)
                .Include(m => m.Menu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }

        // POST: MenuItems/Delete/5
        [HttpPost("{menuId}/MenuItems/Delete/{id}", Name = "menuitemdelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int menuId, int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Menus", new { id = menuId });
        }

        private bool MenuItemExists(int id)
        {
            return _context.MenuItems.Any(e => e.Id == id);
        }

        private bool MenuExists(int menuId)
        {
            return _context.Menus.Any(e => e.Id == menuId);
        }
    }
}
