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

                         select m).ToList();

            //return query;
            //select new CandidateViewModel {
            //CandidateName = m.
            //}).to;

            throw new NotImplementedException();

            
            //all database queries goes here

        }

        public void InsertCandidate(CandidateViewModel _objCandidate)
        {
        }
    }
}
