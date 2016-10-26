using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineElection.Domain.ViewModels
{
    public class BatchDetailsViewModel
    {
        public string batch_ID { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public string fac_ID { get; set; }
    }
}