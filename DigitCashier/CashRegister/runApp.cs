using CashRegister.filehandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    class runApp
    {
        public static void Main(string[] args)
        {
            FileHandler fh = new FileHandler("Products.txt");
            fh.addLine("Super_Product 1 0 yolo");
            
            String code;
            Program program;

            Console.WriteLine("Please log in with your three digit code: ");
            code = Console.ReadLine();

            if (code.Length > 0) { 
                if (code[0].Equals('2'))
                {
                    program = new Program();
                }
                else if (code[0].Equals('3'))
                {

                }
                else if (code[0].Equals('5'))
                {

                }
            }
        }
    }
}
