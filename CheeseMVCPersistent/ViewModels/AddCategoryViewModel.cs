using System;
using System.ComponentModel.DataAnnotations;
using CheeseMVCPersistent.Models;

namespace CheeseMVCPersistent.ViewModels
{
    public class AddCategoryViewModel
    {
        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        public static CheeseCategory CreateCheeseCategory(string name)
        {
            CheeseCategory newCheeseCategory = new CheeseCategory
            {
                Name = name
                
            };
            return newCheeseCategory;
        }
    }
}
