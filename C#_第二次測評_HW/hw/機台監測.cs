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
    public partial class 機台監測 : Form
    {
        public 機台監測()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox4.Image = new Bitmap(comboBox1.Text + ".png");
            label15.Text = comboBox1.Text;

            string selectedMachine = comboBox1.SelectedItem.ToString();
            String machine = comboBox1.SelectedItem.ToString();
            ReadMachineData(machine);
        }

        private void ReadMachineData(string machine)
        {
            int normalTime = 0;
            int abnormalTime = 0;

            string temp1 = "";
            string temp2 = "";

            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                        @"AttachDbFilename=|DataDirectory|\Test.mdf;" +
                        "Integrated Security=True";
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Id,時間,機台編號,運作狀態,製令單號 FROM 機台監測即時數據資料表 WHERE 機台編號 = @machine ORDER BY 時間 DESC", cn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@machine", SqlDbType.NVarChar));
                        cmd.Parameters["@machine"].Value = machine;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string status = reader["運作狀態"].ToString();
                                label47.Text = status;
                            }
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand("SELECT Id,時間,機台編號,運作狀態,製令單號 FROM 機台監測即時數據資料表 WHERE 機台編號 = @machineN ORDER BY 運作狀態", cn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@machineN", SqlDbType.NVarChar));
                        cmd.Parameters["@machineN"].Value = machine;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string status = reader["運作狀態"].ToString();
                                if (status == "正常生產")
                                {
                                    normalTime++;
                                }
                                else
                                {
                                    abnormalTime++;
                                }
                            }
                        }
                    }

                    double utilizationRate = (double)normalTime / (normalTime + abnormalTime);

                    label48.Text = $"{utilizationRate:P}";

                    label48.Text = $"{utilizationRate:P}";

                    if (utilizationRate > 0.85)
                    {
                        label48.ForeColor = Color.Green;
                    }
                    else if (utilizationRate >= 0.8 && utilizationRate <= 0.85)
                    {
                        label48.ForeColor = Color.Yellow;
                    }
                    else
                    {
                        label48.ForeColor = Color.Red;
                    }
                    using (SqlCommand cmd1 = new SqlCommand("SELECT 機台編號,作業人員,製令單號 FROM 生產製造心跳表 WHERE 機台編號 = @machineN ", cn))
                    {
                        cmd1.Parameters.Add(new SqlParameter("@machineN", SqlDbType.NVarChar));
                        cmd1.Parameters["@machineN"].Value = machine;


                        using (SqlDataReader reader = cmd1.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string status = reader["製令單號"].ToString();
                                if (status != "無生產")
                                {
                                    label51.Text = reader["製令單號"].ToString();
                                    label52.Text = "XX化妝品";
                                    label55.Text = "陳XX";

                                    label58.Text = "XX化妝品";
                                    label56.Text = "陳XX";
                                }
                                else
                                {
                                    label51.Text = reader["製令單號"].ToString();
                                    label52.Text = "無數據";
                                    label53.Text = ("無數據");
                                    label55.Text = "無數據";
                                }
                            }
                        }
                    }

                    DateTime endTime = new DateTime(2023, 12, 19, 17, 30, 0);

                    using (SqlCommand cmd1 = new SqlCommand("SELECT 機台編號, MIN(時間) AS 開始生產時間 FROM 即時生產資訊表 WHERE 生產數量 > 0 AND 機台編號 = @machineN GROUP BY 機台編號", cn))
                    {
                        cmd1.Parameters.AddWithValue("@machineN", machine);

                        using (SqlDataReader reader = cmd1.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime startTime;
                                if (DateTime.TryParse(reader["開始生產時間"].ToString(), out startTime))
                                {
                                    TimeSpan timeDifference = endTime - startTime;
                                    string machineId = reader["機台編號"].ToString();
                                    if (machineId != "")
                                        label53.Text = timeDifference.ToString(@"hh\:mm\:ss");
                                    else
                                        label53.Text = ("無數據");
                                }
                            }
                        }
                    }


                    using (SqlCommand cmd1 = new SqlCommand("SELECT 目標數量 FROM 生產製造心跳表 WHERE 機台編號 = @machineN", cn))
                    {
                        cmd1.Parameters.AddWithValue("@machineN", machine);

                        using (SqlDataReader reader = cmd1.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader["目標數量"].ToString() != "0")
                                    temp1 = reader["目標數量"].ToString();
                            }

                        }
                    }

                    using (SqlCommand cmd1 = new SqlCommand("SELECT SUM(生產數量) AS 總生產數量 FROM 即時生產資訊表 WHERE 機台編號 = @machineN GROUP BY 機台編號", cn))
                    {
                        cmd1.Parameters.AddWithValue("@machineN", machine);

                        using (SqlDataReader reader = cmd1.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader["總生產數量"].ToString() != "")
                                    temp2 = reader["總生產數量"].ToString();
                            }
                        }
                    }


                    double temp1Value;
                    double temp2Value;

                    bool temp1Numeric = double.TryParse(temp1, out temp1Value);
                    bool temp2Numeric = double.TryParse(temp2, out temp2Value);

                    if (temp1Numeric && temp2Numeric && temp1Value != 0)
                    {
                        double percentage = (temp2Value / temp1Value) * 100;
                        label50.Text = $"{percentage:0.00}%";
                    }
                    else
                    {
                        label50.Text = "無數據";
                    }
                    using (SqlCommand cmd1 = new SqlCommand("SELECT 時間, 異常資訊, 製令單號 FROM 機台異常記錄表 WHERE 機台編號 = @machineN", cn))
                    {
                        cmd1.Parameters.AddWithValue("@machineN", machine);

                        using (SqlDataReader reader = cmd1.ExecuteReader())
                        {
                            int count = 0;
                            while (reader.Read() && count < 3)
                            {
                                if (count == 0)
                                {
                                    label59.Text = reader["製令單號"].ToString();
                                    label58.Text = "XX化妝品";
                                    label57.Text = reader["時間"].ToString();
                                    label56.Text = "陳XX";
                                    label61.Text = reader["異常資訊"].ToString();

                                }
                                else if (count == 1)
                                {
                                    label68.Text = reader["製令單號"].ToString();
                                    label67.Text = "XX化妝品";
                                    label69.Text = reader["異常資訊"].ToString();
                                    label66.Text = reader["時間"].ToString();
                                    label65.Text = "陳XX";

                                }
                                else if (count == 2)
                                {
                                    label73.Text = reader["製令單號"].ToString();
                                    label72.Text = "XX化妝品";
                                    label74.Text = reader["異常資訊"].ToString();
                                    label71.Text = reader["時間"].ToString();
                                    label70.Text = "陳XX";

                                }
                                count++;
                            }
                            SetLabelVisibility(count, 1, label59, label58, label61, label57, label56);
                            SetLabelVisibility(count, 2, label68, label67, label69, label66, label65);
                            SetLabelVisibility(count, 3, label73, label72, label74, label71, label70);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"資料庫查詢錯誤：{ex.Message}");
            }
        }
        void SetLabelVisibility(int count, int group, params Label[] labels)
        {
            foreach (var label in labels)
            {
                label.Visible = count >= group;
            }
        }

        private void 機台監測_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "請選擇欲查看機台編號!!";
            //comboBox1.Items.Add("A01");
            //comboBox1.Items.Add("A02");
            string[] photo = new string[] { "A01", "A02", "A03", "B01", "B02", "C01", "C02" };
            comboBox1.Items.AddRange(photo);
            pictureBox4.BorderStyle = BorderStyle.Fixed3D;
            // 圖片隨控制項大小伸縮
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void 產能效率_Click(object sender, EventArgs e)
        {
            this.Hide();
            產能效率 f = new 產能效率();
            f.StartPosition = FormStartPosition.Manual;
            f.Location = new Point(100, 100);
            f.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            機台監測 f = new 機台監測();
            f.StartPosition = FormStartPosition.Manual;
            f.Location = new Point(100, 100);
            f.ShowDialog();
        }

        private void 電力監測_Click(object sender, EventArgs e)
        {
            this.Hide();
            電力監測 f = new 電力監測();
            f.StartPosition = FormStartPosition.Manual;
            f.Location = new Point(100, 100);
            f.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            預防保養 f = new 預防保養();
            f.StartPosition = FormStartPosition.Manual;
            f.Location = new Point(100, 100);
            f.ShowDialog();
        }

        private void 離開_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
