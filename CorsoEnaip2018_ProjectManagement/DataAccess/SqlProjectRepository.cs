using CorsoEnaip2018_ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CorsoEnaip2018_ProjectManagement.DataAccess
{
    public class SqlProjectRepository : IRepository<Project>
    {
        public const string CONNECTION_STRING = @"Data Source=TRISRV10\SQLEXPRESS;Database=CorsoEuris_Kraus;Integrated Security=True";

        public bool Delete(Project model)
        {
            using (var conn = new SqlConnection(CONNECTION_STRING))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "project_delete";
                cmd.Parameters.AddWithValue("@id", model.Id);

                var result = cmd.ExecuteNonQuery();

                return result == 1;
            }
        }

        public Project Find(int id)
        {
            using (var conn = new SqlConnection(CONNECTION_STRING))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "project_select";
                cmd.Parameters.AddWithValue("@id", id);

                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        var p = new Project
                        {
                            Id = (int)r["Id"],
                            Name = (string)r["Name"],
                            Customer = (string)r["Customer"],
                            Manager = (string)r["Manager"],
                            StartDate = (DateTime)r["StartDate"],
                            EndDate = (DateTime)r["EndDate"],
                            DeliveryDate = (DateTime)r["DeliveryDate"],
                            Price = (decimal)r["Price"],
                            Cost = (decimal)r["Cost"],
                        };

                        return p;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public List<Project> FindAll()
        {
            using (var conn = new SqlConnection(CONNECTION_STRING))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "project_select_all";

                using (var r = cmd.ExecuteReader())
                {
                    var list = new List<Project>();

                    while (r.Read())
                    {
                        var p = new Project
                        {
                            Id = (int)r["Id"],
                            Name = (string)r["Name"],
                            Customer = (string)r["Customer"],
                            Manager = (string)r["Manager"],
                            StartDate = (DateTime)r["StartDate"],
                            EndDate = (DateTime)r["EndDate"],
                            DeliveryDate = (DateTime)r["DeliveryDate"],
                            Price = (decimal)r["Price"],
                            Cost = (decimal)r["Cost"],
                        };

                        list.Add(p);
                    }

                    return list;
                }
            }
        }

        public void Insert(Project model)
        {
            using (var conn = new SqlConnection(CONNECTION_STRING))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "project_insert";
                cmd.Parameters.AddWithValue("@name", model.Name);
                cmd.Parameters.AddWithValue("@customer", model.Customer);
                cmd.Parameters.AddWithValue("@manager", model.Manager);
                cmd.Parameters.AddWithValue("@start", model.StartDate);
                cmd.Parameters.AddWithValue("@end", model.EndDate);
                cmd.Parameters.AddWithValue("@delivery", model.DeliveryDate);
                cmd.Parameters.AddWithValue("@price", model.Price);
                cmd.Parameters.AddWithValue("@cost", model.Cost);

                cmd.ExecuteNonQuery();
            }
        }

        public bool Update(Project model)
        {
            using (var conn = new SqlConnection(CONNECTION_STRING))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "project_update";
                cmd.Parameters.AddWithValue("@id", model.Id);
                cmd.Parameters.AddWithValue("@name", model.Name);
                cmd.Parameters.AddWithValue("@customer", model.Customer);
                cmd.Parameters.AddWithValue("@manager", model.Manager);
                cmd.Parameters.AddWithValue("@start", model.StartDate);
                cmd.Parameters.AddWithValue("@end", model.EndDate);
                cmd.Parameters.AddWithValue("@delivery", model.DeliveryDate);
                cmd.Parameters.AddWithValue("@price", model.Price);
                cmd.Parameters.AddWithValue("@cost", model.Cost);

                var result = cmd.ExecuteNonQuery();

                return result == 1;
            }
        }
    }
}
