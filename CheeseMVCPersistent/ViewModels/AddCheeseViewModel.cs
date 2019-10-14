using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CheeseMVCPersistent.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CheeseMVCPersistent.ViewModels
{
    public class AddCheeseViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        [Display(Name = "Cheese Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must give your cheese a description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public AddCheeseViewModel()
        {
        }

        public AddCheeseViewModel(IEnumerable<CheeseCategory> categories)
        {
            Categories = new List<SelectListItem>();

            foreach(CheeseCategory cat in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = cat.ID.ToString(),
                    Text = cat.Name
                });

            }

            /*
            //<option value="0">Hard</option>
            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Hard).ToString(),
                Text = CheeseType.Hard.ToString()
            });
            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Soft).ToString(),
                Text = CheeseType.Soft.ToString()
            });
            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Fake).ToString(),
                Text = CheeseType.Fake.ToString()
            });
            */
        }

        [Required]
        [Range(1, 5)]
        [Display(Name = "Rating (1-5)")]
        public int Rating { get; set; } = 3;

        public static Cheese CreateCheese(string name, string description, CheeseCategory category, int rating)
        {
            Cheese newCheese = new Cheese
            {
                Name = name,
                Description = description,
                Category = category,
                Rating = rating
            };
            return newCheese;
        }


    }
}
