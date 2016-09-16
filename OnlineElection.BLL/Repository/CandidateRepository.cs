using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineElection.Domain.ViewModels;
using OnlineElection.DAL;


namespace OnlineElection.BLL.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        OnlineElectionEntities _dbContext = new OnlineElectionEntities();

        public IEnumerable<CandidateViewModel> GetAllCandidates()
        {

           

            var query = (from m in _dbContext.Candidates
                         select new CandidateViewModel
                        {
                            CandidateName=m.CandidateName,
                            Address=m.Address,
                            Telephone=m.Telephone
                        }).ToList();

            return query;
           
        }

        public void InsertCandidate(CandidateViewModel _objCandidate)
        {
        }
    }
}
