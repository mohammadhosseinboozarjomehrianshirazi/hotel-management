using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Threading;

namespace HOTEL.Windows
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        public int LoginUserId { get; private set; } = -1;

        bool isanimationplayed = false;
        bool isanimationcompleted = false;

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            e.Cancel = !isanimationcompleted;
            if (!isanimationplayed)
            {
                isanimationplayed = true;
                ((Storyboard)FindResource("OnClosing")).Begin();
                (new Thread(new ThreadStart(()=> {
                    Thread.Sleep(600);
                    isanimationcompleted = true;
                    Dispatcher.Invoke(new Action(() => { this.Close(); }));
                }))).Start();
            }
        }

        private void MyMessageBox(string inputmessage)
        {
            MessageBoxTest.Text = inputmessage;
            ((Storyboard)FindResource("OpenMessageBox")).Begin();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        string GetUserPassRoll(string username , string password)
        {

            DataTable dt = new DataTable();
            Classes.Program.Connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM admins", Classes.Program.Connection);
            sda.Fill(dt);
            Classes.Program.Connection.Close();

            foreach (DataRow dr in dt.Rows)
                if (dr["username"].ToString() == username && dr["password"].ToString() == password)
                {
                    LoginUserId = int.Parse(dr["id"].ToString());
                    return "1";
                }
            

            return "";
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            string roll = GetUserPassRoll(Username.Text, Password.Password);
            if (roll == "")
                MyMessageBox("نام کاربری یا رمز عبور اشتباه است");
            else
            {
                this.Close();
            }
        }

        private void OKMessageBox_Click(object sender, RoutedEventArgs e)
        {
            ((Storyboard)FindResource("CloseMessageBox")).Begin();
        }
    }
}
