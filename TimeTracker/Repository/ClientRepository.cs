using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TimeTracker.Models;

namespace TimeTracker.Repository
{
    public class ClientRepository
    {
        private SqlConnection conn
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["LocalDbServer"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                return conn;
            }
        }

        public ClientRep get(string clientRep)
        {
            ClientRep client = new ClientRep();

            using (conn)
            {

                client = conn.Query<ClientRep>(@"SELECT Client.Id,Client.Name,Client.Address1 as address,Client.PostCode,Client.City ,Client.Country,Client.Vat FROM ClientRep
                                              JOIN Client
                                              ON ClientRep.CliendId = Client.Id
                                              WHERE concat(  ClientRep.FirstName, ' ', ClientRep.LastName ) = @name", new { name = clientRep } ).First();

                var row = conn.Query<ClientRep>(@"SELECT id, CONCAT( FirstName, ' ', LastName ) AS name FROM ClientRep 
                                        WHERE CONCAT( FirstName, ' ', LastName ) = @name", new { name = clientRep }).ToList();

                client.clientReps = new Dictionary<int, string>()
                {
                    { row[0].id , row[0].name  }
                };
                
                return client;
            }
        }
    }
}