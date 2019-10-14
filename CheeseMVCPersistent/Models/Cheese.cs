using System;
using System.Collections.Generic;

namespace CheeseMVCPersistent.Models
{
    public class Cheese
    {
        //private static int nextCheeseId = 1;
        //public int CheeseId { get; set; }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int CategoryID { get; set; }
        public CheeseCategory Category{ get; set; }

        public List<CheeseMenu> CheeseMenus { get; set; }

        public int Rating { get; set; }



        /*public Cheese()//string name, string description) //commented out for binding
        {
            CheeseId = nextCheeseId++;
            //Name = name;
            //Description = description;
            //Type = CheeseType.Hard;
        }*/

    }
}
