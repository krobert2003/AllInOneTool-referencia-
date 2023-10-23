using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AllInOneTool_referencia_
{
    public partial class AllInOneTool : Form
    {
        public AllInOneTool()
        {
            InitializeComponent();
        }

        private void AllInOneTool_Load(object sender, EventArgs e)
        {
           

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Szamologep newform = new Szamologep();
            newform.Show();
        }
     
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ToDoList newform = new ToDoList();
            newform.Show();
           
        }
        private void Idojaras_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Jegyzettomb newform = new Jegyzettomb();
            newform.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
