using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineElection.Domain
{
    public class PollModel
    {
        public string pollType { get; set; }
        public string name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string[] Faculty { get; set; }
        public string[] Year { get; set; }
        public Guid[] batch { get; set; }
        public Guid[] candidateID { get; set; }

    }
}
