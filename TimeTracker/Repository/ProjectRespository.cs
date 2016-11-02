using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TimeTracker.Models;


namespace TimeTracker.Repository
{
    public class ProjectRepository
    {
        private string connectionString = "tubedapametrypolaczeniazbazadanych";
        private SqlConnection GetConnection()
        {
            var tmp = new SqlConnection(connectionString);
            tmp.Open();
            return tmp;
        }

        public void insert()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Project ID</param>
        public Project get(int id)
        {
            using (var connection = GetConnection())
            {
                return connection.Query<Project>("SELECT * FROM Projects WHERE Id = @id", id).Single();
            }
        }
         
        public Project get(string name)
        {
            using (var connection = GetConnection())
            {
                return connection.Query<Project>("SELECT * FROM Projects WHERE Id = @id", name).Single();
            }
        }


        public int update(Project data)
        {

            using (var connection = GetConnection())
            {
                return connection.Execute("UPDATE cos tam FROM Projects WHERE Id = @id", data.name);
            }
        }

        public void delete() { }



    }
}