using OnlineElection.Domain.ViewModels;
using OnlineElection.Hubs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace OnlineElection.BLL.Repository
{
    public class MessegeRepository
    {
        readonly string _connString = ConfigurationManager.ConnectionStrings["OnlineElectionEntities2"].ConnectionString;
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineElectionEntities2"].ConnectionString);


        public IEnumerable<MessegeViewModel> GetAllMessages(string id)
        {
            

            var messages = new List<MessegeViewModel>();
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT [ID], [subject],[body], [from], [to], [date], [read] FROM [dbo].[Messege] where [to] ='" + id + "' or [from] ='" + id + "' order by [date] desc ", connection))
                {
                    command.Notification = null;

                    var dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        messages.Add(item: new MessegeViewModel { MessageID = (int)reader["ID"], from = reader["from"].ToString(), to = reader["to"].ToString() , subject = (string)reader["subject"], body = (string)reader["body"] ,read = (int)reader["read"], MessageDate = Convert.ToDateTime(reader["date"]) });
                    }
                    reader.Close();
                }


                foreach (var item in messages)
                {
                    SqlCommand cmd = new SqlCommand("select FirstName, LastName, image from person where Person_ID = '" + item.from + "'", connection);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        string name = rdr["FirstName"].ToString();
                        name = name + " " + (rdr["LastName"].ToString());

                        item.UserName = name;
                        item.UserImage = rdr["image"].ToString();
                    }


                                String ShowDateTime = null;

                                DateTime messDate = @item.MessageDate;
                                DateTime now = DateTime.Now;

                                if (messDate.Date == now.Date)
                                {
                                    var ts = (now - messDate).TotalSeconds;
                                    int dif = (int)ts;
                                    if (dif < 60)
                                    {
                                        ShowDateTime = dif + " Seconds ago";
                                    }
                                    else if (dif < 3600)
                                    {
                                        ShowDateTime = (dif/60) + " Minutes ago";
                                    }
                                    else
                                    {
                                        ShowDateTime = (dif/3600) + " Hours ago";
                                    }
                                        
                                }
                                if(messDate.Date != now.Date)
                                    {
                                        TimeSpan dt = (now.Date - messDate.Date);
                                        int t = (int)dt.TotalDays;
                                        if (t == 1)
                                        {
                                            ShowDateTime = "Yesterday";
                                        }
                                        else
                                        {
                                            ShowDateTime = messDate.ToShortDateString();
                                        }
                                    }
                    item.MessageDateString = ShowDateTime;



                    rdr.Close();
                    
                }

            }
            
            connection.Close();
            return messages;


        }

        public IEnumerable<MessegeViewModel> GetAllMessagesNew(string id)
        {


            var messages = new List<MessegeViewModel>();
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT [ID], [subject],[body], [from], [to], [date],[read] FROM [dbo].[Messege] where [to] ='" + id + "' order by [date] desc ", connection))
                {
                    command.Notification = null;

                    var dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        TimeSpan ts = DateTime.Now - Convert.ToDateTime(reader["date"]);
                        int sec = (int)ts.TotalSeconds;
                        if (sec < 20)
                        {
                            messages.Add(item: new MessegeViewModel { MessageID = (int)reader["ID"], from = reader["from"].ToString(), to = reader["to"].ToString(), subject = (string)reader["subject"], read = (int)reader["read"], body = (string)reader["body"], MessageDate = Convert.ToDateTime(reader["date"]) });
                        }
                    }
                    reader.Close();
                }


                foreach (var item in messages)
                {
                    SqlCommand cmd = new SqlCommand("select FirstName, LastName, image from person where Person_ID = '" + item.from + "'", connection);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        string name = rdr["FirstName"].ToString();
                        name = name + " " + (rdr["LastName"].ToString());

                        item.UserName = name;
                        item.UserImage = rdr["image"].ToString();
                    }


                    String ShowDateTime = null;

                    DateTime messDate = @item.MessageDate;
                    DateTime now = DateTime.Now;

                    if (messDate.Date == now.Date)
                    {
                        var ts = (now - messDate).TotalSeconds;
                        int dif = (int)ts;
                        if (dif < 60)
                        {
                            ShowDateTime = dif + " Seconds ago";
                        }
                        else if (dif < 3600)
                        {
                            ShowDateTime = (dif / 60) + " Minutes ago";
                        }
                        else
                        {
                            ShowDateTime = (dif / 3600) + " Hours ago";
                        }

                    }
                    if (messDate.Date != now.Date)
                    {
                        TimeSpan dt = (now.Date - messDate.Date);
                        int t = (int)dt.TotalDays;
                        if (t == 1)
                        {
                            ShowDateTime = "Yesterday";
                        }
                        else
                        {
                            ShowDateTime = messDate.ToShortDateString();
                        }
                    }
                    item.MessageDateString = ShowDateTime;



                    rdr.Close();

                }

            }

            connection.Close();
            return messages;


        }

        public IEnumerable<MessegeViewModel> GetConversation(int id)
        {
            List<MessegeViewModel> MessList = new List<MessegeViewModel>();
            connection.Open();
            SqlCommand command = new SqlCommand("select * from [dbo].[MessegeConv] where [ID] = " + id + " ", connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    MessList.Add(item: new MessegeViewModel { MessageID = (int)reader["ID"], from = reader["from"].ToString(), to = reader["to"].ToString(), subject = (string)reader["subject"], body = (string)reader["body"], MessageDate = Convert.ToDateTime(reader["date"]) });
                }
            }
            connection.Close();
            return MessList;
        }

        public IEnumerable<NotificationsViewModel> GetAllNotifications(string id)
        {


            var Notifs = new List<NotificationsViewModel>();
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                List<string> pollID = new List<string>();
                SqlCommand cmdn = new SqlCommand("select [PollID] from [dbo].[PollEligibleUsers] where [BatchID] = (select [batchID] from [dbo].[person] where [Person_ID]= '" + id + "')", connection);
                SqlDataReader rdr2 = cmdn.ExecuteReader();
                if (rdr2.HasRows)
                {
                    while (rdr2.Read())
                    {
                        pollID.Add(rdr2["PollID"].ToString());
                    }
                }
                rdr2.Close();

                using (var command = new SqlCommand("SELECT [PollID], [notification_type],[date], [comment] FROM [dbo].[Notifications] order by [date] desc", connection))
                {
                    command.Notification = null;

                    var dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foreach (var item in pollID)
                        {
                            if (reader["PollID"].ToString() == item)
                            {
                                Notifs.Add(item: new NotificationsViewModel { PollID = reader["PollID"].ToString(), date = reader["date"].ToString(), type = reader["notification_type"].ToString(), comment = reader["comment"].ToString() });
                            }
                        }
                    }
                    reader.Close();
                }

                foreach (var item in Notifs)
                {
                    SqlCommand cmd = new SqlCommand("select [Name] from [dbo].[Poll] where [ID] = '" + item.PollID + "' ", connection);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            item.Name = rdr["Name"].ToString();
                        }
                    }

                }

            }

            connection.Close();
            return Notifs;


        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                MessagesHub.SendMessages();
            }
        }

        public int unreadCount(string user)
        {
            try
            {   connection.Open();
                int count = 0;
                SqlCommand command = new SqlCommand("select count(*) as cnt from Messege where [to] = '" + user + "' AND [read] = '" + count + "'",connection);
                SqlDataReader rdr = command.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        count = int.Parse(rdr["cnt"].ToString());
                    }
                }
                connection.Close();
                return count;
            }
            catch (Exception)
            {

                throw;
            }
            
            

        }

       


    }
}
