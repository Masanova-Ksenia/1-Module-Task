using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДомашнееЗадание_1
{
    public class Library
    {
        private List<Book> books;
        private List<Reader> readers;
        public Library()
        {
            books = new List<Book>();
            readers = new List<Reader>();
        }
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public void RemoveBook(string isbn)
        {
            var book = books.FirstOrDefault(b => b.ISBN == isbn);
            if (book != null)
            {
                books.Remove(book);
            }
        }
        public void RegisterReader(Reader reader)
        {
            readers.Add(reader);
        }
        public void RemoveReader(int readerId)
        {
            var reader = readers.FirstOrDefault(r => r.ReaderId == readerId);
            if (reader != null)
            {
                readers.Remove(reader);
            }
        }
        public bool LendBook(string isbn, int readerId)
        {
            var book = books.FirstOrDefault(b => b.ISBN == isbn);
            var reader = readers.FirstOrDefault(r => r.ReaderId == readerId);

            if (book != null && reader != null && book.Borrow())
            {
                reader.BorrowBook(book);
                return true;
            }
            return false;
        }
        public bool ReturnBook(string isbn, int readerId)
        {
            var book = books.FirstOrDefault(b => b.ISBN == isbn);
            var reader = readers.FirstOrDefault(r => r.ReaderId == readerId);

            if (book != null && reader != null)
            {
                book.Return();
                reader.ReturnBook(book);
                return true;
            }
            return false;
        }
        public void ShowBooks()
        {
            Console.WriteLine("Книги в библиотеке:");
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
        public void ShowReaders()
        {
            Console.WriteLine("Читатели библиотеки:");
            foreach (var reader in readers)
            {
                Console.WriteLine(reader);
            }
        }
    }
}