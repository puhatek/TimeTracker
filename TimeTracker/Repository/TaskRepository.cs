using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using TimeTracker.Models;
using System.ComponentModel.DataAnnotations;

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
                List<ProjectTask> tasks = new List<ProjectTask>();
                string query = @"SELECT Project.Name projectName, Task.StartDate, Task.LeadTime, ClientRep.FirstName as clientRep, TaskStatusId FROM Task 
                                JOIN Project ON Task.ProjectId = Project.Id 
                                JOIN ClientRep ON Task.ClientRepId = ClientRep.id ";

                tasks = connection.Query<ProjectTask>(query).ToList();

                tasks.ForEach(a => a.status = GetDisplayName((Status)a.taskStatusId));

                return tasks;
            }
        }

        public void add(ProjectTask task)
        {
            Project project = projectRepo.get(task.projectName);
            ClientRep client = clientRepo.get(task.clientRep);

            using (var conn = GetConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Task (ProjectId, ClientRepID, TastStatusId,LeadTime)
                                        VALUES (@projectId, @clientrepId, @statusId, @leadTime)";
                    cmd.Parameters.AddWithValue("@projectId", project.id);
                    cmd.Parameters.AddWithValue("@clientrepId", client.clientReps.Select(a => a.Value == task.clientRep).First());
                    cmd.Parameters.AddWithValue("@statusId", (int)Status.InProgress);
                    cmd.Parameters.AddWithValue("@leadTime", task.leadTime);
                }

            }
        }

        public void start(ProjectTask task) { }


        private string GetDisplayName(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DisplayAttribute[] attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);

            if ((attributes != null) && (attributes.Length > 0))
            {
                return attributes[0].GetName();
            }
            else
            {
                return value.ToString();
            }

        }
    }
}