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
    public partial class edithall : Form
    {
        #region Paramters

        SqlConnection con = new SqlConnection(@"server=MESHO-PC\MESHO ; database=Gym ; integrated security=true");

        #endregion

        public edithall()
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

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            #region paramter

            Halls c1 = new Halls();
            string name = combhall.Text;

            #endregion
            dgv_search_cust.DataSource = c1.search1(name);
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region all statements of add informations

            if (combhall.Text != string.Empty)
            {

                #region paramter

                con.Open();
                string name = combhall.Text;
                Halls c1 = new Halls();
                c1.Name = txtnames.Text;

                #endregion

                c1.add1(c1);
                con.Close();
            }

            else
            {
                MessageBox.Show("Please make sure that you have entered all the information");
            }


            #endregion
        }
    }
}
