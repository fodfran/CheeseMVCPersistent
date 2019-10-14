using System;
using System.ComponentModel.DataAnnotations;
using CheeseMVCPersistent.Models;

namespace CheeseMVCPersistent.ViewModels
{
    public class AddMenuViewModel
    {
        [Required]
        [Display(Name = "Menu Name")]
        public string Name { get; set; }


        public static Menu CreateMenu(string name)
        {
            Menu newMenu = new Menu
            {
                Name = name

            };
            return newMenu;
        }
    }
}
