using System;
using System.Collections.Generic;
using System.Text;

namespace _10_GenericTypesCollections.Models
{



    internal class BookManager
    {
        public List<Book> Books { get; set; }
        public Dictionary<string, List<Book>> BooksByAuthor { get; set; }
        public Queue<string> WaitingQueue { get; set; }
        public Stack<Book> RecentlyReturned { get; set; }
        public BookManager()
        {
            Books = new List<Book>(); new Dictionary<string, List<Book>>();
            BooksByAuthor = new Dictionary<string, List<Book>>();
            WaitingQueue = new Queue<string>();
            RecentlyReturned = new Stack<Book>();
        }
        public void AddBook(Book book )
        {
            Books.Add(book);

            if (BooksByAuthor.ContainsKey(book.Author))
            {
                BooksByAuthor[book.Author] = new List<Book>();
            }

            BooksByAuthor[book.Author].Add(book);

            Console.WriteLine("yeni kitab elave olundu");
        }
        public Book SearchByTitle(string title)
        {
            foreach (var item in Books)

            {
                if (title==item.Title )
                {

                    return item;

                }
            }
            return null;
        }
        public List<Book> GetBooksByAuthor(string author)
        {
            if (BooksByAuthor.ContainsKey(author))

            {
                return BooksByAuthor[author];

            }
            return new List<Book>();
        }
        public void AddToWaitingQueue(string memberName)
        {
            WaitingQueue.Enqueue(memberName);
            Console.WriteLine($"{memberName }Elave olundu");

            
        }
        public string ServeNextInQueue()
        {
            if (WaitingQueue.Count != 0)
            {

                return WaitingQueue.Dequeue();

            }
            return null;
        }
        public void ReturnBook(Book book)
        {
            RecentlyReturned.Push(book);


            Console.WriteLine($"Kitab qebul edildi:{book.Title}");

        }
        public Book GetLastReturnedBook()
        {
            if (RecentlyReturned.Count != 0)

            {
                return RecentlyReturned.Peek();

            }
            return null;
        }
       

    }

}
