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
using System.IO;

namespace N96121171_蔡尚哲_C__第二次測評
{
    public partial class 預防保養 : Form
    {
        public 預防保養()
        {
            InitializeComponent();
        }

        private void 預防保養_Load(object sender, EventArgs e)
        {
            

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;" + "AttachDbFilename=|DataDirectory|Test.mdf;" + "Integrated Security=True";
                DataSet ds = new DataSet();
                SqlDataAdapter daEmp = new SqlDataAdapter("SELECT * FROM 機台健康度記錄表", cn);
                daEmp.Fill(ds,"機台健康度記錄表");
                dataGridView1.DataSource = ds.Tables["機台健康度記錄表"];

                string maintenanceColumn = "建議保養時數";
                string runningTimeColumn = "已運行時數";

                DataColumn healthColumn = new DataColumn("機台健康度", typeof(double));

                
                ds.Tables["機台健康度記錄表"].Columns.Add(healthColumn);
                

                
                foreach (DataRow row in ds.Tables["機台健康度記錄表"].Rows)
                {
                    double maintenanceTime = Convert.ToDouble(row[maintenanceColumn]);
                    double runningTime = Convert.ToDouble(row[runningTimeColumn]);

                    
                    if (maintenanceTime != 0)
                    {
                        row["機台健康度"] = Math.Round((maintenanceTime - runningTime) / (double)maintenanceTime * 100, 1);
                    }
                    else
                    {
                        row["機台健康度"] = 0; 
                    }
                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;" + "AttachDbFilename=|DataDirectory|Test.mdf;" + "Integrated Security=True";
                DataSet ds2 = new DataSet();
                SqlDataAdapter daEmp = new SqlDataAdapter("SELECT * FROM 設備保養歷史清單", cn);
                daEmp.Fill(ds2, "設備保養歷史清單");
                

                設備保養歷史清單 f = new 設備保養歷史清單(comboBox1.Text);
                f.ShowDialog();

            }
        }
    }
}
