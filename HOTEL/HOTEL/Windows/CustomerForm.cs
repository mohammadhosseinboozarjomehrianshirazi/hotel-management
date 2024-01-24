using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOTEL.Windows
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
            this.Load += CustomerForm_Load;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Classes.Program.Connection.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM customer", Classes.Program.Connection);
            sda.Fill(dt);
            Classes.Program.Connection.Close();
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd=new SqlCommand("", Classes.Program.Connection);
            Classes.Program.Connection.Open();
            foreach(DataRow dr in ((DataTable)dataGridView1.DataSource).Rows)
            {
                cmd.CommandText = $"UPDATE customer SET name='{dr["name"]}',lastname='{dr["lastname"]}',nationalid='{dr["nationalid"]}',phonenumber='{dr["phonenumber"]}' WHERE Id='{dr["Id"]}'";
                cmd.ExecuteNonQuery();
            }
            Classes.Program.Connection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
