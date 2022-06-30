using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace WindowsFormsSortMyList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        vector<int> vecI = new vector<int>();
        vector<int> vecI1;

        vector<double> vecD = new vector<double>();
        vector<double> vecD1;

        vector<string> vecS = new vector<string>();
        vector<string> vecS1;

        private void button1_Click(object sender, EventArgs e)
        {//формирование двух целых одинаковых списков 
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            
           
            textBox6.Clear();
            textBox7.Clear();
            textBox9.Clear();
            textBox10.Clear();

            if (vecI.Length != 0)
                vecI.clear();

            int n = int.Parse(textBox1.Text);
            

            vecI = Utilities<int>.RandomInt(n);
            vecI1 = Utilities<int>.Copy(vecI);
            for (int i = 0; i < vecI.Length; i++)
            {
                listBox1.Items.Add(vecI[i].Element.ToString());
            }
        }
    
           
        private void button2_Click(object sender, EventArgs e)
        {

            sortingQuick<int> sortQuick = new sortingQuick<int>();
            vector<int> sorted = Utilities<int>.SortVar(vecI, sortQuick);//!!!!!!!!!!!
            for (int i = 0; i < sorted.Length; i++)
            {
                listBox2.Items.Add(sorted[i].Element.ToString());
            }
          
            textBox6.Text = sortQuick.comparison.ToString();
            textBox7.Text = sortQuick.shift.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sortingMerge<int> sortMerge = new sortingMerge<int>();
            vector<int> sorted = Utilities<int>.SortVar(vecI1, sortMerge);//!!!!!!!!!!!
            for (int i = 0; i < sorted.Length; i++)
            {
                listBox3.Items.Add(sorted[i].Element.ToString());
            }

            textBox9.Text = sortMerge.comparison.ToString();
            textBox10.Text = sortMerge.shift.ToString();
            
        }

     



        private void button6_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox14.Clear();
            textBox15.Clear();

            if (vecD.Length != 0)
                vecD.clear();

            int n = int.Parse(textBox20.Text);

            
            vecD = Utilities<double>.RandomDouble(n);
           
            vecD1 = Utilities<double>.Copy(vecD);
            for (int i = 0; i < vecD.Length; i++)
            {
                listBox4.Items.Add(vecD[i].Element.ToString());
            }
        }

       

        private void button5_Click(object sender, EventArgs e)
        {
            sortingQuick<double> sortQuick = new sortingQuick<double>();
            vector<double> sorted = Utilities<double>.SortVar(vecD, sortQuick);//!!!!!!!!!!!

            for (int i = 0; i < sorted.Length; i++)
            {
                listBox5.Items.Add(sorted[i].Element.ToString());
            }
            textBox15.Text = sortQuick.comparison.ToString();
            textBox14.Text = sortQuick.shift.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sortingMerge<double> sortMerge = new sortingMerge<double>();
            vector<double> sorted = Utilities<double>.SortVar(vecD1, sortMerge);//!!!!!!!!!!!


            for (int i = 0; i < sorted.Length; i++)
            {
                listBox6.Items.Add(sorted[i].Element.ToString());
            }
            textBox12.Text = sortMerge.comparison.ToString();
            textBox11.Text = sortMerge.shift.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox7.Items.Clear();
            listBox8.Items.Clear();
            listBox9.Items.Clear();
            textBox18.Clear();
            textBox19.Clear();
            textBox22.Clear();
            textBox23.Clear();
            if (vecS.Length != 0)
                vecS.clear();

            int n = int.Parse(textBox26.Text);

           
            vecS = Utilities<string>.RandomString(n);
            vecS1 = Utilities<string>.Copy(vecS);
            for (int i = 0; i < vecS.Length; i++)
            {
                listBox7.Items.Add(vecS[i].Element.ToString());
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            sortingQuick<string> sortQuick = new sortingQuick<string>();
            vector<string> sorted = Utilities<string>.SortVar(vecS, sortQuick);//!!!!!!!!!!!

            for (int i = 0; i < sorted.Length; i++)
            {
                listBox8.Items.Add(sorted[i].Element.ToString());
            }
            textBox23.Text = sortQuick.comparison.ToString();
            textBox22.Text = sortQuick.shift.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            sortingMerge<string> sortMerge = new sortingMerge<string>();
            vector<string> sorted = Utilities<string>.SortVar(vecS1, sortMerge);//!!!!!!!!!!!
            for (int i = 0; i < sorted.Length; i++)
            {
                listBox9.Items.Add(sorted[i].Element.ToString());
            }
            textBox19.Text = sortMerge.comparison.ToString();
            textBox18.Text = sortMerge.shift.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

