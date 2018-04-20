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
    public partial class deletehall : Form
    {
        #region Paramters

        SqlConnection con = new SqlConnection(@"server=MESHO-PC\MESHO ; database=Gym ; integrated security=true");

        #endregion
        public deletehall()
        {
            InitializeComponent();

            #region paramter

            DataTable dt_combo_hall = new DataTable();
            SqlDataAdapter da;

            #endregion

            #region show all Halls Name combobox

            con.Open();
            dt_combo_hall.Clear();
            da = new SqlDataAdapter("SELECT Halls_Name from Halls", con);
            da.Fill(dt_combo_hall);
            combhall.DataSource = dt_combo_hall;
            combhall.DisplayMember = ("Halls_Name");
            con.Close();

            #endregion

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            Halls c1 = new Halls();
            string name = combhall.Text;
            c1.delete1(name);
            con.Close();
        }
    }
}
