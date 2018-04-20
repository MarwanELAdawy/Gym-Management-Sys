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
    public partial class editcust : Form
    {

        #region paramter

        SqlConnection con = new SqlConnection(@"server=MESHO-PC\MESHO ; database=Gym ; integrated security=true");

        #endregion

        public editcust()
        {
            InitializeComponent();

            #region paramter

            DataTable dt_combo_kind = new DataTable();
            DataTable dt_combo_gender = new DataTable();
            SqlDataAdapter da;

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

        private void button1_Click(object sender, EventArgs e)
        {

            con.Open();

            #region paramter

            Customers c1 = new Customers();
            string name = txtname.Text;

            #endregion

            dgv_search_cust.DataSource = c1.search(name);

            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            #region all statements of edit informations

            if (txtnames.Text != string.Empty && txtcost.Text != string.Empty && txtfrom.Text != string.Empty && txtto.Text != string.Empty && combkind.Text != string.Empty && txtusername.Text != string.Empty && txtpass.Text != string.Empty && combgender.Text != string.Empty)
            {
                #region paramter

                string name = txtname.Text;
                string df = txtfrom.Text.ToString();
                string dt = txtto.Text.ToString();
                DateTime dtf = Convert.ToDateTime(df);
                DateTime dtt = Convert.ToDateTime(dt);
                int cos = Int32.Parse(txtcost.Text);
                int x = 0, y = 0;

                #endregion

                if (dtt > dtf)
                { 
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
                    c1.Name = txtnames.Text;
                    c1.cost = cos;
                    c1.froms = dtf;
                    c1.tos = dtt;
                    c1.kind_of_exer_id = x;
                    c1.Acount = txtusername.Text;
                    c1.password = txtpass.Text;
                    c1.gender_id = y;

                    #endregion

                    c1.edit(c1,name);
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
