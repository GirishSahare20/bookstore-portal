using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;

namespace DataAccessLayer
{
    public class BookDbContext : DbContext
    {
        
        public BookDbContext() : base("name=DbConnectionString")
        {
          //  Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BookDbContext>());
           //Database.SetInitializer(new DropCreateDatabaseAlways<BookDbContext>());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }
    }



}
