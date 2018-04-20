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
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();

            #region Paramters

            SqlConnection con = new SqlConnection(@"server=MESHO-PC\MESHO ; database=Gym ; integrated security=true");
            DataTable dt_grid_trainer = new DataTable();
            SqlDataAdapter da_show_trainer;

            #endregion

            #region show all Exercise in select Month and Exer in Datagridview form combobox

            con.Open();

            // the second is very correct becuse  change when select another Exer or Month
            dt_grid_trainer.Clear();
            da_show_trainer = new SqlDataAdapter("select Traineer.Traineer_Name,Halls.Halls_Name,Traineer.Froms,Traineer.Tos from Traineer inner join Halls on Halls.ID=Traineer.halls_id", con);
            da_show_trainer.Fill(dt_grid_trainer);
            dvg_trainer.DataSource = dt_grid_trainer;

            con.Close();

            #endregion

        }

        private void button1_Click(object sender, EventArgs e)
        {    
            Cust f1 = new Cust();
            f1.ShowDialog();
           // this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Traine f1 = new Traine();
            f1.ShowDialog();
            //this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Manage f1 = new Manage();
            f1.ShowDialog();
            //this.Close();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {

        }
    }
}
