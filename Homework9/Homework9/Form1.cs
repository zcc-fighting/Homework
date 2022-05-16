using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Homework9
{
    public partial class Form1 : Form
    {
        string ENGLISHDATA = "";
        int i = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void sure_Click(object sender, EventArgs e)
        {
            if (ENGLISHDATA.Replace(" ", "") == textBox1.Text)
                result.Text = "拼写正确！";
            else result.Text = "拼写错误！";
        }

        private void next_Click(object sender, EventArgs e)
        {
            //建立连接字符串
            string conString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\C#work\\Homework9\\DATA\\WORD.mdf;Integrated Security=True";
            //创建连接对象
            SqlConnection conn = new SqlConnection(conString);
            //打开数据连接
            conn.Open();
            //执行数库库操作
            string conStr = "SELECT CHINESE,ENGLISH FROM WORD WHERE NO = '" + i + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(conStr, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "WORD");
            Chinese.Text = ds.Tables["WORD"].Rows[0][0].ToString();
            ENGLISHDATA = ds.Tables["WORD"].Rows[0][1].ToString();
            conStr = "SELECT COUNT(NO) FROM WORD";
            SqlCommand cmd = new SqlCommand(conStr,conn);
            object COUNT = cmd.ExecuteScalar();
            if (COUNT.Equals(i+1))
            {
                MessageBox.Show("恭喜你，背完了！");
                i = 0;
            }
            else
            {
                i++;
            }
            //关闭连接
            conn.Close();
        }
    }
}
