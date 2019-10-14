using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CheeseMVCPersistent.Models;
using CheeseMVCPersistent.ViewModels;
using CheeseMVCPersistent.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVCPersistent.Controllers
{
    public class CheeseController : Controller
    {
        //db setup
        private readonly CheeseDbContext context;

        public CheeseController(CheeseDbContext dbContext)
        {
            this.context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {

            IList<Cheese> cheeses = context.Cheeses.Include(c => c.Category).ToList(); //CheeseData.GetAll();

            ViewBag.Title = "My Cheese";

            return View(cheeses);
        }

        [HttpPost]
        [Route("/Cheese")]
        public IActionResult Remove(int[] cheeses)
        {
            foreach (int id in cheeses)
            {
                //CheeseData.RemoveCheese(id);
                Cheese theCheese = context.Cheeses.Single(c => c.ID == id);
                context.Cheeses.Remove(theCheese);

            }

            context.SaveChanges();

            return Redirect("/Cheese");
        }

        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel =
                new AddCheeseViewModel(context.Categories.ToList());

            //ViewBag.error = error;
            //error = "";
            return View(addCheeseViewModel);

        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            //Add new cheese to existing cheeses
            if (ModelState.IsValid)
            {
                CheeseCategory newCheeseCategory =
                    context.Categories.Single(c => c.ID == addCheeseViewModel.CategoryID);

                Cheese newCheese = AddCheeseViewModel.CreateCheese(
                    addCheeseViewModel.Name,
                    addCheeseViewModel.Description,
                    newCheeseCategory,
                    addCheeseViewModel.Rating);

                context.Cheeses.Add(newCheese); //CheeseData.AddCheese(newCheese);
                context.SaveChanges();

                return Redirect("/Cheese");
            }

            
            /*
            Regex rgx = new Regex(@"^[A-Za-z ]+$");
            if (addCheeseViewModel.Name == null || rgx.IsMatch(addCheeseViewModel.Name) == false)
            {
                error = "Invalid Name";
                return Redirect("/Cheese/Add");
            }*/


            return View(new AddCheeseViewModel(context.Categories.ToList()));
        }

        public IActionResult Edit(int cheeseId)
        {
            //ViewBag.cheese = CheeseData.GetByID(cheeseId);

            Cheese cheese = context.Cheeses.Single(c => c.ID == cheeseId); //CheeseData.GetByID(cheeseId);
            AddEditCheeseViewModel addEditCheeseViewModel = new AddEditCheeseViewModel(context.Categories.ToList())
            {
                Name = cheese.Name,
                Description = cheese.Description,
                CategoryID = cheese.Category.ID,
                cheeseId = cheese.ID,
                Rating = cheese.Rating
                
            };

            return View(addEditCheeseViewModel);
        }

        [HttpPost]
        [Route("/Cheese/Edit")]
        public IActionResult Edit(AddEditCheeseViewModel addEditCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                CheeseCategory newCheeseCategory =
                    context.Categories.Single(c => c.ID == addEditCheeseViewModel.CategoryID);

                Cheese cheeseEdit = context.Cheeses.Single(c => c.ID == addEditCheeseViewModel.cheeseId); //CheeseData.GetByID(addEditCheeseViewModel.cheeseId);

                cheeseEdit.Name = addEditCheeseViewModel.Name;
                cheeseEdit.Description = addEditCheeseViewModel.Description;
                cheeseEdit.Category = newCheeseCategory;
                cheeseEdit.Rating = addEditCheeseViewModel.Rating;

                

                context.SaveChanges();
                return Redirect("/Cheese");
            }

            return View(new AddEditCheeseViewModel(context.Categories.ToList()));
        }

        public IActionResult Category(int id)
        {
            if (id == 0)
            {
                return Redirect("/Category");
            }

            CheeseCategory theCategory = context.Categories
                .Include(c => c.Cheeses)
                .Single(c => c.ID == id);

            /*
             IList<Cheese> theCheeses = context.Cheeses
                .Include(c => c.Category)
                .Where(c => c.CategoryID == id)
                .ToList()
             */

            ViewBag.Title = "Cheeses in Category: " + theCategory.Name;

            return View("Index", theCategory.Cheeses);
        }

    }
}
