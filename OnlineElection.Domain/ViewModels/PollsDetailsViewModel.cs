using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineElection.Domain.ViewModels
{
    public class PollsDetailsViewModel
    {
        public string poll_ID { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Name { get; set; }
        public string Type{ get; set; }
        public string maxCandidates { get; set; }
        public string No_of_votes { get; set; }
    }
}
