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
    public partial class deleteequip : Form
    {
        #region Paramters

        SqlConnection con = new SqlConnection(@"server=MESHO-PC\MESHO ; database=Gym ; integrated security=true");
        DataTable dt_combo_equip = new DataTable();

        #endregion

        public deleteequip()
        {
            InitializeComponent();

            #region Paramters

            SqlDataAdapter da;

            #endregion

            #region show all Equipments in combobox

            con.Open();
            dt_combo_equip.Clear();
            da = new SqlDataAdapter("SELECT equip_Name from Equipments", con);
            da.Fill(dt_combo_equip);
            combname.DataSource = dt_combo_equip;
            combname.DisplayMember = ("equip_Name");
            con.Close();

            #endregion

        }

        private void deleteequip_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            Equipments c1 = new Equipments();
            string name = combname.Text;
            c1.delete1(name);
            con.Close();
        }

        private void combname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
