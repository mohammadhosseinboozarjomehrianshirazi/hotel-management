using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace HOTEL.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int UserID { get; set; }
        public MainWindow(int id)
        {
            this.UserID = id;
            InitializeComponent();
        }
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

                (new Thread(new ThreadStart(() => {
                    Thread.Sleep(600);
                    isanimationcompleted = true;
                    Dispatcher.Invoke(new Action(() => { this.Close(); }));
                }))).Start();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        

        private void CustomerButton_Click(object sender, RoutedEventArgs e)
        {
            CustomerForm cl = new CustomerForm();
            cl.ShowDialog();
        }

        private void RoomButton_Click(object sender, RoutedEventArgs e)
        {
            RoomForm rl = new RoomForm();
            rl.ShowDialog();
        }
    }
}
