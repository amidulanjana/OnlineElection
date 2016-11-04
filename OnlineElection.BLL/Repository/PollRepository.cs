﻿using OnlineElection.DAL;
using OnlineElection.Domain;
using OnlineElection.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineElection.BLL.Repository
{
    public class PollRepository : IPollRepository
    {
        OnlineElectionEntities _dbContext = new OnlineElectionEntities();
        Poll polls;
        candidate candidates;
        PollEligibleUser EligibleUser;


        /**
          * @desc Insert polls details into poll,candidate,PollEligibleUser database tables
          * @param - poll model object from controller
          * @return Json - success/Failure
        */
        public bool InsertPolls(PollModel _polls)
        {
            DateTimeFormatInfo usDtfi = new CultureInfo("en-US", false).DateTimeFormat;
            polls = new Poll();
                        
            DateTime startDate = Convert.ToDateTime(_polls.startDate, usDtfi);
            DateTime endDate = Convert.ToDateTime(_polls.endDate, usDtfi);


            polls.Name = _polls.name;
            polls.startDate = startDate;
            polls.endDate = endDate;
            polls.Type = _polls.pollType;


            
            foreach (var candidatesID in _polls.candidateID)
            {
                candidates = new candidate();
                candidates.Person_ID = candidatesID;
                candidates.Poll = polls;
                polls.candidates.Add(candidates);
               
            }

            foreach (var batchID in _polls.batch)
            {
                EligibleUser = new PollEligibleUser();
                EligibleUser.BatchID = batchID;
                EligibleUser.Poll = polls;
                polls.PollEligibleUsers.Add(EligibleUser);
            }

            _dbContext.Polls.Add(polls);

            if (_dbContext.SaveChanges()>0 )
            {
                return true;
            }

            return false;
        }

        /**
         * @desc Return all the details of polls to the polls Controller
         * @param - no param
         * @return List - polls details
       */
        public List<Poll> GetAllPolls()
        {
            return _dbContext.Polls.ToList();
        }

        /**
        * @desc Return all the details of Assigned candidates to the polls Controller
        * @param - (GUID) poll ID
        * @return List - AssignedCandidateDomain object
      */
        public List<AssignedCandidateDomain> GetAssignedCandidates(Guid pollID)
        {
            var AssignedCandidates = (from c in _dbContext.candidates
                                      where c.Poll_ID == pollID
                                      select new AssignedCandidateDomain
                                      {
                                          CandidateID=c.Person_ID,
                                          CandidateName = c.person.FirstName,
                                          SID = c.person.SID,
                                          Batch = c.person.batch.Name,
                                          Faculty = c.person.batch.Faculty.Name
                                      }).ToList();

            return AssignedCandidates;
        }
    }
}
