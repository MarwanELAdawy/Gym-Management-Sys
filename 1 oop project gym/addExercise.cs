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
    public partial class addExercise : Form
    {
        #region Paramters

        SqlConnection con = new SqlConnection(@"server=MESHO-PC\MESHO ; database=Gym ; integrated security=true");

        #endregion

        public addExercise()
        {
            InitializeComponent();

            #region Paramters

            SqlDataAdapter da;
            DataTable dt_combo_equip = new DataTable();
            DataTable dt_combo_hall = new DataTable();
            DataTable dt_combo_month = new DataTable();

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

            #region show all Equipments in combobox

            con.Open();
            dt_combo_equip.Clear();
            da = new SqlDataAdapter("SELECT equip_Name from Equipments", con);
            da.Fill(dt_combo_equip);
            combequip.DataSource = dt_combo_equip;
            combequip.DisplayMember = ("equip_Name");
            con.Close();

            #endregion

            #region show all Month in combobox

            con.Open();
            dt_combo_month.Clear();
            da = new SqlDataAdapter("SELECT month_number from Months", con);
            da.Fill(dt_combo_month);
            combmonth.DataSource = dt_combo_month;
            combmonth.DisplayMember = ("month_number");
            con.Close();

            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region all statements of add Equipments

            if (combhall.Text != string.Empty && combequip.Text != string.Empty && combmonth.Text != string.Empty)
            {
                int x = 0, y = 0, z = 0;

                con.Open();

                #region check of halls

                if (combhall.Text.Equals("Chest"))
                {
                    x = 1;
                }

                else if (combhall.Text.Equals("Back"))
                {
                    x = 2;
                }

                else if (combhall.Text.Equals("Shoulder"))
                {
                    x = 3;
                }

                else if (combhall.Text.Equals("Biceps"))
                {
                    x = 4;
                }

                else if (combhall.Text.Equals("Triceps"))
                {
                    x = 5;
                }

                else if (combhall.Text.Equals("Leg"))
                {
                    x = 6;
                }

                else
                    x = 7;

                #endregion

                #region check of Equipments

                if (combequip.Text.Equals("Barbell Bench Press"))
                {
                    y = 1;
                }

                else if (combequip.Text.Equals("Flat Bench Dumbbell Press"))
                {
                    y = 2;
                }

                else if (combequip.Text.Equals("Low-Incline Barbell Bench Press"))
                {
                    y = 3;
                }

                else if (combequip.Text.Equals("Machine Decline Press"))
                {
                    y = 4;
                }

                else if (combequip.Text.Equals("Seated Machine Chest Press"))
                {
                    y = 5;
                }

                else if (combequip.Text.Equals("Incline Dumbbell Press"))
                {
                    y = 6;
                }

                else if (combequip.Text.Equals("Dips For Chest"))
                {
                    y = 7;
                }

                else if (combequip.Text.Equals("Incline Bench Cable Fly"))
                {
                    y = 8;
                }

                else if (combequip.Text.Equals("Over"))
                {
                    y = 9;
                }

                else
                    y = 10;

                #endregion

                #region check of Months

                if (combmonth.Text.Equals("Month_1"))
                {
                    z = 1;
                }

                else if (combmonth.Text.Equals("Month_2"))
                {
                    z = 2;
                }

                else
                    z = 3;

                #endregion
            
                #region paramter

                Exercise_Plane c1 = new Exercise_Plane();
                c1.halls_id = x;
                c1.equip_id = y;
                c1.month_id = z;

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
