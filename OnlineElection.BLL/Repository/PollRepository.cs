using OnlineElection.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineElection.BLL.Repository
{
    public class PollRepository : IPollRepository
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineElectionEntities"].ConnectionString);

        public void InsertCandidate()
        {
            throw new NotImplementedException();
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

                        poll.poll_ID = rdr.GetOrdinal("ID").ToString();
                        poll.Name = rdr.GetOrdinal("Name").ToString();
                        poll.No_of_votes= rdr.GetString(rdr.GetOrdinal("No_of_Votes"));
                        poll.maxCandidates = rdr.GetOrdinal("max_candidates").ToString();
                        poll.Type = rdr.GetOrdinal("Type").ToString();
                        poll.StartTime = rdr.GetOrdinal("starttime").ToString();
                        poll.Date = rdr.GetString(rdr.GetOrdinal("poll_date"));
                        poll.EndTime = rdr.GetString(rdr.GetOrdinal("endtime"));


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

        //public IEnumerable<PollsDetailsViewModel> GetRunningPolls()
        //{


        //}

        //public IEnumerable<PollsDetailsViewModel> GetNotStartedPolls()
        //{

        //}
    }
}
