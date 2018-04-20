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
    public partial class addcust : Form
    {

        #region Paramters

        SqlConnection con = new SqlConnection(@"server=MESHO-PC\MESHO ; database=Gym ; integrated security=true");

        #endregion                              

        public addcust()
        {
            InitializeComponent();

            #region Paramters

            SqlDataAdapter da;
            DataTable dt_combo_kind = new DataTable();
            DataTable dt_combo_gender = new DataTable();

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

            #region show all Gender in combobox

            con.Open();
            dt_combo_gender.Clear();
            da = new SqlDataAdapter("SELECT Kind from Gender", con);
            da.Fill(dt_combo_gender);
            combgender.DataSource = dt_combo_gender;
            combgender.DisplayMember = ("Kind");
            con.Close();

            #endregion

        }

        private void button2_Click(object sender, EventArgs e)
        {

            #region all statements of add informations

           

            if (txtname.Text != string.Empty && txtcost.Text != string.Empty && txtfrom.Text != string.Empty && txtto.Text != string.Empty && combkind.Text != string.Empty && txtusername.Text != string.Empty && txtpass.Text != string.Empty && combgender.Text != string.Empty)
            {
                #region paramter

                DateTime dtf = Convert.ToDateTime(txtfrom.Text.ToString());
                DateTime dtt = Convert.ToDateTime(txtto.Text.ToString());
                int cos = Int32.Parse(txtcost.Text);

                #endregion
                if (dtt > dtf)
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

                    if (combgender.Text.Equals("Male      "))
                    {
                        y = 1;
                    }

                    else
                        y = 2;

                    #region paramter

                    Customers c1 = new Customers();
                    c1.Name = txtname.Text;
                    c1.cost = cos;
                    c1.froms = dtf;
                    c1.tos = dtt;
                    c1.kind_of_exer_id = x;
                    c1.Acount = txtusername.Text;
                    c1.password = txtpass.Text;
                    c1.gender_id = y;

                    #endregion

                    c1.add(c1);
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Please check your End Date");
                }
            }
            else
            {
                MessageBox.Show("Please make sure that you have entered all the information");
            }


            #endregion

        }
    }
}
