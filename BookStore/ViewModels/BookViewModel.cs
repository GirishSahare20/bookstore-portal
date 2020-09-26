using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KCN.ViewModels
{
    
          public class BookViewModel
        {
          
            public int BookID { get; set; }
            public string Name { get; set; }
            public string ISBN { get; set; }
            public string Author { get; set; }
            public string Description { get; set; }
            public string Photo { get; set; }
            public double Price { get; set; }
            public int Stock { get; set; }
            public string SId { get; set; }
    }
    }