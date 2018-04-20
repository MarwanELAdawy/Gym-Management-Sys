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
    public partial class displayhall : Form
    {
        #region Paramters

        SqlConnection con = new SqlConnection(@"server=MESHO-PC\MESHO ; database=Gym ; integrated security=true");

        #endregion

        public displayhall()
        {
            InitializeComponent();
            con.Open();

            #region paramter

            Halls c1 = new Halls();

            #endregion

            dgv_display_cust.DataSource = c1.display1();

            con.Close();
        }

        private void displayhall_Load(object sender, EventArgs e)
        {

        }
    }
}
