using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineElection.DAL;

namespace OnlineElection.BLL.Repository
{
    public class PersonRepository : IPersonRepository
    {
        OnlineElectionEntities _dbContext = new OnlineElectionEntities();
        public bool registerPerson(person _objPerson)
        {
            _dbContext.people.Add(_objPerson);
            _dbContext.SaveChanges();
            Guid id = _objPerson.Person_ID;

            if (id == null) return false;

            return true;

        }
    }
}
