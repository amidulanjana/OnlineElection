using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineElection.BLL.Repository
{
    public class StudentRepository : IStudentRepository
    {

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineElectionEntities"].ConnectionString);

        public void InsertCandidate()
        {
            throw new NotImplementedException();
        }

        public List<string> GetStudentListByFaculty(string fac)
        {
            connection.Open();
            try
            {
                List<string> stuList = new List<string>();
                SqlCommand command = new SqlCommand("select Person_ID from student where Degree_ID = (select Degree_ID from degree where Department_ID = (select Department_ID from Department where Fac_ID = (select Fac_ID from Faculty where Name ='" + fac + "' )))", connection);
                SqlDataReader rdr = command.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        stuList.Add(rdr["Person_ID"].ToString());
                    }
                }
                connection.Close();
                return stuList;
            }
            catch (Exception e)
            {

                throw;
            }
            
        }

        public List<string> GetStudentListByBatch(string batch)
        {
            connection.Open();
            try
            {
                List<string> stuList = new List<string>();
                SqlCommand command = new SqlCommand("select Person_ID from student where batch_ID = '" + batch + "' ",connection);
                SqlDataReader rdr = command.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        stuList.Add(rdr["Person_ID"].ToString());
                    }
                }
                connection.Close();
                return stuList;
            }
            catch (Exception e)
            {

                throw;
            }
            
        }
    }
}
