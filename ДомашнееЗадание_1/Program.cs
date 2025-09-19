using System;
using System.Collections.Generic;
using System.Linq;

namespace ДомашнееЗадание_1
{ 
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            Book book1 = new Book("Преступление и наказание", "Ф.М. Достоевский", "1111", 3);
            Book book2 = new Book("Война и мир", "Л.Н. Толстой", "2222", 2);
            Book book3 = new Book("Мастер и Маргарита", "М.А. Булгаков", "3333", 1);

            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);

            Reader reader1 = new Reader("Иван Иванов", 1);
            Reader reader2 = new Reader("Анна Смирнова", 2);

            library.RegisterReader(reader1);
            library.RegisterReader(reader2);

            library.ShowBooks();
            library.ShowReaders();

            library.LendBook("1111", 1);

            library.ShowBooks();
            library.ShowReaders();

            library.ReturnBook("1111", 1);

            library.RemoveBook("3333");
            library.RemoveReader(2);
            
            library.ShowBooks();
            library.ShowReaders();
        }
    }
}