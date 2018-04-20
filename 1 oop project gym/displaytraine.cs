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
    public partial class displaytraine : Form
    {
        #region Paramters

        SqlConnection con = new SqlConnection(@"server=MESHO-PC\MESHO ; database=Gym ; integrated security=true");

        #endregion

        public displaytraine()
        {
            InitializeComponent();

            con.Open();

            #region paramter

            Trainers c1 = new Trainers();

            #endregion

            dgv_display_cust.DataSource = c1.display();
            con.Close();

        }

        private void displaytraine_Load(object sender, EventArgs e)
        {

        }
    }
}
