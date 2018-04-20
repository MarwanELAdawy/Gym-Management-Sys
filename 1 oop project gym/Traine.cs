using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1_oop_project_gym
{
    public partial class Traine : Form
    {
        public Traine()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addcust f1 = new addcust();
            f1.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            editcust f1 = new editcust();
            f1.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deletecust f1 = new deletecust();
            f1.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            displaycust f1 = new displaycust();
            f1.ShowDialog();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            addExercise f1 = new addExercise();
            f1.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            editExercise f1 = new editExercise();
            f1.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            deleteExercise f1 = new deleteExercise();
            f1.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            displayExercise f1 = new displayExercise();
            f1.ShowDialog();
            this.Close();
        }
    }
}
