﻿using AndalusRestaurant.Data;
using AndalusRestaurant.Models;
using Microsoft.AspNetCore.Mvc;

namespace AndalusRestaurant.Controllers
{
    public class IngredientController : Controller
    {
        private Repository<Ingredient> ingredients;
        public IngredientController(ApplicationDbContext context)
        {
            ingredients = new Repository<Ingredient>(context);
        }

        public async Task<IActionResult>Details(int id)
        {
            return View(await ingredients.GetByIdAsync(id,new QueryOptions<Ingredient>()
            {
                Includes = "ProductIngredients.Product"
            }));

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngredientId,Name")] Ingredient ingredient)
        {
            if(ModelState.IsValid)
            {
                await ingredients.AddAsync(ingredient);
                return RedirectToAction("Index");
            }
            return View(ingredient);
        }

    }
}
