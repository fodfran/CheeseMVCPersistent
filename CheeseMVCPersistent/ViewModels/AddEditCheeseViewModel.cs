using System;
using System.Collections.Generic;
using CheeseMVCPersistent.Models;

namespace CheeseMVCPersistent.ViewModels
{
    public class AddEditCheeseViewModel : AddCheeseViewModel
    {
        public AddEditCheeseViewModel(IEnumerable<CheeseCategory> categories) : base(categories)
        {
        }

        public AddEditCheeseViewModel() { }

        //public AddEditCheeseViewModel(IEnumerable<CheeseCategory> categories) : base(categories)
        //{
        //}

        public int cheeseId { get; set; }

    }
}
