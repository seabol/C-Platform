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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace N96121171_蔡尚哲_C__第二次測評
{
    public partial class 設備保養歷史清單 : Form
    {
        string combobox_value = "";
        public 設備保養歷史清單(string comboBoxValue)
        {
            InitializeComponent();
            combobox_value = comboBoxValue;
        }

        private void 設備保養歷史清單_Load(object sender, EventArgs e)
        {
            richTextBox1.Text += "------------------------------------------------------------------------\n";

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;" + "AttachDbFilename=|DataDirectory|Test.mdf;" + "Integrated Security=True";
                DataSet ds = new DataSet();
                SqlDataAdapter daEmp = new SqlDataAdapter("SELECT * FROM 設備保養歷史清單", cn);
                daEmp.Fill(ds, "設備保養歷史清單");

                foreach (DataRow row in ds.Tables["設備保養歷史清單"].Rows)
                {
            
                    for (int i = 1; i < ds.Tables["設備保養歷史清單"].Columns.Count; i++)
                    {
                        if((row[2].ToString()) == combobox_value +"       ")
                        {
                            richTextBox1.Text += row[i].ToString() + "     ";
                           
                        }
                        
                    }
                    if ((row[2].ToString()) == combobox_value + "       ")
                    {
                        richTextBox1.Text += "\n";
                    }
                }

            }


        }
    }
}
