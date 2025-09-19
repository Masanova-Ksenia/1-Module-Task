using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДомашнееЗадание_1
{
    public class Reader
    {
        public string Name { get; }
        public int ReaderId { get; }
        private List<Book> borrowedBooks;
        public Reader(string name, int id)
        {
            Name = name;
            ReaderId = id;
            borrowedBooks = new List<Book>();
        }
        public void BorrowBook(Book book)
        {
            borrowedBooks.Add(book);
        }
        public void ReturnBook(Book book)
        {
            borrowedBooks.Remove(book);
        }
        public override string ToString()
        {
            return $"Читатель: {Name}, ID: {ReaderId}, Взято книг: {borrowedBooks.Count}";
        }
    }
}