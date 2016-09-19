using OnlineElection.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineElection.BLL.Repository
{
    public class UserRepository : IUserRepository
    {
        OnlineElectionEntities _dbContext = new OnlineElectionEntities();
        public void RegisterUser(user user)
        {
            

            _dbContext.users.Add(user);


        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
