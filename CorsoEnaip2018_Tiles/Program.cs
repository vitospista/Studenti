using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Tiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string customer = "Generali";
            double meters = 146.7;
            double pack = 5; //square meters per package
            double packPrice = 299.99;

            double requiredPackages = meters / pack;

            double ceiledPackages = Math.Ceiling(requiredPackages);

            double price = ceiledPackages * packPrice;

            Console.WriteLine("Preventivo: " + price);

            // vorrei un metodo di select che mi restituisca 4 valori.
            // ma i metodi possono restituire un valore solo!
            // quindi un codice come il seguente non esiste!
            // (meters, pack, packPrice, customer) = SelectWithId(3);

            // devo creare delle strutture-dati che INCASPULANO le informazioni

            Estimate e = SelectWithId(3);

            Console.Read();
        }

        static void InsertOnDatabase(
            double meters, double pack, double packPrice, string customer)
        {
            string connectionString = @"Data Source=TRISRV10\SQLEXPRESS;Initial Catalog=CorsoEuris_Kraus;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            // la stringa a mano è pericolosa!
            //command.CommandText = "insert into Tiles (meters,pack,packPrice,customer) values (" + meters + "," + pack + "," + packPrice + ",'" + customer + "');";

            command.Parameters.Add(new SqlParameter("meters", meters));
            command.Parameters.Add(new SqlParameter("pack", pack));
            command.Parameters.Add(new SqlParameter("packPrice", packPrice));
            command.Parameters.Add(new SqlParameter("customer", customer));
            command.CommandText =
                "insert into Tiles (meters, pack, packPrice, customer) "
                + "values (@meters,@pack,@packPrice,@customer);";

            Console.WriteLine("La query è: " + command.CommandText);

            int affectedRows = command.ExecuteNonQuery();

            Console.WriteLine("Righe aggiunte: " + affectedRows);

            conn.Close();
        }

        static Estimate SelectWithId(int id)
        {
            string connectionString = @"Data Source=TRISRV10\SQLEXPRESS;Initial Catalog=CorsoEuris_Kraus;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("id", id));
            command.CommandText =
                "select meters, pack, packPrice, customer from Tiles"
                + " where id = @id;";

            Console.WriteLine("La query è: " + command.CommandText);

            SqlDataReader reader = command.ExecuteReader();

            reader.Read();

            Estimate e = new Estimate();

            e.meters = (double)reader.GetDecimal(0);
            e.pack = (double)reader.GetDecimal(1);
            e.packPrice = (double)reader.GetDecimal(2);
            e.customer = reader.GetString(3);

            conn.Close();

            return e;
        }
    }

    class Estimate
    {
        public double meters;
        public double pack;
        public double packPrice;
        public string customer;
    }
}
