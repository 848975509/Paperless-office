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
    public partial class register : Form
    {
        public login t1;
        public register()
        {
            InitializeComponent();
        }

        public register(login temp)
        {
            InitializeComponent();
            t1 = temp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            t1.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="") MessageBox.Show("请输入账号!");
            else if(textBox2.Text=="") MessageBox.Show("请输入密码!");
            else if (textBox3.Text == "") MessageBox.Show("请输入确认密码!");
            else if (textBox4.Text == "") MessageBox.Show("请输入姓名!");
            else if (textBox5.Text == "") MessageBox.Show("请输入工作职位!");
            else if (textBox6.Text == "") MessageBox.Show("请输入年龄!");
            else if(textBox2.Text!=textBox3.Text) MessageBox.Show("两次密码输入不一致!");
            else
            {
                String id = textBox1.Text;
                String mima = textBox2.Text;
                MySqlDataReader dgv = MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, "select * from user", null);
                bool ok = true;
                while (dgv.Read())
                {
                    String tid = dgv.GetString("id");
                    if (tid == id)
                    {
                        ok = false;
                        break;
                    }

                }
                dgv.Close();
                if (ok)
                {
                    String name = textBox4.Text;
                    int age = int.Parse(textBox6.Text);
                    String work = textBox5.Text;
                    String command1 = "insert into user set id=@id , mima = @mima,name=@name,work=@work,age=@age";
                    MySqlParameter[] paras1 = new MySqlParameter[]{
                        new MySqlParameter("@id", id),
                        new MySqlParameter("@mima", mima),
                        new MySqlParameter("@name", name),
                        new MySqlParameter("@work", work),
                        new MySqlParameter("@age", age)

                    };
                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, command1, paras1);
                    MessageBox.Show("注册成功!");
                }
                else MessageBox.Show("该账号已注册");
            }
        }
    }
}
