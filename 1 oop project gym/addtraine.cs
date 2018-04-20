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
    public partial class addtraine : Form
    {
        #region Paramters

        SqlConnection con = new SqlConnection(@"server=MESHO-PC\MESHO ; database=Gym ; integrated security=true");

        #endregion

        public addtraine()
        {
            InitializeComponent();

            #region Paramters

            SqlDataAdapter da;
            DataTable dt_combo_manage = new DataTable();
            DataTable dt_combo_hall = new DataTable();

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

        private void button2_Click(object sender, EventArgs e)
        {
            #region all statements of add Equipments

            if (txtname.Text != string.Empty && txtsalary.Text != string.Empty && combhall.Text != string.Empty && combmanage.Text != string.Empty && txtfrom.Text != string.Empty && txtto.Text != string.Empty)
            {
                #region paramter

                string name = txtname.Text;
                int salary = Int32.Parse(txtsalary.Text);
                string dtf = txtfrom.Text;
                string dtt = txtto.Text;
                #endregion

                if ((dtf == "12 pm" && dtt == "8 pm") || (dtf == "8 pm" && dtt == "4 am"))
                {

                    int x = 0, y = 0;

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
                    c1.Name = txtname.Text;
                    c1.Salary = salary;
                    c1.halls_id = y;
                    c1.manager_id = x;
                    c1.froms = dtf;
                    c1.tos = dtt;


                    #endregion

                    c1.add(c1);
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

            

            #endregion
        }

        private void addtraine_Load(object sender, EventArgs e)
        {

        }
    }
}
