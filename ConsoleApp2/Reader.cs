using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Reader
    {
        //Victor Rafael da Silva
        public string Name { get; set; }
        public string Cpf { get; set; }
        public List<string> Books { get; set; }

        public Reader(string name, string cpf)
        {
            Name = name;
            Cpf = cpf;
            Books = new List<string>();
        }
    }
}
