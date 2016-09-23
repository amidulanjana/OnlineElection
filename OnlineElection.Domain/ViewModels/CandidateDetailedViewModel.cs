using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineElection.Domain.ViewModels
{
    public class CandidateDetailedViewModel
    {
        public string person_ID { get; set; }
        public string poll_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Year { get; set; }
        public string Sem { get; set; }
        public string degree { get; set; }
        public string Telephone { get; set; }
        public string ImageUrl { get; set; }
    }
}
