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

        //Sasindu
        public bool VoteStubmit(string loggedIn, string poll_id, string candidateID)
        {
            try
            {
                Guid poll = Guid.Parse(poll_id);
                Guid cand = Guid.Parse(candidateID);
                Guid user = Guid.Parse(loggedIn);
                int votecount=0;
                var _query = (from m in _dbContext.candidates
                             where (m.Person_ID == cand &&
                                m.Poll_ID == poll)
                             select m);
                foreach (var item in _query)
                {
                    votecount = (int)item.vote_count;
                }

                votecount = votecount + 1;
                
                //update candidate table with candidateID and vote count
                var query =(from ord in _dbContext.candidates
                            where (ord.Person_ID == cand &&
                                    ord.Poll_ID == poll)
                            select ord);
                
                foreach (var ord in query)
                {
                    ord.vote_count = votecount;
                }
                _dbContext.SaveChanges();


                //update vote_person table with loggedIn and poll_id
                votes_person newvotesP = new votes_person
                {
                    Person_ID = user,
                    Poll_ID = poll,
                    vote_date =  DateTime.Now
                };

                _dbContext.votes_person.Add(newvotesP);
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public void InsertCandidate(CandidateViewModel _objCandidate)
        {
        }
    }
}
