using System;
using System.Collections.Generic;
using CheeseMVCPersistent.Models;

namespace CheeseMVCPersistent.ViewModels
{
    public class ViewMenuViewModel
    {
        public Menu Menu { get; set; }
        public IList<CheeseMenu> Items { get; set; }


    }
}
