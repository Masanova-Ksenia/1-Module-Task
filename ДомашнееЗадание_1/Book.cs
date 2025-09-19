using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДомашнееЗадание_1
{
    public class Book
    {
        public string Title { get; }
        public string Author { get; }
        public string ISBN { get; }
        public int CopiesAvailable { get; private set; }
        public Book(string title, string author, string isbn, int copies)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            CopiesAvailable = copies;
        }
        public bool Borrow()
        {
            if (CopiesAvailable > 0)
            {
                CopiesAvailable--;
                return true;
            }
            return false;
        }
        public void Return()
        {
            CopiesAvailable++;
        }
        public override string ToString()
        {
            return $"{Title} ({Author}), ISBN: {ISBN}, Доступно: {CopiesAvailable}";
        }
    }
}