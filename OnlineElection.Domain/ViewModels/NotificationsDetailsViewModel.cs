using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineElection.Domain.ViewModels
{
    public class NotoficationsDetailsViewModel
    {
        public string poll_ID { get; set; }
        public string Date { get; set; }
        public string type { get; set; }
        public string comment { get; set; }
    }
}
