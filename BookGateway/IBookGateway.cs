using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BookGatewayService
{
   public interface IBookGateway
    {
        PurchaseDetail SavePaymentDetails(PurchaseDetail purchaseDetail);
    }

    public class Paypal : IBookGateway
    {
        public PurchaseDetail SavePaymentDetails(PurchaseDetail purchaseDetail)
        {
            BookDbContext context = new BookDbContext();
            IBookRepository bookRepository = new BookRepository(context);

            PurchaseDetail opurchaseDetail = bookRepository.Add(purchaseDetail);
            return opurchaseDetail;
        }
    }
    public class StripNet : IBookGateway
    {
        public PurchaseDetail SavePaymentDetails(PurchaseDetail purchaseDetail)
        {
            BookDbContext context = new BookDbContext();
            IBookRepository bookRepository = new BookRepository(context);

            PurchaseDetail opurchaseDetail = bookRepository.Add(purchaseDetail);
            return opurchaseDetail;
        }
    }
   

}
