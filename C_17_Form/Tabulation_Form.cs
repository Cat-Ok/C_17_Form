using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_17_Form
{
    public partial class Tabulation_Form : Form
    {
        public Tabulation_Form()
        {
            InitializeComponent();
        }

        private void Tabulation_Form_Load(object sender, EventArgs e)
        {

        }

        public void Add(int a,int b,double h,double equation)
        {
            C_17 form = new C_17();
            for (double i = a; i <= b; i+=h)
            {
                equation += Math.Sqrt(i * i + 1) * Math.Exp(i);
                //form.DataGridView(i, equation);
                listBox1.Items.Add(equation.ToString());
                
            }
            int lenght = listBox1.Items.Count;
            textBox1.Text = listBox1.Items[lenght - 1].ToString();
            textBox2.Text = listBox1.Items[0].ToString();
        }

        public void ResetAll()
        {
            int lenght = listBox1.Items.Count;
            for (int i = 0; i < lenght; i++)
            {
                listBox1.Items.RemoveAt(0);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
