using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineElection.Domain.ViewModels
{
    public class CandidateViewModel
    {
        public int ID { get; set; }
        public string CandidateName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
    }
}
