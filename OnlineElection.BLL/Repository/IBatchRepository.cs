using OnlineElection.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineElection.BLL.Repository
{
    public interface IBatchRepository
    {
        //Sasindu
        IEnumerable<BatchDetailsViewModel> GetFOCBatchDetails();

        IEnumerable<BatchDetailsViewModel> GetFOBBatchDetails();

        IEnumerable<BatchDetailsViewModel> GetFOEBatchDetails();

        bool sendMessege(List<string> results,string subject, string body);
    }
}
