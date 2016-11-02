using OnlineElection.DAL;
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
    }
}
