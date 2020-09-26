using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public class UserInfo
    {
        [Key]
        public int Userid { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }      
        public string Password { get; set; }

    }
}
