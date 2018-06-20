using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace 无纸化办公
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            comboBox1.Text = "用户";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            register t = new register(this);
            this.Hide();
            t.Show();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void init(MySqlDataReader dgv)
        {
            Person.age = dgv.GetInt32("age");
            Person.id = dgv.GetString("id");
            Person.password = dgv.GetString("mima");
            Person.Flag = dgv.GetString("Flag");
            Person.name = dgv.GetString("name");
            Person.work = dgv.GetString("work");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlDataReader dgv = MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, "select * from user", null);
            int ok = 0;
            String id = textBox1.Text;
            String mima = textBox2.Text;
            String shenfen = comboBox1.Text;
            while (dgv.Read())
            {
                String tid = dgv.GetString("id");
                if (id == tid)
                {
                    ok = 1;
                    String tmima = dgv.GetString("mima");
                    if (tmima == mima)
                    {
                        ok = 2;
                        String fag = dgv.GetString("Flag");
                        if (shenfen == "管理员" && fag == "1")
                        {
                            ok = 3;
                            init(dgv);
                        }
                        else if (shenfen == "用户" && fag == "0")
                        {
                            ok = 4;
                            init(dgv);
                        } 
                    }
                }
            }
            dgv.Close();
            if (ok == 0)
            {
                MessageBox.Show("不存在该账号");
            }
            else if (ok == 1)
            {
                MessageBox.Show("密码错误");
            }
            else if (ok == 2)
            {
                MessageBox.Show("不存在该" + shenfen);
            }
            else
            {
                 MessageBox.Show("登陆成功");
                 Main main = new Main(this);
                 main.Show();
                 this.Hide();
            }
        }
    }
}