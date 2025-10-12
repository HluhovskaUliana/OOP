using System;
using System.Diagnostics;
using System.Text;

class Book
{
    public string author;
    public string title;
    public decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public string Author
    {
        get
        {
            return this.author;
        }
        set
        {
            var parts = value.Split(' ');
            if (parts.Length > 1 && char.IsDigit(parts[0][0]))
            {
                throw new ArgumentException("Author not valid!");
            }
            this.author = value;
        }
    }

    public string Title
    {
        get
        {
            return this.title;
        }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }

    public virtual decimal Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            this.price = value;
        }
    }

    public override string ToString()
    {
        var resultBuilder = new StringBuilder();
        resultBuilder.AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Title: {this.Title}")
            .AppendLine($"Author: {this.Author}")
            .AppendLine($"Price: {this.Price:f2}");
        
        return resultBuilder.ToString().TrimEnd();
    }
}

class GoldenEditionBook : Book
{
    public GoldenEditionBook(string author, string title, decimal price)
        : base(author, title, price) { }

    public override decimal Price => base.Price * 1.3m;
}

class BookShop
{
    static void Main()
    {
        try
        {
            string author = Console.ReadLine();
            string title = Console.ReadLine();
            decimal price = decimal.Parse(Console.ReadLine());

            Book book = new Book(author, title, price);
            GoldenEditionBook goldenBook = new GoldenEditionBook(author, title, price);

            Console.WriteLine(book + Environment.NewLine);
            Console.WriteLine(goldenBook);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.ReadKey();
    }
}
