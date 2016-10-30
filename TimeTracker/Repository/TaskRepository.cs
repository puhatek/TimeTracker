using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TimeTracker.Models;

namespace TimeTracker.Repository
{
    public class TaskRepository
    {
        private string connectionString = @"Server=DESKTOP-QPSPDBH;Database=TimeTracker;Integrated Security=True;";

        private SqlConnection GetConnection()
        {
            var conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        public List<ProjectTask> get()
        {
            using (var connection = GetConnection())
            {
                string query = @"SELECT Project.Name projectName, Task.StartDate, Task.LeadTime, TaskStatus.Name as status, ClientRep.FirstName as clientRep FROM Task 
                                JOIN Project ON Task.ProjectId = Project.Id 
                                JOIN ClientRep ON Task.ClientRepId = ClientRep.id 
                                JOIN TaskStatus ON Task.TaskStatusId = TaskStatus.id";
                return connection.Query<ProjectTask>(query).ToList();
            }
        }


    }
}