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
    public partial class edittraine : Form
    {
        #region Paramters

        SqlConnection con = new SqlConnection(@"server=MESHO-PC\MESHO ; database=Gym ; integrated security=true");

        #endregion

        public edittraine()
        {
            InitializeComponent();

            #region Paramters

            SqlDataAdapter da;
            DataTable dt_combo_manage = new DataTable();
            DataTable dt_combo_hall = new DataTable();
            DataTable dt_combo_train = new DataTable();

            #endregion

            #region show all trainers in combobox

            con.Open();
            dt_combo_train.Clear();
            da = new SqlDataAdapter("SELECT Traineer_Name from Traineer", con);
            da.Fill(dt_combo_train);
            combname.DataSource = dt_combo_train;
            combname.DisplayMember = ("Traineer_Name");
            con.Close();

            #endregion

            #region show all Managers in combobox

            con.Open();
            dt_combo_manage.Clear();
            da = new SqlDataAdapter("SELECT manager_Name from Manager", con);
            da.Fill(dt_combo_manage);
            combmanage.DataSource = dt_combo_manage;
            combmanage.DisplayMember = ("manager_Name");
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

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            #region paramter

            Trainers c1 = new Trainers();
            string name = combname.Text;

            #endregion

            dgv_search_cust.DataSource = c1.search(name);

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region all statements of add Equipments

            #region paramter

            int b = int.Parse(txtbouns.Text);
            Trainers t = new Trainers();
            Trainers c2 = new Trainers();

            #endregion

            if (txtnames.Text != string.Empty && txtsalary.Text != string.Empty && combhall.Text != string.Empty && combmanage.Text != string.Empty && txtfroms.Text != string.Empty && txttos.Text != string.Empty)
            {
                #region paramter

                string name = combname.Text;
                int salary = Int32.Parse(txtsalary.Text) + Int32.Parse(txtbouns.Text);
                string dtf = txtfroms.Text;
                string dtt = txttos.Text;
                int x = 0, y = 0;

                #endregion

                 if ((dtf == "12 pm" && dtt == "8 pm") || (dtf == "8 pm" && dtt == "4 am"))
                {

                    con.Open();
                    if (combmanage.Text.Equals("Mohamed Salah Salem"))
                    {
                        x = 1;
                    }

                    else if (combmanage.Text.Equals("Marawan Mahmoud"))
                    {
                        x = 2;
                    }

                    else if (combmanage.Text.Equals("Yossief Sayed"))
                    {
                        x = 3;
                    }

                    else if (combmanage.Text.Equals("Youmna"))
                    {
                        x = 4;
                    }

                    else
                        x = 5;

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

                    Trainers c1 = new Trainers();
                    c1.Name = txtnames.Text;
                    c1.Salary = salary;
                    c1.halls_id = y;
                    c1.manager_id = x;
                    c1.froms = dtf;
                    c1.tos = dtt;

                    #endregion

                    c1.edit(c1, name);
                    con.Close();
                    }
                 else
                 {
                     MessageBox.Show("Please check trainers shift");
                 }
            }
            else
            {
                MessageBox.Show("Please make sure that you have entered all the information");
            }

            c2.Salary = int.Parse(txtsalary.Text);
            t.Salary = c2 + b;
            MessageBox.Show("Bouns =" + t.Salary);


            #endregion
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
