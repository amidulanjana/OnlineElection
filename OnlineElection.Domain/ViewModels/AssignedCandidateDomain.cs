using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineElection.Domain.ViewModels
{
    public class AssignedCandidateDomain
    {
        public Guid CandidateID { get; set; }
        public string CandidateName { get; set; }
        public string SID { get; set; }
        public string Faculty { get; set; }
        public string Batch { get; set; }
    }
}
