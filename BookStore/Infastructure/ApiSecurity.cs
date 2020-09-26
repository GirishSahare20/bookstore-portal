using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Infastructure
{
    public class ApiSecurity
    {
        //private IUserRepository _userRepository;
        //public ApiSecurity(IUserRepository userRepository)
        //{
        //    _userRepository = userRepository;
        //}
        public static bool VaidateUser(string username, string password)
        {
            BookDbContext bookDb = new BookDbContext();
            IUserRepository userRepository = new UserRepository(bookDb);
            bool IsValidUser = userRepository.GetAllUser()
             .Any(u => u.Username.ToLower() == username.ToLower() && u.Password.ToLower() == password.ToLower());
  
            return IsValidUser;
        }
        public static string DecryptString(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "";
            }
            return decrypted;
        }

        public static string EnryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }
    }
}