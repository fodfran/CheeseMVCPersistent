﻿using System;
using System.Collections.Generic;

namespace CheeseMVCPersistent.Models
{
    public class Menu
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public IList<CheeseMenu> CheeseMenus { get; set; } = new List<CheeseMenu>();
    }
}
