using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    //I created an Abstract Class and named it Item
    abstract class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int InStock { get; set; }
        public int Total { get; set; }
        public string ItemCode { get; set; }
        public abstract string HowManyItemsOfChoice();
        public abstract string Receipt();
        //public abstract string PrintUserChoicesToTextFile();
    }
}
