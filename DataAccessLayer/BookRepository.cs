using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IBookRepository
    {
    
        IEnumerable<Book> GetAllBooks();
        Book GetBook(int Id);
        PurchaseDetail Add(PurchaseDetail purchaseDetail);
        
    }
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext context;

        public BookRepository(BookDbContext context)
        {
            this.context = context;
        }

        public PurchaseDetail Add(PurchaseDetail purchaseDetail)
        {
            int? count = context.PurchaseDetails.Count();

            purchaseDetail.PurchaseID = count.GetValueOrDefault()+1;
            context.PurchaseDetails.Add(purchaseDetail);
            context.SaveChanges();

            Book book = context.Books.Find(purchaseDetail.BookID);
            if (book != null)
            {
                book.Stock = book.Stock - 1;
                context.SaveChanges();
            }
            return purchaseDetail;

        }

        public IEnumerable<Book> GetAllBooks()
        {
            return context.Books;
        }

        public Book GetBook(int Id)
        {
            return context.Books.Find(Id);
        }
    }
}
