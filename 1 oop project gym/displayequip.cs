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
    public partial class displayequip : Form
    {
        #region Paramters

        SqlConnection con = new SqlConnection(@"server=MESHO-PC\MESHO ; database=Gym ; integrated security=true");

        #endregion

        public displayequip()
        {
            InitializeComponent();

            con.Open();

            #region paramter

            Equipments c1 = new Equipments();

            #endregion

            dgv_display_equip.DataSource = c1.display1();

            con.Close();
        }

        private void displayequip_Load(object sender, EventArgs e)
        {

        }
    }
}
