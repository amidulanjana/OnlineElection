using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineElection.Domain.ViewModels
{
    public class NotificationsViewModel
    {
        public string ID { get; set;}
        public string Name { get; set; }
        public string type { get; set; }
        public string date { get; set; }
        public string comment { get; set; } 
    }
}
