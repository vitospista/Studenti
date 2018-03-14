using CorsoEnaip2018_SuperHeroes.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CorsoEnaip2018_SuperHeroes.DataAccess
{
    public class SuperHeroSqlRepository : IRepository<SuperHero>
    {
        private const string CONNECTION_STRING = @"Data Source=TRISRV10\SQLEXPRESS;Initial Catalog=CorsoEuris_Kraus;Integrated Security=True";

        public void Insert(SuperHero model)
        {
            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        " INSERT INTO SuperHeroes" +
                        " ([Name],[SecretName],[Birth],[Strength],[CanFly],[KilledVillains]) " +
                        " VALUES" +
                        " (@Name,@SecretName,@Birth,@Strength,@CanFly,@KilledVillains)";

                    cmd.Parameters.Add(new SqlParameter("Name", model.Name));
                    // quest'altra versione è equivalente:
                    //cmd.Parameters.AddWithValue("@Name", model.Name);

                    cmd.Parameters.Add(new SqlParameter("SecretName", model.SecretName));
                    cmd.Parameters.Add(new SqlParameter("Birth", model.Birth));
                    cmd.Parameters.Add(new SqlParameter("Strength", model.Strength));
                    cmd.Parameters.Add(new SqlParameter("CanFly", model.CanFly));
                    cmd.Parameters.Add(new SqlParameter("KilledVillains", model.KilledVillains));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool Delete(SuperHero model)
        {
            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        "DELETE FROM SuperHeroes WHERE Id = @id";

                    cmd.Parameters.Add(new SqlParameter("id", model.Id));

                    var result = cmd.ExecuteNonQuery();

                    return result == 1;
                }
            }

        }

        public SuperHero Find(int id)
        {
            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM SuperHeroes WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new SuperHero
                            {
                                Id = (int)reader[nameof(SuperHero.Id)],
                                Name = (string)reader[nameof(SuperHero.Name)],
                                SecretName = (string)reader[nameof(SuperHero.SecretName)],
                                Birth = (DateTime)reader[nameof(SuperHero.Birth)],
                                Strength = (int)reader[nameof(SuperHero.Strength)],
                                CanFly = (bool)reader[nameof(SuperHero.CanFly)],
                                KilledVillains = (int)reader[nameof(SuperHero.KilledVillains)]
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public List<SuperHero> FindAll()
        {
            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM SuperHeroes";

                    using (var reader = cmd.ExecuteReader())
                    {
                        var list = new List<SuperHero>();

                        while (reader.Read())
                        {
                            var sh = new SuperHero
                            {
                                Id = (int)reader[nameof(SuperHero.Id)],
                                Name = (string)reader[nameof(SuperHero.Name)],
                                SecretName = (string)reader[nameof(SuperHero.SecretName)],
                                Birth = (DateTime)reader[nameof(SuperHero.Birth)],
                                Strength = (int)reader[nameof(SuperHero.Strength)],
                                CanFly = (bool)reader[nameof(SuperHero.CanFly)],
                                KilledVillains = (int)reader[nameof(SuperHero.KilledVillains)]
                            };

                            list.Add(sh);
                        }

                        return list;
                    }
                }
            }      
        }

        public bool Update(SuperHero model)
        {
            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        " UPDATE SuperHeroes SET" +
                        " [Name] = @name," +
                        " [SecretName] = @secretname," +
                        " [Birth] = @birth," +
                        " [Strength] = @strength," +
                        " [CanFly] = @canfly," +
                        " [KilledVillains] = @killedvillains" +
                        " WHERE Id = @id";

                    cmd.Parameters.Add(new SqlParameter("name", model.Name));
                    cmd.Parameters.Add(new SqlParameter("secretname", model.SecretName));
                    cmd.Parameters.Add(new SqlParameter("birth", model.Birth));
                    cmd.Parameters.Add(new SqlParameter("strength", model.Strength));
                    cmd.Parameters.Add(new SqlParameter("canfly", model.CanFly));
                    cmd.Parameters.Add(new SqlParameter("killedvillains", model.KilledVillains));
                    cmd.Parameters.Add(new SqlParameter("id", model.Id));

                    var result = cmd.ExecuteNonQuery();

                    return result == 1;
                }
            }
        }
    }
}
