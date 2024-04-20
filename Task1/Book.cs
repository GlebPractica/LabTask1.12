using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Book
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"Автор: {Author}, название {Title}, год {Year}";
        }
    }
}
