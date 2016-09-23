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



            //var query = (from m in _dbContext.Candidates
            //             select new CandidateViewModel
            //            {
            //                CandidateName=m.CandidateName,
            //                Address=m.Address,
            //                Telephone=m.Telephone
            //            }).ToList();

            //return query;
            return null;
           
        }

        //Sasindu
        public IEnumerable<CandidateDetailedViewModel> GetPollSpecificCandidates(string poll_ID)
        {
            try
            {
                Guid pID = Guid.Parse(poll_ID);
                //List<string> candidateIDList = new List<string>();
                List<Guid> candidateList = new List<Guid>();
                candidateList = (from m in _dbContext.candidates
                                   where m.Poll_ID==pID
                                   select m.Person_ID
                             ).ToList();
                List<CandidateDetailedViewModel> Poll_candidates = new List<CandidateDetailedViewModel>();
                foreach (Guid cand in candidateList)
                {
                    Poll_candidates = (from p in _dbContext.people
                                       join s in _dbContext.students on p.Person_ID equals s.Person_ID                                       
                                       where p.Person_ID == cand 
                                       select new CandidateDetailedViewModel
                                       {
                                           FirstName = p.FirstName,
                                           LastName = p.LastName,
                                           Year = s.Year.ToString(),
                                           person_ID = p.Person_ID.ToString(),
                                           poll_ID = pID.ToString(),
                                           Address = p.Address,
                                           Telephone = p.Phone.ToString(),
                                           ImageUrl = "user.png"
                                       }).ToList();
                }


                return Poll_candidates;
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
            
        }

        public void InsertCandidate(CandidateViewModel _objCandidate)
        {
        }
    }
}
