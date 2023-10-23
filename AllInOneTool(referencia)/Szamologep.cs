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
    public partial class Szamologep : Form
    {
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;
        public Szamologep()
        {
            InitializeComponent();
        }

        private void Szamologep_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            AllInOneTool form1 = new AllInOneTool();
            form1.ShowDialog();
            this.Close();
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((textBox_Result.Text == "0") || (isOperationPerformed))
                textBox_Result.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!textBox_Result.Text.Contains("."))
                    textBox_Result.Text = textBox_Result.Text + button.Text;

            }
            else
                textBox_Result.Text = textBox_Result.Text + button.Text;

        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;



            if (resultValue != 0)
            {
                button15.PerformClick();
                operationPerformed = button.Text;
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {

                operationPerformed = button.Text;
                if (double.TryParse(textBox_Result.Text, out resultValue))
                {
                    resultValue = Double.Parse(textBox_Result.Text);
                    labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                    isOperationPerformed = true;
                }
                else
                {

                    MessageBox.Show("Nem jó formátum");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            resultValue = 0;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                switch (operationPerformed)
                {
                    case "+":
                        textBox_Result.Text = (resultValue + Double.Parse(textBox_Result.Text)).ToString();
                        break;
                    case "-":
                        textBox_Result.Text = (resultValue - Double.Parse(textBox_Result.Text)).ToString();
                        break;
                    case "*":
                        textBox_Result.Text = (resultValue * Double.Parse(textBox_Result.Text)).ToString();
                        break;
                    case "/":
                        textBox_Result.Text = (resultValue / Double.Parse(textBox_Result.Text)).ToString();
                        break;
                    default:
                        break;
                }
                resultValue = Double.Parse(textBox_Result.Text);
                labelCurrentOperation.Text = "";

            }
            catch (FormatException ex)
            {
                MessageBox.Show("nem megfelelő formátum ");
            }

            
        }
    }
}

