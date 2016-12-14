﻿using OnlineElection.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineElection.BLL.Repository
{
    public class BatchRepository:IBatchRepository
    {
        
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineElectionEntities2"].ConnectionString);
        StudentRepository _studentRepository = new StudentRepository();
        //Sasindu
        public IEnumerable<BatchDetailsViewModel> GetFOCBatchDetails()
        {
            try
            {
                connection.Open();

                List<BatchDetailsViewModel> batchDetails = new List<BatchDetailsViewModel>();
                string faculty = "Computing";
                SqlCommand command = new SqlCommand("select * from batch where fac_ID = (select Fac_ID from Faculty where Name = '"+ faculty + "' )",connection);
                SqlDataReader rdr = command.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        BatchDetailsViewModel batch = new BatchDetailsViewModel();

                        batch.batch_ID = rdr["batch_ID"].ToString();
                        batch.fac_ID = rdr["fac_ID"].ToString();
                        batch.Name = rdr["Name"].ToString();
                        batch.Year = rdr["Year"].ToString();


                        batchDetails.Add(batch);
                    }
                }
                rdr.Close();
                connection.Close();
                return batchDetails;
                
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }

        }

        //Sasindu
        public IEnumerable<BatchDetailsViewModel> GetFOBBatchDetails()
        {
            try
            {
                connection.Open();

                List<BatchDetailsViewModel> batchDetails = new List<BatchDetailsViewModel>();
                string faculty = "Business";
                SqlCommand command = new SqlCommand("select * from batch where fac_ID = (select Fac_ID from Faculty where Name = '" + faculty + "' )", connection);
                SqlDataReader rdr = command.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        BatchDetailsViewModel batch = new BatchDetailsViewModel();

                        batch.batch_ID = rdr["batch_ID"].ToString();
                        batch.fac_ID = rdr["fac_ID"].ToString();
                        batch.Name = rdr["Name"].ToString();
                        batch.Year = rdr["Year"].ToString();


                        batchDetails.Add(batch);
                    }
                }
                rdr.Close();
                connection.Close();
                return batchDetails;

            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }

        }

        //Sasindu
        public IEnumerable<BatchDetailsViewModel> GetFOEBatchDetails()
        {
            try
            {
                connection.Open();

                List<BatchDetailsViewModel> batchDetails = new List<BatchDetailsViewModel>();
                string faculty = "engineering";
                SqlCommand command = new SqlCommand("select * from batch where fac_ID = (select Fac_ID from Faculty where Name = '" + faculty + "' )", connection);
                SqlDataReader rdr = command.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        BatchDetailsViewModel batch = new BatchDetailsViewModel();

                        batch.batch_ID = rdr["batch_ID"].ToString();
                        batch.fac_ID = rdr["fac_ID"].ToString();
                        batch.Name = rdr["Name"].ToString();
                        batch.Year = rdr["Year"].ToString();


                        batchDetails.Add(batch);
                    }
                }
                rdr.Close();
                connection.Close();
                return batchDetails;

            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }

        }


        //Sasindu
        public bool sendMessege(List<string> results,string subject, string body)
        {
            bool result = false;
            try
            {
                List<string> UserList = new List<string>();
                connection.Open();
                foreach (var item in results)
                {
                    if (item == "foc")
                    {
                        List<string> stu = _studentRepository.GetStudentListByFaculty("foc");
                        foreach (var it in stu)
                        {
                            UserList.Add(it);
                        }
                    }
                    else if (item == "fob")
                    {
                        List<string> stu = _studentRepository.GetStudentListByFaculty("fob");
                        foreach (var it in stu)
                        {
                            UserList.Add(it);
                        }
                    }
                    else if (item == "foe")
                    {
                        List<string> stu = _studentRepository.GetStudentListByFaculty("foe");
                        foreach (var it in stu)
                        {
                            UserList.Add(it);
                        }
                    }
                    else
                    {
                        List<string> stu = _studentRepository.GetStudentListByBatch(item);
                        foreach (var it in stu)
                        {
                            UserList.Add(it);
                        }
                    }
                }



                
                //Please Take the loggedIn Admin LoggedIn ID
                string UserFrom = "21781dd9-4a1c-4dfb-933f-21633b94b61b";

                
                foreach (var item in UserList)
                {
                    DateTime date = DateTime.Now;
                    
                    SqlCommand newcmd = new SqlCommand("select * from Messege where ([from] = '"+UserFrom+"' AND [to] = '"+item+ "') or ([from] = '" + item + "' AND [to] = '" + UserFrom + "')", connection);
                    int count = Convert.ToInt32(newcmd.ExecuteScalar());
                    SqlDataReader rdr = newcmd.ExecuteReader();
                    List<int> MessIDs = new List<int>();
                    int messgeID = 0;
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            MessIDs.Add((int)rdr["ID"]);
                            messgeID = (int)rdr["ID"];


                        }
                        
                    }
                    rdr.Close();

                    foreach (int no in MessIDs)
                    {
                        SqlCommand comm = new SqlCommand("update Messege set Subject = '" + subject + "', body = '" + body + "', date = '" + date + "' where ID = " + no + " ", connection);
                        comm.ExecuteNonQuery();
                        
                    }
                    

                    if (count== 0)
                    {
                        //change ID to AutoIncrement
                        SqlCommand command2 = new SqlCommand("insert into Messege([date],[from],[to],[subject],[body],[read]) values ('" + date + "','" + UserFrom + "','" + item + "','" + subject + "','" + body + "',"+0+")", connection);
                        command2.ExecuteNonQuery();

                        SqlCommand cmmnd = new SqlCommand("select * from Messege where ([from] = '" + UserFrom + "' AND [to] = '" + item + "') or ([from] = '" + item + "' AND [to] = '" + UserFrom + "')", connection);
                        int co = Convert.ToInt32(cmmnd.ExecuteScalar());
                        co++;
                        
                        
                        messgeID = co;
                    }

                    //change ID to AutoIncrement
                     SqlCommand command3 = new SqlCommand("insert into MessegeConv values ('" + messgeID + "','" + date + "','" + UserFrom + "','" + item + "','" + subject + "','" + body + "'," + 0 + ")", connection);
                    command3.ExecuteNonQuery();
                }
                



                connection.Close();
                result = true;
                return result;

            }
            catch (Exception e)
            {

                throw new NotImplementedException();
            }

        }




    }
}