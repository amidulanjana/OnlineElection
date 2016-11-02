using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineElection.DAL;
using OnlineElection.Domain.ViewModels;

namespace OnlineElection.BLL.Repository
{

    /** 
      * @desc this class will hold functions for Polls Controller
      * @author Amila Dulanjana
      * @required OnlineElection.DAL
    */
    public class FacultyRepository : IFacultyRepository
    {

        OnlineElectionEntities _dbContext = new OnlineElectionEntities();

        /**
          * @desc Give all the Faculty details for the Controller
          * @param No
          * @return List - Return Faculty table
        */
        public List<Faculty> GetAllFaculty()
        {
           return _dbContext.Faculties.ToList();
           
        }

        /**
          * @desc Give all the Batch details for the Controller
          * @param Guid - facultyID in faculty table
          * @return List - Return Batches
        */
        public List<BatchDomain> GetBatches(Guid[] ids)
        {

            var batches = (from b in _dbContext.batches
                           where ids.Contains((Guid)b.fac_ID)
                           select new BatchDomain
                           {
                               BatchID = b.batch_ID,
                               facultyD = b.fac_ID,
                               name = b.Name
                           }).ToList();

            return batches;
        }

        public bool InsertFaculty()
        {
            throw new NotImplementedException();
        }

    }
}
