using OnlineElection.Domain;
using OnlineElection.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineElection.BLL.Repository
{
    public interface IPollRepository
    {
        void InsertCandidate();
        //Sasindu
        //        IEnumerable<PollsDetailsViewModel> GetNotStartedPolls();

        ////Sasindu
        //IEnumerable<PollsDetailsViewModel> GetRunningPolls();

        ////Sasindu
        IEnumerable<PollsDetailsViewModel> GetCompletedPolls();
        bool InsertPolls(PollModel polls);
        
    }
    
}
