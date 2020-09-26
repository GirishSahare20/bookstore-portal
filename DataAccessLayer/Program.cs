using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            BookDbContext context = new BookDbContext();
            IBookRepository bos = new BookRepository(context);
            var books = bos.GetAllBooks();
            foreach (var book in books)
            {
                Console.WriteLine(book.Name);
                Console.WriteLine("\n");
            }
            Console.ReadLine();

            //using (var db = new BookDbContext())
            //{
            //    Console.WriteLine("ok");
            //    for (int i = 0; i < 10; i++)
            //    {
            //        //
            //        Book book = new Book { BookID = i + 1, Name = "Book" + i.ToString(), ISBN = "014310542" + i.ToString(), Author = "Author" + i.ToString(), Description = "Book" + i.ToString(), Photo = "Book" + i.ToString() + ".jpg", Price = 100.00, Stock = 100 };
            //        db.Books.Add(book);
            //        db.SaveChanges();

            //    }
            //    var count = db.Books.Count();
            //    Console.WriteLine(count);
            //    for (int i = 0; i < 3; i++)
            //    {
            //        //Console.WriteLine("ok");
            //        UserInfo user = new UserInfo { Userid = i + 1, Username = "Test" + i.ToString(), Email = "Test" + i.ToString() + "@test.com", Name = "Test" + i.ToString(), Password = "Test" + i.ToString() };
            //        db.UserInfos.Add(user);
            //        db.SaveChanges();

            //    }
            //    var count1 = db.UserInfos.Count();
            //    Console.WriteLine(count1); ;


            //    // Console.WriteLine(count);
            //    Console.ReadLine();


            //    //foreach (var book in books)
            //    //{
            //    //    author.Books.Remove(book);
            //    //}
            //    //context.Remove(author);
            //    //context.SaveChanges();
            //}
        }
    }
}
