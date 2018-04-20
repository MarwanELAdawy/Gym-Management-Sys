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
    public partial class addhall : Form
    {
        #region Paramters

        SqlConnection con = new SqlConnection(@"server=MESHO-PC\MESHO ; database=Gym ; integrated security=true");

        #endregion

        public addhall()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region all statements of add informations

           

            if (txtname.Text != string.Empty)
            {

                #region paramter
                
                con.Open();
                string name = txtname.Text;
                Halls c1 = new Halls();
                c1.Name = txtname.Text;

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
