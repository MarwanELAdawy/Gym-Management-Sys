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
    public partial class Cust : Form
    {
        #region Paramters

        SqlConnection con = new SqlConnection(@"server=MESHO-PC\MESHO ; database=Gym ; integrated security=true");
        SqlCommand cmd;
        SqlDataReader reader;

        #endregion

        public Cust()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region show if the username and password is correct or no

            bool ok = false;
            con.Open();
            cmd = new SqlCommand("select Passwords from Customer where Acount='" + txtusername.Text + "'", con);
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string pass = reader[0].ToString();

                if (pass == txtpass.Text)
                    ok = true;
                else
                    MessageBox.Show("Password not OK !");
            }
            else
                MessageBox.Show("User Name not OK !");
            reader.Close();
            if (ok)
            {
                CustLogin f1 = new CustLogin();
                f1.ShowDialog();
                this.Close();
            }
            con.Close();

            #endregion 

        }
    }
}
