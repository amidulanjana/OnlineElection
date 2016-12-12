using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineElection.Domain.ViewModels
{
    public class UserVoted
    {
        public string candidateName  { get; set; }
        public int votesOfCandidate { get; set; }
        public int noOfVotes { get; set; }
        public string pollName { get; set; }
    }

    public class userVotedPoll
    {
        public Guid pollID { get; set; }
        public string pollName { get; set; }
    }


    public class AllVotedPoll
    {
        public string _pollName { get; set; }

        public List<UserVoted> _candidates { get; set; }

        public AllVotedPoll(string pollName,List<UserVoted> candidates)
        {
            _pollName = pollName;
            _candidates = candidates;
        }

    }
}
