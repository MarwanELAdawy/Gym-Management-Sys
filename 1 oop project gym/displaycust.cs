using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _1_oop_project_gym
{
    public partial class displaycust : Form
    {
        #region Paramters

        SqlConnection con = new SqlConnection(@"server=MESHO-PC\MESHO ; database=Gym ; integrated security=true");

        #endregion

        public displaycust()
        {
            InitializeComponent();

            con.Open();

            #region paramter

            Customers c1 = new Customers();

            #endregion

            dgv_display_cust.DataSource = c1.display();

            con.Close();

        }

        private void displaycust_Load(object sender, EventArgs e)
        {

        }

        private void dgv_display_cust_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
