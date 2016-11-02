using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TimeTracker.Models;

namespace TimeTracker.Repository
{
    public class TaskRepository
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["LocalDBServer"].ConnectionString;
        ProjectRepository projectRepo = new ProjectRepository();
        ClientRepository clientRepo = new ClientRepository();

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

        public void add(ProjectTask task)
        {
            Project project = projectRepo.get(task.projectName);
            Client client = clientRepo.get(task.clientRep); 

            using (var conn = GetConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand() )
                {
                    cmd.CommandText = @"INSERT INTO Task (ProjectId, ClientRepID, TastStatusId,LeadTime)
                                        VALUES (@projectId, @clientrepId, @statusId, @leadTime)";
                    cmd.Parameters.AddWithValue("@projectId", project.id);
                    cmd.Parameters.AddWithValue("@clientrepId", client.id);
                    cmd.Parameters.AddWithValue("@statusId", (int)Status.InProgress);
                    cmd.Parameters.AddWithValue("@leadTime", task.leadTime ); 
                }

            }
        }

        public void start(ProjectTask task) { }
    }
}