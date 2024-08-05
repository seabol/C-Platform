using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace N96121171_蔡尚哲_C__第二次測評.Resources
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int t1 = 0, t2 = 0, t3 = 0;
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbfilename=|DataDirectory|Test.mdf; Integrated Security=True";
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT 運作狀態 FROM 機台監測即時數據資料表 WHERE 時間 = '2023/12/19 17:30:00'", cn);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string status = dr["運作狀態"].ToString();
                    switch (status)
                    {
                        case "正常生產":
                            t1++;
                            break;
                        case "待單停機":
                            t2++;
                            break;
                        case "故障":
                            t3++;
                            break;
                    }
                }
            }
            label1.Text = t1.ToString();
            label5.Text = t2.ToString();
            label3.Text = t3.ToString();


        }
        private void SetLabelColor(Label label)
        {

            label.ForeColor = Color.White;

        }
        private void SetLabelColorBasedOnValue(Label label)
        {
            double value = Convert.ToDouble(label.Text.TrimEnd('%'));
            if (value >= 85)
            {
                label.ForeColor = Color.Green;
            }
            else if (value >= 80 && value < 85)
            {
                label.ForeColor = Color.Yellow;
            }
            else
            {
                label.ForeColor = Color.Red;
            }
        }
        private void CalculateAndDisplayOEE(Label productionEfficiencyLabel, Label passRateLabel, Label utilizationLabel, Label oeeLabel)
        {
            double productionEfficiency = Convert.ToDouble(productionEfficiencyLabel.Text.TrimEnd('%')) / 100;
            double passRate = Convert.ToDouble(passRateLabel.Text.TrimEnd('%')) / 100;
            double utilizationRate = Convert.ToDouble(utilizationLabel.Text.TrimEnd('%')) / 100;

            double oee = productionEfficiency * passRate * utilizationRate;
            oeeLabel.Text = (oee * 100).ToString("0.00") + "%";
        }
        private void UpdateMachineUtilizationRate(Label machineLabel, Label utilizationLabel, Label startTimeLabel, Dictionary<string, int> operationTimes, DateTime endTime)
        {
            string machineId = machineLabel.Text;
            if (operationTimes.ContainsKey(machineId) && DateTime.TryParseExact(startTimeLabel.Text, "yyyy/MM/dd tt hh:mm:ss", new CultureInfo("zh-TW"), DateTimeStyles.None, out DateTime startTime))
            {
                int totalOperationTime = (operationTimes[machineId] - 1) * 10; // 獲取調整後的運作時間
                Console.WriteLine("機台調整後的運作時間: " + totalOperationTime);
                double totalDuration = (endTime - startTime).TotalSeconds;
                Console.WriteLine("機台調整後的總運作時間: " + totalDuration);
                double utilizationRate = (totalDuration > 0) ? (double)totalOperationTime / totalDuration * 100 : 0;
                utilizationLabel.Text = utilizationRate.ToString("0.00") + "%";
            }
            else
            {
                utilizationLabel.Text = "無數據";
            }
        }



        private void UpdatePassRate(Label producedLabel, Label passRateLabel, Dictionary<string, int> goodProducts, string machineId)
        {
            if (goodProducts.ContainsKey(machineId) && double.TryParse(producedLabel.Text, out double produced))
            {
                double passRate = (produced > 0) ? (double)goodProducts[machineId] / produced * 100 : 0;
                passRateLabel.Text = (passRate > 100) ? "100.00%" : passRate.ToString("0.00") + "%";
            }
            else
            {
                passRateLabel.Text = "無數據";
            }
        }
        private void UpdateProductionProgressLabel(Label actualLabel, Label targetLabel, Label progressLabel)
        {
            if (double.TryParse(actualLabel.Text, out double actual) && double.TryParse(targetLabel.Text, out double target) && target != 0)
            {
                double progress = actual / target * 100;
                progressLabel.Text = progress.ToString("0.00") + "%";
            }
            else
            {
                progressLabel.Text = "無數據";
            }
        }

        private void UpdateStatusLabel(Label label, string status)
        {

            label.BackColor = Color.Green;
            label.ForeColor = Color.Black;
        }
        private void UpdateStatusLabel2(Label label, string status)
        {

            label.BackColor = Color.Gray;
            label.ForeColor = Color.Black;
        }
        private void UpdateStatusLabel3(Label label, string status)
        {

            label.BackColor = Color.Red;
            label.ForeColor = Color.Black;
        }
        // 更新PictureBox圖片
        private void UpdatePictureBox(string machineId, PictureBox pictureBox)
        {
            if (machineId.StartsWith("A"))
            {
                pictureBox.Image = Properties.Resources.Machine_A;
            }
            else if (machineId.StartsWith("B"))
            {
                pictureBox.Image = Properties.Resources.Machine_B;
            }
            else if (machineId.StartsWith("C"))
            {
                pictureBox.Image = Properties.Resources.Machine_C;
            }
            else
            {
                pictureBox.Image = null;
            }
        }







        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbfilename=|DataDirectory|Test.mdf; Integrated Security=True";
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT 時間, 運作狀態, 機台編號, 製令單號 FROM 機台監測即時數據資料表", cn);
                //SqlDataReader dr = cmd.ExecuteReader();
                Dictionary<string, int> normalMachines = new Dictionary<string, int>();
                Dictionary<string, string> machineStatus = new Dictionary<string, string>();
                Dictionary<string, string> machineOrders = new Dictionary<string, string>();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string machineId = dr["機台編號"].ToString();
                        string status = dr["運作狀態"].ToString();
                        string order = dr["製令單號"].ToString();
                        // 更新機台狀態
                        if (!machineStatus.ContainsKey(machineId))
                        {
                            machineStatus[machineId] = status;
                            machineOrders[machineId] = order;
                        }
                        if (dr["時間"].ToString() == "2023/12/19 下午 05:30:00" && dr["運作狀態"].ToString() == "正常生產")
                        {

                            if (!normalMachines.ContainsKey(machineId))
                            {
                                normalMachines[machineId] = 0;
                            }
                            normalMachines[machineId]++;
                        }
                    }
                }




                Dictionary<string, string> machineStartTimes = new Dictionary<string, string>();

                // 執行新的查詢以獲取每台機器的開始生產時間
                SqlCommand startTimeCmd = new SqlCommand("SELECT 機台編號, MIN(時間) AS 開始生產時間 FROM 即時生產資訊表 WHERE 生產數量 > 0 GROUP BY 機台編號", cn);
                using (SqlDataReader startTimeDr = startTimeCmd.ExecuteReader())
                {
                    while (startTimeDr.Read())
                    {
                        string machineId = startTimeDr["機台編號"].ToString();
                        string startTime = startTimeDr["開始生產時間"].ToString();
                        machineStartTimes[machineId] = startTime;
                    }
                }


                var sortedMachines = normalMachines.OrderByDescending(kvp => kvp.Value).Take(3).ToList();


                SqlCommand targetCmd = new SqlCommand("SELECT 機台編號, 目標數量 FROM 生產製造心跳表", cn);
                using (SqlDataReader targetDr = targetCmd.ExecuteReader())
                {
                    Dictionary<string, string> targetQuantities = new Dictionary<string, string>();
                    while (targetDr.Read())
                    {
                        string machineId = targetDr["機台編號"].ToString();
                        string targetQuantity = targetDr["目標數量"].ToString();
                        targetQuantities[machineId] = targetQuantity;
                    }

                    // 更新LABEL28、48、68
                    label28.Text = sortedMachines.Count >= 1 && targetQuantities.ContainsKey(sortedMachines[0].Key) ? targetQuantities[sortedMachines[0].Key] : "無數據";
                    label48.Text = sortedMachines.Count >= 2 && targetQuantities.ContainsKey(sortedMachines[1].Key) ? targetQuantities[sortedMachines[1].Key] : "無數據";
                    label68.Text = sortedMachines.Count >= 3 && targetQuantities.ContainsKey(sortedMachines[2].Key) ? targetQuantities[sortedMachines[2].Key] : "無數據";
                }
                // 定義一個字典來存儲每台機台的實際生產數量
                Dictionary<string, int> actualProduction = new Dictionary<string, int>();

                // 統計每台機台的生產數量
                SqlCommand productionCmd = new SqlCommand("SELECT 機台編號, SUM(生產數量) AS 總生產數量 FROM 即時生產資訊表 GROUP BY 機台編號", cn);
                using (SqlDataReader productionDr = productionCmd.ExecuteReader())
                {
                    while (productionDr.Read())
                    {
                        string machineId = productionDr["機台編號"].ToString();
                        int totalProduction = Convert.ToInt32(productionDr["總生產數量"]);
                        actualProduction[machineId] = totalProduction;
                    }
                }





                // 更新LABEL27、47、67
                label27.Text = sortedMachines.Count >= 1 && actualProduction.ContainsKey(sortedMachines[0].Key) ? actualProduction[sortedMachines[0].Key].ToString() : "無數據";
                label47.Text = sortedMachines.Count >= 2 && actualProduction.ContainsKey(sortedMachines[1].Key) ? actualProduction[sortedMachines[1].Key].ToString() : "無數據";
                label67.Text = sortedMachines.Count >= 3 && actualProduction.ContainsKey(sortedMachines[2].Key) ? actualProduction[sortedMachines[2].Key].ToString() : "無數據";

                ////////////////////////////////









                // 更新界面
                label9.Text = sortedMachines.Count >= 1 ? sortedMachines[0].Key : "無數據";
                label31.Text = "正常生產";
                label30.Text = sortedMachines.Count >= 1 ? machineOrders[sortedMachines[0].Key] : "無數據";
                label30.Text = "NC12121906";
                label10.Text = sortedMachines.Count >= 2 ? sortedMachines[1].Key : "無數據";
                label51.Text = "正常生產";
                label50.Text = sortedMachines.Count >= 2 ? machineOrders[sortedMachines[1].Key] : "無數據";

                label11.Text = sortedMachines.Count >= 3 ? sortedMachines[2].Key : "無數據";
                label71.Text = "正常生產";
                label70.Text = sortedMachines.Count >= 3 ? machineOrders[sortedMachines[2].Key] : "無數據";


                DateTime endTime = new DateTime(2023, 12, 19, 17, 30, 0);
                Dictionary<string, double> cycleTimes = new Dictionary<string, double>
                {
                { "A01", 2 }, { "A02", 1.6 }, { "A03", 2.5 }, { "B02", 1 }, { "C02", 1.5 }
                };

                foreach (var machine in sortedMachines)
                {
                    if (DateTime.TryParseExact(machineStartTimes[machine.Key], "yyyy/MM/dd tt hh:mm:ss", new CultureInfo("zh-TW"), DateTimeStyles.None, out DateTime startTime))
                    {
                        TimeSpan timeDifference = endTime - startTime;
                        double cycleTime = cycleTimes.ContainsKey(machine.Key) ? cycleTimes[machine.Key] : 0;
                        double actual = 0;
                        double efficiency = 0;

                        //Console.WriteLine(label9.Text);
                        //Console.WriteLine(label10.Text);
                        //Console.WriteLine(label11.Text);
                        if (machine.Key == label9.Text)
                        {
                            actual = double.Parse(label27.Text);
                            efficiency = (cycleTime > 0) ? actual / (timeDifference.TotalSeconds / cycleTime) * 100 : 0;
                            label25.Text = efficiency.ToString("0.00") + "%";
                        }
                        else if (machine.Key == label10.Text)
                        {
                            actual = double.Parse(label47.Text);
                            efficiency = (cycleTime > 0) ? actual / (timeDifference.TotalSeconds / cycleTime) * 100 : 0;
                            label45.Text = efficiency.ToString("0.00") + "%";
                        }
                        else if (machine.Key == label11.Text)
                        {
                            actual = double.Parse(label67.Text);
                            efficiency = (cycleTime > 0) ? actual / (timeDifference.TotalSeconds / cycleTime) * 100 : 0;
                            label65.Text = efficiency.ToString("0.00") + "%";
                        }
                    }
                    else
                    {
                        label25.Text = "無數據";
                        label45.Text = "無數據";
                        label65.Text = "無數據";
                    }
                }
                Dictionary<string, int> goodProducts = new Dictionary<string, int>();

                // 從數據庫中獲取每台機台的良品數量
                SqlCommand goodProductsCmd = new SqlCommand("SELECT 機台編號, SUM(良品數量) AS 總良品數量 FROM 即時生產品質記錄表 GROUP BY 機台編號", cn);
                using (SqlDataReader goodProductsDr = goodProductsCmd.ExecuteReader())
                {
                    while (goodProductsDr.Read())
                    {
                        string machineId = goodProductsDr["機台編號"].ToString();
                        int totalGoodProducts = Convert.ToInt32(goodProductsDr["總良品數量"]);
                        goodProducts[machineId] = totalGoodProducts;
                    }
                }


                // 更新直通率
                UpdatePassRate(label27, label24, goodProducts, label9.Text);
                UpdatePassRate(label47, label44, goodProducts, label10.Text);
                UpdatePassRate(label67, label64, goodProducts, label11.Text);

                //////////////////
                label29.Text = sortedMachines.Count >= 1 && machineStartTimes.ContainsKey(sortedMachines[0].Key) ? machineStartTimes[sortedMachines[0].Key] : "無數據";
                label49.Text = sortedMachines.Count >= 2 && machineStartTimes.ContainsKey(sortedMachines[1].Key) ? machineStartTimes[sortedMachines[1].Key] : "無數據";
                label69.Text = sortedMachines.Count >= 3 && machineStartTimes.ContainsKey(sortedMachines[2].Key) ? machineStartTimes[sortedMachines[2].Key] : "無數據";

                // 更新PictureBox圖片
                UpdatePictureBox(label9.Text, pictureBox1);
                UpdatePictureBox(label10.Text, pictureBox2);
                UpdatePictureBox(label11.Text, pictureBox3);
                UpdateStatusLabel(label31, sortedMachines.Count >= 1 ? machineStatus[sortedMachines[0].Key] : "無數據");
                UpdateStatusLabel(label51, sortedMachines.Count >= 2 ? machineStatus[sortedMachines[1].Key] : "無數據");
                UpdateStatusLabel(label71, sortedMachines.Count >= 3 ? machineStatus[sortedMachines[2].Key] : "無數據");
                UpdateProductionProgressLabel(label27, label28, label26);
                UpdateProductionProgressLabel(label47, label48, label46);
                UpdateProductionProgressLabel(label67, label68, label66);


                Dictionary<string, int> normalOperationCount = new Dictionary<string, int>();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string machineId = dr["機台編號"].ToString();
                        string status = dr["運作狀態"].ToString();

                        if (status == "正常生產")
                        {
                            if (!normalOperationCount.ContainsKey(machineId))
                            {
                                normalOperationCount[machineId] = 0;
                            }
                            normalOperationCount[machineId]++;
                        }
                    }

                    // 將每台機台的正常運作次數減一後乘以10
                    foreach (var pair in normalOperationCount)
                    {
                        int adjustedOperationTime = (pair.Value - 1) * 10;
                        Console.WriteLine("機台 " + pair.Key + " 調整後的運作時間: " + adjustedOperationTime);
                    }
                }


                UpdateMachineUtilizationRate(label9, label23, label29, normalOperationCount, endTime);
                UpdateMachineUtilizationRate(label10, label43, label49, normalOperationCount, endTime);
                UpdateMachineUtilizationRate(label11, label63, label69, normalOperationCount, endTime);

                CalculateAndDisplayOEE(label25, label24, label23, label22);
                CalculateAndDisplayOEE(label45, label44, label43, label42);
                CalculateAndDisplayOEE(label65, label64, label63, label62);
                SetLabelColorBasedOnValue(label22);
                SetLabelColorBasedOnValue(label23);
                SetLabelColorBasedOnValue(label24);
                SetLabelColorBasedOnValue(label25);
                SetLabelColorBasedOnValue(label42);
                SetLabelColorBasedOnValue(label43);
                SetLabelColorBasedOnValue(label44);
                SetLabelColorBasedOnValue(label45);
                SetLabelColorBasedOnValue(label62);
                SetLabelColorBasedOnValue(label63);
                SetLabelColorBasedOnValue(label64);
                SetLabelColorBasedOnValue(label65);


            }
        }

       



        private void 產能效率_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f = new Form2();
            f.StartPosition = FormStartPosition.Manual;
            f.Location = new Point(100, 100);
            f.ShowDialog();
        }

        private void 機台監測_Click(object sender, EventArgs e)
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

        private void 預防保養_Click(object sender, EventArgs e)
        {
            this.Hide();
            預防保養 f = new 預防保養();
            f.StartPosition = FormStartPosition.Manual;
            f.Location = new Point(100, 100);
            f.ShowDialog();
        }

        private void 生產總表_Click(object sender, EventArgs e)
        {
 
        }

        private void 離開_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)

        {

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbfilename=|DataDirectory|Test.mdf; Integrated Security=True";
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT 時間, 運作狀態, 機台編號, 製令單號 FROM 機台監測即時數據資料表", cn);
                SqlDataReader dr = cmd.ExecuteReader();

                Dictionary<string, int> normalMachines = new Dictionary<string, int>();
                Dictionary<string, string> machineStatus = new Dictionary<string, string>();
                Dictionary<string, string> machineOrders = new Dictionary<string, string>();

                while (dr.Read())
                {
                    string machineId = dr["機台編號"].ToString();
                    string status = dr["運作狀態"].ToString();
                    string order = dr["製令單號"].ToString();
                    // 更新機台狀態
                    if (!machineStatus.ContainsKey(machineId))
                    {
                        machineStatus[machineId] = status;
                        machineOrders[machineId] = order;
                    }
                    if (dr["時間"].ToString() == "2023/12/19 下午 05:30:00" && dr["運作狀態"].ToString() == "待單停機")
                    {

                        if (!normalMachines.ContainsKey(machineId))
                        {
                            normalMachines[machineId] = 0;
                        }
                        normalMachines[machineId]++;
                    }
                }

                var sortedMachines = normalMachines.OrderByDescending(kvp => kvp.Value).Take(3).ToList();

                // 更新界面
                label9.Text = sortedMachines.Count >= 1 ? sortedMachines[0].Key : "無數據";
                label31.Text = "待單停機";
                label30.Text = "無數據";

                label10.Text = sortedMachines.Count >= 2 ? sortedMachines[1].Key : "無數據";
                label51.Text = "待單停機";
                label50.Text = "無數據";

                label11.Text = sortedMachines.Count >= 3 ? sortedMachines[2].Key : "無數據";
                label71.Text = "待單停機";
                label70.Text = "無數據";
                label29.Text = "無數據";
                label28.Text = "無數據";
                label27.Text = "無數據";
                label26.Text = "無數據";
                label25.Text = "無數據";
                label24.Text = "無數據";
                label23.Text = "無數據";
                label22.Text = "無數據";
                label49.Text = "無數據";
                label48.Text = "無數據";
                label47.Text = "無數據";
                label46.Text = "無數據";
                label45.Text = "無數據";
                label44.Text = "無數據";
                label43.Text = "無數據";
                label42.Text = "無數據";
                label69.Text = "無數據";
                label68.Text = "無數據";
                label67.Text = "無數據";
                label66.Text = "無數據";
                label65.Text = "無數據";
                label64.Text = "無數據";
                label63.Text = "無數據";
                label62.Text = "無數據";
                // 更新PictureBox圖片
                UpdatePictureBox(label9.Text, pictureBox1);
                UpdatePictureBox(label10.Text, pictureBox2);
                UpdatePictureBox(label11.Text, pictureBox3);
                UpdateStatusLabel2(label31, sortedMachines.Count >= 1 ? machineStatus[sortedMachines[0].Key] : "無數據");
                UpdateStatusLabel2(label51, sortedMachines.Count >= 2 ? machineStatus[sortedMachines[1].Key] : "無數據");
                UpdateStatusLabel2(label71, sortedMachines.Count >= 3 ? machineStatus[sortedMachines[2].Key] : "無數據");
                SetLabelColor(label22);
                SetLabelColor(label23);
                SetLabelColor(label24);
                SetLabelColor(label25);
                SetLabelColor(label42);
                SetLabelColor(label43);
                SetLabelColor(label44);
                SetLabelColor(label45);
                SetLabelColor(label62);
                SetLabelColor(label63);
                SetLabelColor(label64);
                SetLabelColor(label65);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbfilename=|DataDirectory|Test.mdf; Integrated Security=True";
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT 時間, 運作狀態, 機台編號, 製令單號 FROM 機台監測即時數據資料表", cn);
                SqlDataReader dr = cmd.ExecuteReader();

                Dictionary<string, int> normalMachines = new Dictionary<string, int>();
                Dictionary<string, string> machineStatus = new Dictionary<string, string>();
                Dictionary<string, string> machineOrders = new Dictionary<string, string>();

                while (dr.Read())
                {
                    string machineId = dr["機台編號"].ToString();
                    string status = dr["運作狀態"].ToString();
                    string order = dr["製令單號"].ToString();
                    // 更新機台狀態
                    if (!machineStatus.ContainsKey(machineId))
                    {
                        machineStatus[machineId] = status;
                        machineOrders[machineId] = order;
                    }
                    if (dr["時間"].ToString() == "2023/12/19 下午 05:30:00" && dr["運作狀態"].ToString() == "故障")
                    {

                        if (!normalMachines.ContainsKey(machineId))
                        {
                            normalMachines[machineId] = 0;
                        }
                        normalMachines[machineId]++;
                    }
                }

                var sortedMachines = normalMachines.OrderByDescending(kvp => kvp.Value).Take(3).ToList();

                // 更新界面
                label9.Text = sortedMachines.Count >= 1 ? sortedMachines[0].Key : "無數據";
                label31.Text = sortedMachines.Count >= 1 ? machineStatus[sortedMachines[0].Key] : "無數據";
                label30.Text = "無數據";

                label10.Text = sortedMachines.Count >= 2 ? sortedMachines[1].Key : "無數據";
                label51.Text = sortedMachines.Count >= 2 ? machineStatus[sortedMachines[1].Key] : "無數據";
                label50.Text = "無數據";

                label11.Text = sortedMachines.Count >= 3 ? sortedMachines[2].Key : "無數據";
                label71.Text = sortedMachines.Count >= 3 ? machineStatus[sortedMachines[2].Key] : "無數據";
                label70.Text = "無數據";
                label29.Text = "無數據";
                label28.Text = "無數據";
                label27.Text = "無數據";
                label26.Text = "無數據";
                label25.Text = "無數據";
                label24.Text = "無數據";
                label23.Text = "無數據";
                label22.Text = "無數據";
                label49.Text = "無數據";
                label48.Text = "無數據";
                label47.Text = "無數據";
                label46.Text = "無數據";
                label45.Text = "無數據";
                label44.Text = "無數據";
                label43.Text = "無數據";
                label42.Text = "無數據";
                label69.Text = "無數據";
                label68.Text = "無數據";
                label67.Text = "無數據";
                label66.Text = "無數據";
                label65.Text = "無數據";
                label64.Text = "無數據";
                label63.Text = "無數據";
                label62.Text = "無數據";
                // 更新PictureBox圖片
                UpdatePictureBox(label9.Text, pictureBox1);
                UpdatePictureBox(label10.Text, pictureBox2);
                UpdatePictureBox(label11.Text, pictureBox3);
                UpdateStatusLabel3(label31, sortedMachines.Count >= 1 ? machineStatus[sortedMachines[0].Key] : "無數據");
                UpdateStatusLabel3(label51, sortedMachines.Count >= 2 ? machineStatus[sortedMachines[1].Key] : "無數據");
                UpdateStatusLabel3(label71, sortedMachines.Count >= 3 ? machineStatus[sortedMachines[2].Key] : "無數據");
                SetLabelColor(label22);
                SetLabelColor(label23);
                SetLabelColor(label24);
                SetLabelColor(label25);
                SetLabelColor(label42);
                SetLabelColor(label43);
                SetLabelColor(label44);
                SetLabelColor(label45);
                SetLabelColor(label62);
                SetLabelColor(label63);
                SetLabelColor(label64);
                SetLabelColor(label65);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }
    }
}
