using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.filehandler
{
    //skrrt skrrt
    class FileHandler
    {
        private String path = "";
        private String[] data = null;

        public FileHandler(String fileName)
        {
            this.path += fileName;
            data = read();
            Console.WriteLine(data[0]);
        }

        public String[] read()
        {
            string[] lines = System.IO.File.ReadAllLines(@path);
            return lines;
        }

        public void addLine(String dataWrite)
        {
            File.AppendAllText(path,
                   dataWrite + Environment.NewLine);
        }
    }
}