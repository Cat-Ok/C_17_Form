using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using ZedGraph;

namespace C_17_Form
{
    public partial class C_17 : Form
    {

        #region Variables
        bool check1 = false;
        bool check6 = false;
        int file_count_member = 0;
        int b = 0;
        int a = 0;
        double equation = 0;
        Tabulation_Form form2 = new Tabulation_Form();
        Graphic_Drawing_ZedGraphControl graph = new Graphic_Drawing_ZedGraphControl();
        #endregion


        public C_17()
        {
            InitializeComponent();

            //Chart chart = new Chart();
            //chart.PointToScreen(19);
            //chart.PointToScreen((Point)19);
            //chart.Series[0].Points.Add(1);

            //Emmm em = new Emmm();
            //em.Show();

            To_File.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void outOffFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string from_file_str;
            try
            {
                StreamReader from_file = new StreamReader(@"D:\Франка\2-й курс ПМа - 22\2-й семестр\Обчислювальна Парктика\C_17\C_17_Form\C_17_Form\Reading_From_File.txt");
                int i = 0;
                do
                {
                    i++;
                    from_file_str = from_file.ReadLine();
                }
                while(i != (file_count_member+1));
                switch (from_file_str)
                {
                    case "Var 1:":
                        if(check1)
                        try
                        {
                            TextBox_Equation.Text = (from_file.ReadLine()).ToString();
                        }
                        catch (From_File_InvalidCast ex)
                        {
                            ex.Report();
                        }
                        break;

                    case "Var 6:":
                        if(check6)
                        {
                            try
                            {
                                TextBox_Equation.Text = (from_file.ReadLine()).ToString();
                            }
                            catch(From_File_InvalidCast ex)
                            {
                                ex.Report();
                            }
                        }
                        break;
                    default:
                        MessageBox.Show("Have no such variant");
                        break;
                }
                from_file.Close();
            }
            catch(From_FileNotFound ex)
            {
                ex.Report();
                
            }
                

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBox_Equation_TextChanged(object sender, EventArgs e)
        {

        }

        #region Streaming_To_File
        private void ToFile_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ToFile_checkBox.Checked == true)
            {
                To_File.Visible = true;
            }
        }

        private void To_File_Click(object sender, EventArgs e)
        {
            lock (this)
            {
                try
                {
                    StreamWriter to_file_write = new StreamWriter(@"D:\Франка\2-й курс ПМа - 22\2-й семестр\Обчислювальна Парктика\C_17\C_17_Form\C_17_Form\ToFile.txt");
                    to_file_write.WriteLine(TextBox_Equation.Text);
                    string from_dataGrid;
                    for (int i = 0; i < dataGridView_Output.Rows.Count; i++)
                    {
                        from_dataGrid = dataGridView_Output.Rows[i].Selected.ToString();
                        to_file_write.WriteLine(from_dataGrid.ToString());           
                            //to_file_write.WriteLine(A_lab.Text);
                            //to_file_write.WriteLine(B_lab.Text);
                            //to_file_write.WriteLine(H_lab.Text);
                    }

                    to_file_write.WriteLine("Your Roman Hapatyn");
                    to_file_write.Close();
                }
                catch (To_File_Time ex)
                {
                    ex.Report();
                }
                catch (To_File_Unauthorized ex)
                {
                    ex.Report();
                }
                catch (To_File_Exeption ex)
                {
                    ex.Report();
                }
            }
        }

        private void toFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToFile_checkBox.Checked = true;
            lock (this)
            {
                try
                {
                    StreamWriter to_file_write = new StreamWriter(@"D:\Франка\2-й курс ПМа - 22\2-й семестр\Обчислювальна Парктика\C_17\C_17_Form\C_17_Form\ToFile.txt");
                    to_file_write.WriteLine(TextBox_Equation.Text);
                    string from_dataGrid;
                    if (dataGridView_Output.ToString() != "System.Windows.Forms.DataGridView")
                    {
                        while ((from_dataGrid = dataGridView_Output.ToString()) != null)
                        {
                            to_file_write.WriteLine(from_dataGrid.ToString());
                        }
                        to_file_write.WriteLine(A_lab.Text);
                        to_file_write.WriteLine(B_lab.Text);
                        to_file_write.WriteLine(H_lab.Text);
                    }
                    to_file_write.WriteLine("Your Roman Hapatyn");
                    to_file_write.Close();
                }
                catch (To_File_Time ex)
                {
                    ex.Report();
                }
                catch (To_File_Unauthorized ex)
                {
                    ex.Report();
                }
                catch (To_File_Exeption ex)
                {
                    ex.Report();
                }
            }
        }
        #endregion

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            file_count_member = 1;
            check1 = true;
            equation = Math.Log(Math.Exp(a)/a);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            check6 = true;
            file_count_member = 6;
        }

        #region Label_Region
        private void A_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void B_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void H_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion

        private void calculateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if((A_textBox.Text != "") && (B_textBox.Text != "") && (H_textBox.Text != ""))
            {
                a = Convert.ToInt32(A_textBox.Text);
                b = Convert.ToInt32(B_textBox.Text);
                double h = Convert.ToDouble(H_textBox.Text);
                //DataGridViewCell cel1 = new DataGridViewTextBoxCell();
                //DataGridViewCell cel2 = new DataGridViewTextBoxCell();
                //DataGridViewRow row = new DataGridViewRow();
                
                form2.Show();   
                form2.Add(a, b, h, equation);
                //DataGridView data = new DataGridView();
                //data.DataSource = a.ToString();

                //data.Rows.Add(a, b, h);

                for (double i = a; i <= b; i += h)
                {
                    equation += Math.Sqrt(i * i + 1) * Math.Exp(i);
                    dataGridView_Output.Rows.Add(i, equation);
                }

                
               
            }
        }


        public void DataGridView(double view,double i)
        {
            dataGridView_Output.Rows.Add(i, view);
        }
        private void dataGridView_Output_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void C_17_SizeChanged(object sender, EventArgs e)
        {

        }

        #region Reset_Button
        private void Reset_AB_Click(object sender, EventArgs e)
        {
            A_textBox.Text = "";
            B_textBox.Text = "";
            H_textBox.Text = "";
            TextBox_Equation.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            A_textBox.Text = "";
            B_textBox.Text = "";
            H_textBox.Text = "";
            TextBox_Equation.Text = "";
            check1 = false;
            check6 = false;
            form2.ResetAll();
            dataGridView_Output.Rows.Clear();
            //for (int i = 0; i < dataGridView_Output.Rows.Count; i++)
            //{
            //    dataGridView_Output.Rows.RemoveAt(0);
            //}
        }
        #endregion

        private void aboutProgrammToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AboutBox 
            var about = new AboutBox1();
            about.Show();
        }

        private void Draw_but_Click(object sender, EventArgs e)
        {   
            graph.ShowDialog();
        }

    }
}
