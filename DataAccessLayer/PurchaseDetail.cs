using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public class PurchaseDetail
    {
        [Key]
        public int PurchaseID { get; set; }
        public int BookID { get; set; }
        public int Userid { get; set; }
        public DateTime PurchasedOn { get; set; }
        public double Amount { get; set; }
        public string transactionstatus { get; set; }
        public string transactionType { get; set; }
    }
}
