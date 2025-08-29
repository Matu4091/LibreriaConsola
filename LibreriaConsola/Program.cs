using LibreriaConsola.domain;
using LibreriaConsola.services;

BookService bookServ = new BookService();
List<Book>? books;

Book book = new Book
{
    Isbn = "123-42",
    Title = "Bohemian Rhapsody",
    Author = "Matu",
    Pags_Number = 200,
    Stock = 10
};

if (bookServ.InsertBook(book))
{
    Console.WriteLine("Book Added Succesfully");
}
else { Console.WriteLine("Error Adding the Book"); }

books = bookServ.BringBooks();

if (books != null && books.Count > 0)
{
    Console.WriteLine("//LIST OF BOOKS//");
    foreach (Book b in books)
    {
        Console.WriteLine("-");
        Console.WriteLine(b.ToString());
    }
    Console.WriteLine("///////////////");
}
else
{
    Console.WriteLine("There are not Books Registered");
}

book = new Book
{
    Isbn = "123-42",
    Title = "Tu vieja xd",
    Author = "Matute",
    Pags_Number = 100,
    Stock = 5
};

if (bookServ.UpdateBook(book))
{
    Console.WriteLine("Book Updated Succesfully");
}
else { Console.WriteLine("Error Updating the Book"); }

if (bookServ.DeleteBook("123-42"))
{
    Console.WriteLine("Book Deleted Succesfully");
}
else { Console.WriteLine("Error Deleting the Book"); }
