using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineElection.DAL;

namespace OnlineElection.BLL.Repository
{

    /** 
      * @desc this class will hold functions for Faculty Controller
      * @author Amila Dulanjana
      * @required OnlineElection.DAL
    */
    public class FacultyRepository : IFacultyRepository
    {

        OnlineElectionEntities _dbContext = new OnlineElectionEntities();

        /**
          * @desc Give all the Faculty details for the Controller
          * @param No
          * @return bool - success or failure
        */
        public List<Faculty> GetAllFaculty()
        {
           return _dbContext.Faculties.ToList();
           
        }

        public bool InsertFaculty()
        {
            throw new NotImplementedException();
        }

    }
}
