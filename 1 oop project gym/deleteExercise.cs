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
    public partial class deleteExercise : Form
    {
        #region Paramters

        SqlConnection con = new SqlConnection(@"server=MESHO-PC\MESHO ; database=Gym ; integrated security=true");

        #endregion

        public deleteExercise()
        {
            InitializeComponent();

            #region Paramters

            SqlDataAdapter da;
            
            DataTable dt_combo_id = new DataTable();

            #endregion
            
            #region show all ID of Exercise Plane in combobox

            con.Open();
            dt_combo_id.Clear();
            da = new SqlDataAdapter("SELECT ID from [Exercise Plane]", con);
            da.Fill(dt_combo_id);
            combid.DataSource = dt_combo_id;
            combid.DisplayMember = ("ID");
            con.Close();

            #endregion

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            Exercise_Plane c1 = new Exercise_Plane();
            int id =Convert.ToInt16(combid.Text);
            c1.delete1(id);
            con.Close();
        }
    }
}
