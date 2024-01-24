using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace HOTEL.Classes
{
    class Program
    {
        public static SqlConnection Connection { get; set; }
        public static string ConnectionString { get; } = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                                                            System.Windows.Forms.Application.StartupPath +
                                                            @"\MyDatabase.mdf;Integrated Security=True";

        [STAThread]
        public static void Main(string[] arg)
        {
            Connection = new SqlConnection(ConnectionString);
            Windows.Login login = new Windows.Login();
            login.ShowDialog();
            if (login.LoginUserId != -1)
            {
                Windows.MainWindow main = new Windows.MainWindow(login.LoginUserId);
                main.ShowDialog();
            }
        }
    }
}
