var library = new Library();

var isProgramRunning = true;

while (isProgramRunning)
{
    Console.WriteLine("Please select the option that you would like to perform with the books: \n Add, \n Remove, \n List all, \n Exit");
    var selectedOption = Console.ReadLine();

    switch (selectedOption)
    {
        case "Add":
            library.AddBook();
            break;

        case "Remove":
            library.RemoveBook();
            break;

        case "List all":
            library.GetAll();
            break;

        case "Exit":
            Console.WriteLine("Bye-bye!");
            isProgramRunning = false;
            break;
    }
}

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public DateOnly ReleaseDate { get; set; }

}

class Library
{
    public List<Book> Books { get; set; }

    public Library()
    {
        Books = new List<Book>();
    }

    public void AddBook()
    {
        var book = new Book();

        Console.WriteLine("Hi, please provide Title of the book");
        book.Title = Console.ReadLine();

        Console.WriteLine("Please provide the Author of the book");
        book.Author = Console.ReadLine();

        Console.WriteLine("Please provide the Release Date of the book (dd.mm.yyyy)");
        var dateInput = Console.ReadLine();

        if (DateOnly.TryParse(dateInput, out DateOnly date))
        {
            book.ReleaseDate = date;
        }

        try
        {
            foreach (var libBook in Books)
            {
                if (book.Title == libBook.Title)
                {
                    throw new Exception("The book already exists");
                }
            }
            Books.Add(book);
            Console.WriteLine("The book has been successfully added to the library");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void RemoveBook()
    {
        Console.WriteLine("Please enter the name of the book you'd like to take from the library");
        var bookName = Console.ReadLine();

        var bookToRemove = new Book();

        foreach (var book in Books)
        {
            if (book.Title == bookName)
            {
                bookToRemove = book;
            }
        }

        try
        {
            if (!Books.Remove(bookToRemove))
            {
                throw new Exception("The given book doesn't exist in the library");
            }
            Console.WriteLine("The book has been successfully taken from the library");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void GetAll()
    {
        foreach (var book in Books)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Release Date: {book.ReleaseDate}.");
        }
    }
}