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
    public partial class 電力監測 : Form
    {
        public 電力監測()
        {
            InitializeComponent();
        }

        string cnstr = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
          "AttachDbFilename=|DataDirectory|Test.mdf;" +
          "Integrated Security=True";
        DataSet ds = new DataSet();

        void ShowData()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = cnstr;
                SqlDataAdapter dacharge = new SqlDataAdapter("SELECT * FROM 各CT即時電量數據資料表   ORDER BY Id DESC", cn);
                //SqlCommand cmd = new SqlCommand("SELECT * FROM 機台監測即時數據資料表  WHERE 運作狀態=正常生產 ORDER BY Id DESC", cn);
                //SqlDataReader dr = cmd.ExecuteReader();
                dacharge.Fill(ds, "機台監測即時數據資料表");
                DataTable dt = ds.Tables["機台監測即時數據資料表"];
                // ComboBox控制項資料繫結
                comboBox2.DisplayMember = "Id";
                comboBox2.ValueMember = "機台監測即時數據資料表";
                comboBox2.DataSource = ds.Tables["機台監測即時數據資料表"];
                comboBox3.DisplayMember = "比流器編號";
                comboBox3.ValueMember = "機台監測即時數據資料表";
                comboBox3.DataSource = ds.Tables["機台監測即時數據資料表"];
                //轉換成DateTime
                DateTime dt_end = Convert.ToDateTime(dt.Rows[904][1]);
                DateTime dt_start = Convert.ToDateTime(dt.Rows[0][1]);

                //時間相減
                TimeSpan ts = dt_start - dt_end;
                String totalHours = ts.TotalHours.ToString();
                // 在richTextBox1內顯示客戶的所有記錄

                // 增加第七列
                dt.Columns.Add("本日累計用電量", typeof(float)); // 例如 typeof(int) 或 typeof(string)

                // 增加第八列
                dt.Columns.Add("本日累計碳排量", typeof(float));
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    dt.Rows[i][6] = ((int.Parse(dt.Rows[i][4].ToString())) * int.Parse(dt.Rows[i][5].ToString())) / 1000 * float.Parse(totalHours);
                    dt.Rows[i][7] = float.Parse(dt.Rows[i][6].ToString()) * 0.5;



                }
                // TextBox控制項資料繫結
                //txtName.DataBindings.Add("Text", ds, "員工.姓名");
                //txtTel.DataBindings.Add("Text", ds, "員工.電話");
                //txtPosition.DataBindings.Add("Text", ds, "員工.職稱");
                //txtSalary.DataBindings.Add("Text", ds, "員工.薪資");
                // DataGridView控制項資料繫結
                dataGridView1.DataSource = ds.Tables["機台監測即時數據資料表"];
                //dataGridView1.DataMember = "機台監測即時數據資料表";
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            機台監測 f = new 機台監測();
            f.StartPosition = FormStartPosition.Manual;
            f.Location = new Point(100, 100);
            f.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            電力監測 f = new 電力監測();
            f.StartPosition = FormStartPosition.Manual;
            f.Location = new Point(100, 100);
            f.ShowDialog();
        }

        private void 電力監測_Load(object sender, EventArgs e)
        {
            ShowData();

        }

        private void 產能效率_Click(object sender, EventArgs e)
        {
            this.Hide();
            產能效率 f = new 產能效率();
            f.StartPosition = FormStartPosition.Manual;
            f.Location = new Point(100, 100);
            f.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
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
