using OnlineElection.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineElection.BLL.Repository
{
    public interface ICandidateRepository
    {
        IEnumerable<CandidateViewModel> GetAllCandidates();
        void InsertCandidate(CandidateViewModel _objCandidate);

        //Sasindu
        IEnumerable<CandidateDetailedViewModel> GetPollSpecificCandidates(string poll_ID);
    }
}
