using LibreriaConsola.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaConsola.domain;

namespace LibreriaConsola.services
{
    internal class BookService
    {
        private IRepository<Book, string> BookRepo;

        public BookService()
        {
            BookRepo = new BookRepository();
        }

        public List<Book>? BringBooks()
        {
            return BookRepo.GetAll();
        }

        public Book? BringBook(string isbn)
        {
            return BookRepo.GetById(isbn);
        }

        private bool ValidateExisting(string isbn)
        {
            Book? b = BookRepo.GetById(isbn);
            if (b == null) { return true; }
            else { return false; }
        }

        public bool InsertBook(Book book)
        {
            if (ValidateExisting(book.Isbn))
            {
                return BookRepo.Save(book);
            }
            else
            {
                Console.Write("The ISBN in the DataBase already Exists\n");
                return false;
            }
        }

        public bool UpdateBook(Book book)
        {
            if (!ValidateExisting(book.Isbn))
            {
                return BookRepo.Save(book);
            }
            else
            {
                Console.Write("There is not a Book with that ISBN\n");
                return false;
            }
        }

        public bool DeleteBook(string isbn)
        {
            if (!ValidateExisting(isbn))
            {
                return BookRepo.Delete(isbn);
            }
            else
            {
                Console.Write("There is not a Book with that ISBN\n");
                return false;
            }
        }
    }
}
