using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVCPersistent.Data;
using CheeseMVCPersistent.Models;
using CheeseMVCPersistent.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVCPersistent.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CheeseDbContext context;

        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<CheeseCategory> categories = context.Categories.ToList();

            return View(categories);
        }

        public IActionResult Add()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();

            
            return View(addCategoryViewModel);

        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategoryViewModel)
        {
            //Add new cheese to existing cheeses
            if (ModelState.IsValid)
            {
                CheeseCategory newCheeseCategory = AddCategoryViewModel.CreateCheeseCategory(
                    addCategoryViewModel.Name);

                context.Categories.Add(newCheeseCategory); //CheeseData.AddCheese(newCheese);
                context.SaveChanges();

                return Redirect("/Category");
            }

            return View(addCategoryViewModel);
        }
    }
}
