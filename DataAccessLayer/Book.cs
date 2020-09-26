using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public  class Book
    {
        [Key]
        public int BookID { get; set; }
        public string Name { get; set; }
        public  string ISBN { get; set; }
        public  string Author { get; set; }
        public  string Description { get; set; }
        public  string Photo { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
