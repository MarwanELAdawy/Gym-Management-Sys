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
    public partial class addequip : Form
    {
        #region Paramters

        SqlConnection con = new SqlConnection(@"server=MESHO-PC\MESHO ; database=Gym ; integrated security=true");

        #endregion

        public addequip()
        {
            InitializeComponent();

            #region Paramters

            SqlDataAdapter da;
            DataTable dt_combo_kind = new DataTable();
            DataTable dt_combo_hall = new DataTable();

            #endregion

            #region show all Kind of equip or exer in combobox

            con.Open();
            dt_combo_kind.Clear();
            da = new SqlDataAdapter("SELECT kind_Name from Kind_of_equip_or_exer", con);
            da.Fill(dt_combo_kind);
            combkind.DataSource = dt_combo_kind;
            combkind.DisplayMember = ("kind_Name");
            con.Close();

            #endregion

            #region show all Halls in combobox

            con.Open();
            dt_combo_hall.Clear();
            da = new SqlDataAdapter("SELECT Halls_Name from Halls", con);
            da.Fill(dt_combo_hall);
            combhall.DataSource = dt_combo_hall;
            combhall.DisplayMember = ("Halls_Name");
            con.Close();

            #endregion

        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region all statements of add Equipments

            if (txtname.Text != string.Empty && txtcount.Text != string.Empty && combhall.Text != string.Empty && combkind.Text != string.Empty && combkind.Text != string.Empty )
            {
                int x = 0, y = 0;

                con.Open();
                if (combkind.Text.Equals("Fitness"))
                {
                    x = 1;
                }

                else if (combkind.Text.Equals("Body_Building"))
                {
                    x = 2;
                }

                else
                    x = 3;

                if (combhall.Text.Equals("Chest"))
                {
                    y = 1;
                }

                else if (combhall.Text.Equals("Back"))
                {
                    y = 2;
                }

                else if (combhall.Text.Equals("Shoulder"))
                {
                    y = 3;
                }

                else if (combhall.Text.Equals("Biceps"))
                {
                    y = 4;
                }

                else if (combhall.Text.Equals("Triceps"))
                {
                    y = 5;
                }

                else if (combhall.Text.Equals("Leg"))
                {
                    y = 6;
                }

                else
                    y = 7;

                #region paramter

                string name = txtname.Text;
                int coun = Int32.Parse(txtcount.Text);

                Equipments c1 = new Equipments();
                c1.Name = txtname.Text;
                c1.count = coun;
                c1.hall_id = y;
                c1.kind_of_exer_id = x;
                
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

        private void combkind_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtcount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void combhall_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
