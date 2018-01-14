using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    public sealed class Fruit : Item
    {
        public new string Name { get; }
        public new int Price { get; }
        public new int InStock { get; }

              public new int Quantity => quantity;

        //Fruit class inherits from parent class item specifically for fruits
        //As a sealed class, no other class can inherit from it


        public Fruit(string name, int price, int inStock, string itemCode)
        {
            //This block helps to neaten the code up by allowing you to put your values 
            //In a bracket on a line for every new Fruit you wish to add

            this.Name = name;
            this.Price = price;
            InStock = inStock;
            NewMethod(itemCode);

            this.Total = this.Price * this.Quantity;
        }

       

        private void NewMethod(string itemCode)
        {
            this.ItemCode = itemCode;
        }

        public new string Receipt()
        {
            //Simply prints the user's current choice to screen in a conversational manner
            //NOT THE FINAL RECEIPT THO...


            this.Total = this.Price * this.Quantity;

            string receiptMessage = String.Format("\n\n----- Item Code: {4} ----- \n{0} cost {1:C} a piece. \nSo {2} will cost you {3:C}. \nPress enter to advance", this.Name, this.Price, this.Quantity, this.Total, this.ItemCode);

            return receiptMessage;
            //throw new NotImplementedException();
        }

        public new string HowManyItemsOfChoice
        {
            get
            {
                //Self explanatory

                string itemOfChoiceMessage = String.Format("\n\nHow many {0} would you like to buy?  ", this.Name);

                return itemOfChoiceMessage;

                //throw new NotImplementedException();
            }
        }

        public string ItemCode { get; private set; }
        public int quantity { get; private set; }
    }
}
