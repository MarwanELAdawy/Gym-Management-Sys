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
    public partial class Manage : Form
    {
        public Manage()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            addequip f1 = new addequip();
            f1.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            editequip f1 = new editequip();
            f1.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            deleteequip f1 = new deleteequip();
            f1.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            displayequip f1 = new displayequip();
            f1.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addtraine f1 = new addtraine();
            f1.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            edittraine f1 = new edittraine();
            f1.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deletetraine f1 = new deletetraine();
            f1.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            displaytraine f1 = new displaytraine();
            f1.ShowDialog();
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            addhall f1 = new addhall();
            f1.ShowDialog();
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            edithall f1 = new edithall();
            f1.ShowDialog();
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            deletehall f1 = new deletehall();
            f1.ShowDialog();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            displayhall f1 = new displayhall();
            f1.ShowDialog();
            this.Close();
        }
    }
}
