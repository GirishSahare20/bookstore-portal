using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{

    public interface IUserRepository
    {

        IEnumerable<UserInfo> GetAllUser(); 
        

    }
    public class UserRepository : IUserRepository
    {

        private readonly BookDbContext context;

        public UserRepository(BookDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<UserInfo> GetAllUser()
        {
            return context.UserInfos;
        }
    }
}
