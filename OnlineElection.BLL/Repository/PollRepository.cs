using OnlineElection.DAL;
using OnlineElection.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineElection.BLL.Repository
{
    public class PollRepository : IPollRepository
    {
        OnlineElectionEntities _dbContext = new OnlineElectionEntities();
        Poll polls;
        candidate candidates;
        PollEligibleUser EligibleUser;


        /**
          * @desc Insert polls details into poll,candidate,PollEligibleUser database tables
          * @param poll model from controller
          * @return Json - success/Failure
        */
        public bool InsertPolls(PollModel _polls)
        {
            DateTimeFormatInfo usDtfi = new CultureInfo("en-US", false).DateTimeFormat;
            polls = new Poll();
            
            //candidates = new candidate();
            
            DateTime startDate = Convert.ToDateTime(_polls.startDate, usDtfi);
            DateTime endDate = Convert.ToDateTime(_polls.endDate, usDtfi);


            polls.Name = _polls.name;
            polls.startDate = startDate;
            polls.endDate = endDate;
            polls.Type = _polls.pollType;


            
            foreach (var candidatesID in _polls.candidateID)
            {
                candidates = new candidate();
                candidates.Person_ID = candidatesID;
                candidates.Poll = polls;
                polls.candidates.Add(candidates);
               
            }

            foreach (var batchID in _polls.batch)
            {
                EligibleUser = new PollEligibleUser();
                EligibleUser.BatchID = batchID;
                EligibleUser.Poll = polls;
                polls.PollEligibleUsers.Add(EligibleUser);
            }

            _dbContext.Polls.Add(polls);

            if (_dbContext.SaveChanges()>0 )
            {
                return true;
            }

            return false;
        }
    }
}
