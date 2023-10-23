using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace AllInOneTool_referencia_
{
    public partial class Jegyzettomb : Form
    {
        public Jegyzettomb()
        {
            InitializeComponent();
        }

        private void szerkesztToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void újToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void megnyitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Open";
            open.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
                richTextBox1.LoadFile(open.FileName, RichTextBoxStreamType.PlainText);
            this.Text = open.FileName;
        }

        private void mentésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Save";
            save.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
                richTextBox1.SaveFile(save.FileName, RichTextBoxStreamType.PlainText);
            this.Text = save.FileName;
        }

        private void kilépToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void időDátumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = System.DateTime.Now.ToString();

        }

        private void előzőToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void következőToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void kivágásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void másolásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void beillesztésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void azÖsszesKijelöléseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void betűtipusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fnt = new FontDialog();
            if (fnt.ShowDialog() == DialogResult.OK)
                richTextBox1.Font = fnt.Font;


           
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog fnt = new ColorDialog();
            if (fnt.ShowDialog() == DialogResult.OK)
                richTextBox1.ForeColor = fnt.Color;
        }

        private void visszaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AllInOneTool form1 = new AllInOneTool();
            form1.ShowDialog();
            this.Close();
        }
    }
}
