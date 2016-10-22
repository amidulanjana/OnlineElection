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
        public string dateRange { get; set; }
        public string[] Faculty { get; set; }
        public string[] Year { get; set; }
        public string[] batch { get; set; }
        public string[] candidate { get; set; }
    }
}
