using OnlineElection.DAL;
using OnlineElection.Domain;
using OnlineElection.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineElection.BLL.Repository
{
    public class PollRepository : IPollRepository
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineElectionEntities2"].ConnectionString);
        OnlineElectionEntities _dbContext = new OnlineElectionEntities();
        Poll polls;
        candidate candidates;
        PollEligibleUser EligibleUser;


        /**
          * @desc Insert polls details into poll,candidate,PollEligibleUser database tables
          * @param - poll model object from controller
          * @return Json - success/Failure
        */
        public bool InsertPolls(PollModel _polls)
        {
            DateTimeFormatInfo usDtfi = new CultureInfo("en-US", false).DateTimeFormat;
            polls = new Poll();
                        
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

        /**
         * @desc Return all the details of polls to the polls Controller
         * @param - no param
         * @return List - polls details
       */
        public List<Poll> GetAllPolls()
        {
            return _dbContext.Polls.ToList();
        }

        /**
        * @desc Return all the details of Assigned candidates to the polls Controller
        * @param - (GUID) poll ID
        * @return List - AssignedCandidateDomain object
      */
        public List<AssignedCandidateDomain> GetAssignedCandidates(Guid pollID)
        {
            var AssignedCandidates = (from c in _dbContext.candidates
                                      where c.Poll_ID == pollID
                                      select new AssignedCandidateDomain
                                      {
                                          CandidateID=c.Person_ID,
                                          CandidateName = c.person.FirstName,
                                          SID = c.person.SID,
                                          Batch = c.person.batch.Name,
                                          Faculty = c.person.batch.Faculty.Name
                                      }).ToList();

            return AssignedCandidates;
        }

        public IEnumerable<PollsDetailsViewModel> GetCompletedPolls()
        {
            try
            {
                connection.Open();
                List<PollsDetailsViewModel> pollDetails = new List<PollsDetailsViewModel>();
                
                SqlCommand command = new SqlCommand("select * from Poll where [endtime] < '"+DateTime.Now+"' ", connection);
                SqlDataReader rdr = command.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        PollsDetailsViewModel poll = new PollsDetailsViewModel();

                        poll.poll_ID = rdr["ID"].ToString();
                        poll.Name = rdr["Name"].ToString();
                        poll.No_of_votes= rdr["No_of_Votes"].ToString();
                        poll.maxCandidates = rdr["max_candidates"].ToString();
                        poll.Type = rdr.GetOrdinal("Type").ToString();
                        poll.StartTime = rdr["starttime"].ToString();
                        poll.Date = rdr["poll_date"].ToString();
                        poll.EndTime = rdr["endtime"].ToString(); ;


                        pollDetails.Add(poll);
                    }
                }
                rdr.Close();
                connection.Close();
                return pollDetails;

            }
            catch (Exception)
            {

                throw;
            }           

        }

        public void InsertCandidate()
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<PollsDetailsViewModel> GetRunningPolls()
        //{


        //}

        //public IEnumerable<PollsDetailsViewModel> GetNotStartedPolls()
        //{

        //}
    }
}
