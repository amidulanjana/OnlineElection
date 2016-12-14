using OnlineElection.DAL;
using OnlineElection.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineElection.BLL.Repository
{
    public interface IPersonRepository
    {
        bool registerPerson(person _objPerson);
        List<person> GetAll();
        //List<UserVoted> getUserVoted(Guid id);
        bool DeleteUser(Guid ID);
        bool AdminApproveOrIgnore(person user);
        bool IsSIDAvailable(string SID);
        person LoggedUser(person User);
    }
}
