using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    public class Item
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public  int Age { get; set; }

        public override string ToString()
        {
            return Name + Surname;
        }
    }
}
