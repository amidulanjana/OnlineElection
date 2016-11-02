using OnlineElection.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineElection.BLL.Repository
{
    public class PollRepository : IPollRepository
    {
        OnlineElectionEntities _dbcontext = new OnlineElectionEntities();
        public bool createPoll(Poll _objpoll)
        {
            _dbcontext.Polls.Add(_objpoll);
            _dbcontext.SaveChanges();
            Guid id = _objpoll.ID;

            if (id == null) return false;
            return true;
        }
    }
}
