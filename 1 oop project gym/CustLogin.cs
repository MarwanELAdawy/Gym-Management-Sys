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
    public partial class CustLogin : Form
    {
        #region Paramters

        SqlConnection con = new SqlConnection(@"server=MESHO-PC\MESHO ; database=Gym ; integrated security=true");
        SqlDataAdapter da;

        #endregion

        public CustLogin()
        {
            InitializeComponent();
            
            #region show all Month in combobox

            #region Paramters

            DataTable dt_combo_month = new DataTable();

            #endregion

            con.Open();
            dt_combo_month.Clear();
            da = new SqlDataAdapter("SELECT month_number from Months", con);
            da.Fill(dt_combo_month);
            combmonth.DataSource = dt_combo_month;
            combmonth.DisplayMember = ("month_number");
            con.Close();

            #endregion

            #region show all Halls in combobox

            #region Paramters

            DataTable dt_combo_exer = new DataTable();

            #endregion

            con.Open();
            dt_combo_exer.Clear();
            da = new SqlDataAdapter("SELECT Halls_Name from Halls", con);
            da.Fill(dt_combo_exer);
            combexer.DataSource = dt_combo_exer;
            combexer.DisplayMember = ("Halls_Name");
            con.Close();

            #endregion     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region Paramters

            DataTable dt_grid_exer = new DataTable();
            SqlDataAdapter da_show_exer;

            #endregion
            
            #region show all Exercise in select Month and Exer in Datagridview form combobox

            con.Open();

            dt_grid_exer.Clear();
            da_show_exer = new SqlDataAdapter("select Equipments.equip_Name from Equipments inner join [Exercise Plane] on Equipments.ID=[Exercise Plane].equip_id inner join Months on [Exercise Plane].month_id=Months.ID inner join Halls on [Exercise Plane].halls_id=Halls.ID where Months.month_number='" + combmonth.Text + "' and Halls.Halls_Name='" + combexer.Text + "'", con);
            da_show_exer.Fill(dt_grid_exer);
            dvg_exer.DataSource = dt_grid_exer;

            con.Close();

            #endregion

        }

        private void CustLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
