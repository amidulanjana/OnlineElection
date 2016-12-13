using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineElection.Domain.ViewModels
{
    public class MessegeViewModel
    {
        public int MessageID { get; set; }

        public string UserName { get; set; }

        public string UserImage { get; set; }

        public string from { get; set; }

        public string to { get; set; }

        public string subject { get; set; }

        public string body { get; set; }

        public DateTime MessageDate { get; set; }

        public string MessageDateString { get; set; }

        public int read { get; set; }
    }
}
