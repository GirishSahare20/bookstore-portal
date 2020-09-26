using BookGatewayService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BookGateway
{
    public class BookGatewayFactory
    {
        public IBookGateway GetBookGateway(string type)
        {
            IBookGateway returnvalue = null;
            if (type.ToLower() == "paypal")
            {
                returnvalue = new Paypal();

            }
            else if(type.ToLower() == "stripnet")
            {

                returnvalue = new StripNet();
            }
            return returnvalue;
        }
    }
}
