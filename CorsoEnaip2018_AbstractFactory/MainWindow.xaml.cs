using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CorsoEnaip2018_AbstractFactory
{
    public partial class MainWindow : Window
    {
        private IRepository _repository;

        public MainWindow()
        {
            InitializeComponent();

            _repository = new Repository();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var items = _repository.FindAll();

                List.ItemsSource = items;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Impossibile recuperare gli elementi dal database! Errore: " + ex.Message);
            }
        }
    }

    interface IRepository
    {
        List<string> FindAll();
    }

    class Repository : IRepository
    {
        public List<string> FindAll()
        {
            using (var conn = new SqlConnection(@"Data Source=TRISRV10\SQLEXPRESS;Initial Catalog=CorsoEuris_Kraus;Integrated Security=True"))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM Items";

                using (var reader = cmd.ExecuteReader())
                {
                    var list = new List<string>();

                    while (reader.Read())
                    {
                        list.Add((string)reader[0]);
                    }

                    return list;
                }
            }
        }
    }

    class MockRepositoryOk : IRepository
    {
        public List<string> FindAll()
        {
            return new List<string>
            {
                "one", "two", "three",
            };
        }
    }

    class MockRepositoryFull : IRepository
    {
        public List<string> FindAll()
        {
            return new List<string>
            {
                "one", "two", "three", "one", "two", "three", "one", "two", "three", "one", "two", "three", "one", "two", "three", "one", "two", "three","one", "two", "three",
            };
        }
    }

    class MockRepositoryError : IRepository
    {
        public List<string> FindAll()
        {
            throw new TimeoutException();
        }
    }

    class DatabaseRepository : IRepository
    {
        public List<string> FindAll()
        {
            var conn = new SqlConnection("");
            var cmd = conn.CreateCommand();
            // ...

            return new List<string>();
        }
    }

    interface IRepository<T>
    {
        List<T> SelectAll();
        List<T> Select(/*... filters ...*/);
        T Select(int id);
        void Insert(T model);
        void Update(T model);
        void Delete(int id);
    }
}
