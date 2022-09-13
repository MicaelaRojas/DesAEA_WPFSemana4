using System;
using System.Collections.Generic;
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
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WPFSem4
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source=ROGSTRIXG173\SQLEXPRESS;Initial Catalog=School;Integrated Security=True");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Forma Conectada Procedimiento Almacenado
            List <Person> people = new List <Person>();

            connection.Open();

            SqlCommand command = new SqlCommand("BuscarPersonaNombre", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter1 = new SqlParameter();
            parameter1.SqlDbType = SqlDbType.VarChar;
            parameter1.Size = 50;

            //parameter1.Value = txtLastName.Text. Trim();

            //parameter1.Value = "";
            //parameter1.ParameterName = "@LastName";


            SqlParameter parameter2 = new SqlParameter();
            parameter2.SqlDbType = SqlDbType.VarChar;
            parameter2.Size = 50;

            //parameter2.Value = txtFirstName.Text. Trim();

            parameter2.Value = "ia";

            parameter2.ParameterName = "@FirstName";
           
            command.Parameters.Add(parameter2);
           
            SqlDataReader dataReader = command.ExecuteReader();


            while (dataReader.Read())
            {
                people.Add(new Person
                {
                    PersonID = dataReader["PersonID"].ToString(),
                    LastName =  dataReader["LastName"].ToString(), 
                    FirstName = dataReader["FirstName"].ToString(),

                    //FullName dataReader("FullName"].ToString(),

                    FullName = string.Concat(dataReader["FirstName"].ToString(), " ",
                    
                    //Age DateDiff( DateTime.Now- Convert.ToDateTime( dataReader[2].ToString()), dataReader["LastName"].ToString()),
                    dataReader["LastName"].ToString())
                    
            });

                
            }

            connection.Close(); 
            dgvPeople.ItemsSource = people;
        }

        private void dgvPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgvPeople_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
