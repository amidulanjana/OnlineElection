using OnlineElection.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineElection.BLL.Repository
{
    public interface IPollRepository
    {
        bool InsertPolls(PollModel polls);
        
    }
}
