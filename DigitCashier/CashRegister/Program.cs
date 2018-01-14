using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


// The code is filled with lots of METHODS, I did this because i didn't want to write the same code over and over again
// I could still put everything under one method to make me write just one line of code for each operation but i would find
// difficulty in correcting errors

    //hjälp vi ser grus
namespace CashRegister
{
    class Program
    {
        private static string message = "", x = "";
        //message and x and declared in this way because i needed to use them in other methods in this class
        

        private static int length = 1, grandTotal = 0;
        //length is used in the for loop in order to enable the user run the code or any number of times without closing
        //Grandtotal keeps record of the total of every item purchase you make and stores in memory till it's needed later
        //


        //private static string x = "";
        private static StreamWriter writeToTextFile = new StreamWriter("Receipts.txt");

        public static string Message { get => Message2; set => Message2 = value; }
        public static string X { get => x; set => x = value; }
        public static string Message1 { get => Message2; set => Message2 = value; }
        public static string X1 { get => x; set => x = value; }
        public static string Message2 { get => message; set => message = value; }

        //Streamwriter Writes every purchas to the text file Receipts. txt
        static void Main(string[] args)
        {

            writeToTextFile.WriteLine("\nThanks for doing business with us \nHere's Your Receipt: \n\n");//First line written into the text file
            writeToTextFile.WriteLine("Item   Quantity  Price   Total\n\n");

            Fruit banana = new Fruit("Bananas", 2, 50, "Moos");
            Fruit apple = new Fruit("Apples", 3, 62, "Toofah");
            Fruit pineApple = new Fruit("Pineapples", 2, 100, "Ananas");
            Fruit pear = new Fruit("Pears", 4, 72, "Ambarude");
            Fruit orange = new Fruit("Oranges", 5, 93, "Lean");
            Fruit mango = new Fruit("Mangoes", 6, 90, "Ambe");
           

            for (int i = 0; i < length; i++)
                {
                    try
                    {

                    if (length == 1)
                    {
                        Message2 = "Hello! What would you like to buy?   ";
                    }
                    else if (length >= 1)
                    {
                        Message2 = "\nThanks for staying! What else would you like to buy?   ";
                    }
                    Console.Write(Message2);
                        //JUST FOR READABILITY SAKE.
                        //NOBODY LOVES A ONE WAY TELLER ;)
                    string userPurchaseValue = Console.ReadLine().ToUpper();

                    switch (userPurchaseValue) 
                    {

                            //I PREFER SWITCH CASES OVER IF STATEMENTS IF SO MANY INSTANCES ARE TO BE GIVEN-- MOSTLY DEALING WITH USER INPUT
                        default:
                            Console.WriteLine("Sorry, we do not have {0} in stock yet", userPurchaseValue);
                            //i -= 1;
                            x = "\n                     \n";
                            //I another item is typed whether intentional or mistakenly, draw the users attention
                            break;


                        case "BANANA":

                            RequiredOperations(banana);

                            //howManyWho(banana);      
                            //Message How Many bananas...

                            //getUserInputForQuantity(banana);
                            // Evaluates how many items you want

                            //x = PrintUserChoicesToTextFile(banana);
                            // If Banana is chosen, current value of x which includes 
                            
                            //grandTotal += banana.Total;//grandTotal Updated

                            

                            break;


                        case "APPLE":

                            RequiredOperations(apple);

                            //howManyWho(apple);
                            //getUserInputForQuantity(apple);
                            //x = PrintUserChoicesToTextFile(apple);
                            //grandTotal += apple.Total;
                            break;


                        case "PINEAPPLE":

                            RequiredOperations(pineApple);

                            //howManyWho(pineApple);
                            //getUserInputForQuantity(pineApple);
                            //x = PrintUserChoicesToTextFile(pineApple);
                            //grandTotal += pineApple.Total;
                            break;

                        case "MANGO":

                            RequiredOperations(mango);

                            //howManyWho(mango);
                            //getUserInputForQuantity(mango);
                            //x = PrintUserChoicesToTextFile(mango);
                            //grandTotal += mango.Total;
                            break;

                        case "PEAR":

                            RequiredOperations(pear);

                            //howManyWho(pear);
                            //getUserInputForQuantity(pear);
                            //x = PrintUserChoicesToTextFile(pear);
                            //grandTotal += pear.Total;
                            break;

                        case "ORANGE":

                            RequiredOperations(orange);

                            //howManyWho(orange);
                            //getUserInputForQuantity(orange);
                            //x = PrintUserChoicesToTextFile(orange);
                            //grandTotal += orange.Total;
                            break;






                        
                    }
                    //writeToTextFile.WriteLine(x);//at the end of each loop write the current value for x into text file
                    Console.ReadLine();
                    ContinuePurchase();


                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("\n\n\n\n\n{0}\n\n\n\n", e.Message);

                        // THE ONLY RELEVANT EXCEPTION TYPE I FOUND NECESSARY TO USE AT THE MOMENT SINCE THAT'S PROBABLY THE MOST LIKELY OF ERRORS

                        ContinuePurchase();
                    }
            }
        }

        private static void RequiredOperations(Item item)
        {
            HowManyWho(item);
            GetUserInputForQuantity(item);
            writeToTextFile.WriteLine(PrintUserChoicesToTextFile(item));
            Total(item);
        }

        private static void Total(Item item)
        {
            grandTotal += item.Total;
        }

        private static void ContinuePurchase()
        {
            //Simple message to find out if the user wants to buy anything else after each purchase attempt
            //i could make the user specify the number of items before hand but i just used this to protect 
            //customers from feeling stupid or undecided about how many items to buy

            Console.Write("Continue Shopping?    ( Y / N )  ");
            string tryReadKey = Console.ReadLine().ToUpper();//ToUpper() converts your user input into uppercase to prevent mismatched key input

            if (tryReadKey == "Y")
            {
                //If yes, then increase the scope of the for loop
                length += 1;
            }

            else
            {
                //otherwise put a line under the shopping list in the text file
                writeToTextFile.WriteLine("\n-----------------------------------------");
                writeToTextFile.Close();
                // End the StreamWriter process to enable other processes(Specifically StreamReader) to gain access to the text file

                Console.Clear();//just like DOS cls command
                length = 0;// End the for loop

                StreamReader readFromTextFile = new StreamReader("Receipts.txt");
                //New System.IO.TextReader extension that acts as a straw and sucks up every element from the text file
                
                string line = "";
                //Empty String

                while ((line = readFromTextFile.ReadLine()) != null)
                {
                    //The empty string equals every line read from the text file while theres still text to read,
                    //The process will remain active until the last line of the file is reached.

                    Console.WriteLine(line);
                    //Writes out every line to the console window
                    
                }
                Console.WriteLine("\nGRAND TOTAL:                       {0:C}", grandTotal);
                //Writes the grand total
                Console.ReadLine();
            }
        }


        private static void GetUserInputForQuantity(Item item)
        {
            //make sure there are enough items in stock before you embarrass yourself and your client as well
            int userInputForQuantity = int.Parse(Console.ReadLine());
            item.Quantity = userInputForQuantity;
            if (item.Quantity > item.InStock) //Jag undrar en sak och det är om jag behöver extrahera denna iteration till Item.cs filen?
            {
                Rejection(item);
                length -= 1;
            }
            else
            {
                PrintReceipt(item);// Refer to printReceipt Method for clarity
            }
            NewMethod(item);

            //throw new NotImplementedException();
        }

        private static void Rejection(Item item)
        {
            Console.WriteLine("\nWe cannot give you the {0} {1} you requested\nbecause we have only {2} left in stock.\nWe are deeply sorry for any inconvenince caused.\n                                          Thank You!", item.Quantity, item.Name, item.InStock);
        }

        public static void NewMethod(Item item)
        {
            CheckItem(item);
        }

        public static void CheckItem(Item item) => item.InStock < item.Quantity;//Jag blev förvirrad här. Jag känner en blind spot härborta//Simply subtracts the quantity of items bought from the quantity in stock if purchase is successful

        private static void PrintReceipt(Item item)
        {
            Console.WriteLine(item.Receipt());//any object inheriting properties from Item can reference the receipt property 
        }

        private static void HowManyWho(Item item)
        {
            Console.Write(value: item.HowManyItemsOfChoice());// Refer to HowManyItemsOfChoice under fruit class.. 
        }

        private static string PrintUserChoicesToTextFile(Item item)
        {
            //The items are written to the text file in this format
            string allUserChoices = String.Format("{0} --- {1} --- {2:C} --- {3:C}", item.Name, item.Quantity, item.Price,item.Total);
            return allUserChoices;
            //throw new NotImplementedException();
        }
    }
    
}


