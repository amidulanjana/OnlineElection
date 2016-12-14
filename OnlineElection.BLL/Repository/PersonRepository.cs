﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineElection.DAL;

using System.Data.Entity;
using OnlineElection.Domain.ViewModels;

namespace OnlineElection.BLL.Repository
{
    public class PersonRepository : IPersonRepository
    {
        OnlineElectionEntities _dbContext = new OnlineElectionEntities();

        public bool registerPerson(person _objPerson)
        {
            _dbContext.people.Add(_objPerson);
            _dbContext.SaveChanges();
            Guid id = _objPerson.Person_ID;

            if (id == null) return false;

            return true;

        }


        public person LoggedUser(person User)
        {

            var querySID = (from u in _dbContext.people
                            where u.SID == User.SID
                            select u.SID);


            if (querySID != null)
            {
                return (from u in _dbContext.people
                        where u.SID == User.SID
                        select u).FirstOrDefault();
            }

            return null;

        }

        public bool IsSIDAvailable(string SID)
        {

            string _sid = (from u in _dbContext.people
                           where u.SID == SID
                           select u.SID).FirstOrDefault();

            if (_sid != null) return true;

            return false;
        }

        /**
         * @desc Return all the details of people to the User Controller
         * @param - no param
         * @return List - people details
       */
        public List<person> GetAll()
        {
            return _dbContext.people.ToList();
        }

        public bool AdminApproveOrIgnore(person user)
        {
            person ToUpdatePerson = (from p in _dbContext.people
                                     where p.Person_ID == user.Person_ID
                                     select p).SingleOrDefault();
            ToUpdatePerson.AdminApproved = user.AdminApproved;

            if (_dbContext.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public bool DeleteUser(Guid ID)
        {
            person ToDeletePerson = (from p in _dbContext.people
                                     where p.Person_ID == ID
                                     select p).SingleOrDefault();
            _dbContext.people.Remove(ToDeletePerson);

            if (_dbContext.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }


        public List<AllVotedPoll> getUserVoted(Guid id)
        {
            

            List<AllVotedPoll> votedPoll = new List<AllVotedPoll>();

            List<UserVoted> candidateList = new List<UserVoted>();

            List<userVotedPoll> pollIDList = (from vp in _dbContext.votes_person
                                     where vp.Person_ID == id
                                     select new userVotedPoll
                                     {
                                         pollID=vp.Poll_ID,
                                         pollName=vp.Poll.Name
                                     }
                                ).ToList();

 
                foreach (var polls in pollIDList)
                {
                    candidateList = (from c in _dbContext.candidates
                                     where c.Poll_ID == polls.pollID
                                     select new UserVoted
                                     {
                                         candidateName=c.person.FirstName +" " + c.person.LastName,
                                         noOfVotes = c.Poll.No_of_Votes != null ? (int)c.Poll.No_of_Votes : 0,
                                         votesOfCandidate = c.vote_count != null ? (int)c.vote_count : 0,
                                         pollName = c.Poll.Name

                                     }
                                    ).ToList();
                    votedPoll.Add(new AllVotedPoll(polls.pollName, candidateList));


                }

            return votedPoll;

        }


    }
}
