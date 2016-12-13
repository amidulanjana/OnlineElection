using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineElection.Domain.ViewModels
{
    public class BatchDomain
    {
        public Guid BatchID { get; set; }
        public Guid? facultyD { get; set; }
        public string name { get; set; }
        public string FacultyName { get; set; }
    }
}
