using N96121171_蔡尚哲_C__第二次測評.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N96121171_蔡尚哲_C__第二次測評
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
     

        }

        private void 產能效率_Click(object sender, EventArgs e)
        {
            Form2 f3 = new Form2();
            f3.ShowDialog();
        }


        private void 機台監測_Click(object sender, EventArgs e)
        {
            機台監測 f3 = new 機台監測();
            f3.ShowDialog();
        }


        private void 電力監測_Click(object sender, EventArgs e)
        {
            電力監測 f4 = new 電力監測();
            f4.ShowDialog();
        }

        private void 預防保養_Click(object sender, EventArgs e)
        {
            預防保養 f5 = new 預防保養();
            f5.ShowDialog();
        }

        private void 離開_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }











       






       
    }
}
