using LibreriaConsola.domain;
using LibreriaConsola.services;

Payment_MethodService paymentMethodServ = new Payment_MethodService();
BookService bookServ = new BookService();
List<Book>? books;
List<Payment_Method>? paymentMethods = paymentMethodServ.BringPaymentMethods();
UnitOfWork unitOfWork = new UnitOfWork();
     
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

Book book2 = new Book
{
    Isbn = "1234567890",
    Title = "C# Básico",
    Author = "Autor A",
    Pags_Number = 300,
    Stock = 10
};

if (bookServ.InsertBook(book2))
{
    Console.WriteLine("Book Added Succesfully");
}
else { Console.WriteLine("Error Adding the Book"); }

Book book3 = new Book
{
    Isbn = "0987654321",
    Title = "Bases de Datos",
    Author = "Autor B",
    Pags_Number = 400,
    Stock = 5
};

if (bookServ.InsertBook(book3))
{
    Console.WriteLine("Book Added Succesfully");
}
else { Console.WriteLine("Error Adding the Book"); }

Book book4 = new Book
{
    Isbn = "1122334455",
    Title = "Programación Avanzada",
    Author = "Autor C",
    Pags_Number = 500,
    Stock = 7
};

if (bookServ.InsertBook(book4))
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
        Console.WriteLine("-----");
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
    Title = "un libro xd",
    Author = "Matute",
    Pags_Number = 100,
    Stock = 5
};

if (bookServ.UpdateBook(book))
{
    Console.WriteLine("Book Updated Succesfully");
}
else { Console.WriteLine("Error Updating the Book"); }

if (bookServ.UnsubscribeBook(book))
{
    Console.WriteLine("Book Deleted Succesfully");
}
else { Console.WriteLine("Error Deleting the Book"); }

Invoice invoice1 = new Invoice
{
    Number = 0, 
    Date = DateTime.Today,
    Client = "Juan Pérez",
    Payment_Method = paymentMethods[2],
    ListDetails = new List<Invoice_Details>()
        {
            new Invoice_Details
            {
                Book = new Book { Isbn = "1234567890", Title = "C# Básico", Author = "Autor A", Pags_Number = 300, Stock = 10 },
                Amount = 2
            },
            new Invoice_Details
            {
                Book = new Book { Isbn = "0987654321", Title = "Bases de Datos", Author = "Autor B", Pags_Number = 400, Stock = 5 },
                Amount = 1
            }
        }
};

if (unitOfWork.SaveInvoiceWithDetails(invoice1))
{
    Console.WriteLine("Invoice Saved, Number: " + invoice1.Number);
}
else { Console.WriteLine("Error Saving the Invoice Number: " + invoice1.Number); }

Invoice invoice2 = new Invoice
{
    Number = 0,
    Date = DateTime.Today.AddDays(-10),
    Client = "Ana Gómez",
    Payment_Method = paymentMethods[0],
    ListDetails = new List<Invoice_Details>()
        {
            new Invoice_Details
            {
                Book = new Book { Isbn = "1122334455", Title = "Programación Avanzada", Author = "Autor C", Pags_Number = 500, Stock = 7 },
                Amount = 3
            }
        }
};

if (unitOfWork.SaveInvoiceWithDetails(invoice2))
{
    Console.WriteLine("Invoice Saved, Number: " + invoice2.Number);
}
else { Console.WriteLine("Error Saving the Invoice Number: " + invoice2.Number); }


List<Invoice>? invoices = unitOfWork.BringAllInvoices();

if (invoices != null && invoices.Count > 0)
{
    Console.WriteLine("//LIST OF INVOICES//");
    foreach (Invoice i in invoices)
    {
        Console.WriteLine("-----");
        Console.WriteLine(i.ToString());
        Console.WriteLine("\n|- Details -|:");
        if (i.ListDetails != null && i.ListDetails.Count > 0)
        {
            foreach (Invoice_Details detail in i.ListDetails)
            {
                Console.WriteLine("-");
                Console.WriteLine(detail.ToString());
            }
        }
    }
    Console.WriteLine("///////////////");
}
else
{
    Console.WriteLine("There are not Books Registered");
}

if (unitOfWork.DeleteInvoiceWithDetails(invoice1))
{
    Console.WriteLine("Invoice Deleted Succesfully");
}
else { Console.WriteLine("Error Deleting the Invoice"); }

if (unitOfWork.DeleteInvoiceWithDetails(invoice2))
{
    Console.WriteLine("Invoice Deleted Succesfully");
}
else { Console.WriteLine("Error Deleting the Invoice"); }

if (bookServ.UnsubscribeBook(book2))
{
    Console.WriteLine("Book Deleted Succesfully");
}
else { Console.WriteLine("Error Deleting the Book"); }
if (bookServ.UnsubscribeBook(book3))
{
    Console.WriteLine("Book Deleted Succesfully");
}
