

using _10_GenericTypesCollections.Models;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // books
        Book b1 = new Book(1, "Martin Eden", "Jack London", 1909, 400);
        Book b2 = new Book(2, "1984", "George Orwell", 1949, 328);
        Book b3 = new Book(3, "Animal Farm", "George Orwell", 1945, 112);
        Book b4 = new Book(4, "Ag Gemi", "Cingiz Aytmatov", 1970, 200);
        Book b5 = new Book(5, "Qiriq Budag", "Elcin", 1998, 350);

        List<Book> books = new List<Book> { b1, b2, b3, b4, b5 };

        foreach (var b in books)
        {
            b.DisplayInfo();
        }

        // library
        Library<Book> lib = new Library<Book>("Milli Kitabxana");

        foreach (var b in books)
        {
            lib.Add(b);
        }

        Console.WriteLine("Count: " + lib.Count());

        lib.FindByIndex(0).DisplayInfo();
        lib.FindByIndex(2).DisplayInfo();

        foreach (var b in lib.GetAll())
        {
            b.DisplayInfo();
        }

        // members
        List<Member> members = new List<Member>();
        members.Add(new Member(1, "Ali Memmedov", "ali@mail.com"));


        members.Add(new Member(2, "Leyla Hesenova", "leyla@mail.com"));


        members.Add(new Member(3, "Vuqar Eliyev", "vuqar@mail.com"));


        var m = members[0];

        m.BorrowBook(b1);
        m.BorrowBook(b2);
        m.DisplayBorrowedBooks();

        m.ReturnBook(1);
        m.DisplayBorrowedBooks();

        m.BorrowBook(b3);
        m.BorrowBook(b4);
        m.BorrowBook(b5);

        // manager
        BookManager bm = new BookManager();

        foreach (var b in books)
        {
            bm.AddBook(b);
        }

        foreach (var x in bm.GetBooksByAuthor("George Orwell"))
        {
            x.DisplayInfo();
        }

        foreach (var x in bm.GetBooksByAuthor("Cingiz Aytmatov"))
        {
            x.DisplayInfo();
        }

        Console.WriteLine("Dostoyevski count: " + bm.GetBooksByAuthor("Dostoyevski").Count);

        // queue
        bm.AddToWaitingQueue("Nigar");
        bm.AddToWaitingQueue("Resad");
        bm.AddToWaitingQueue("Sebine");

        Console.WriteLine("Queue: " + bm.WaitingQueue.Count);

        Console.WriteLine("Serving: " + bm.ServeNextInQueue());
        Console.WriteLine("Queue: " + bm.WaitingQueue.Count);

        bm.ServeNextInQueue();
        bm.ServeNextInQueue();

        Console.WriteLine("Queue: " + bm.WaitingQueue.Count);

        // stack
        bm.ReturnBook(b1);
        bm.ReturnBook(b2);
        bm.ReturnBook(b3);


        Console.WriteLine("Stack: " + bm.RecentlyReturned.Count);


        var last = bm.GetLastReturnedBook();
        if (last != null)
        {
            last.DisplayInfo();
        }

        bm.RecentlyReturned.Pop();


        Console.WriteLine("Stack: " + bm.RecentlyReturned.Count);


        var last2 = bm.GetLastReturnedBook();
        if (last2 != null)
        {
            last2.DisplayInfo();
        }

        // search
        var f = bm.SearchByTitle("1984");
        if (f != null)
        {
            f.DisplayInfo();
        }

        var nf = bm.SearchByTitle("Harry Potter");
        if (nf == null)
        {

            Console.WriteLine("Not found");
        }

        // stats
        Console.WriteLine("Books: " + bm.Books.Count);


        Console.WriteLine("Members: " + members.Count);


        Console.WriteLine("Queue: " + bm.WaitingQueue.Count);


        Console.WriteLine("Stack: " + bm.RecentlyReturned.Count);

        int min = int.MaxValue;
        int max = int.MinValue;

        foreach (var b in bm.Books)
        {
            if (b.Year < min) min = b.Year;
            if (b.Year > max) max = b.Year;
        }

        Console.WriteLine("Old: " + min);


        Console.WriteLine("New: " + max);
    }
}