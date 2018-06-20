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
    public partial class changemima : Form
    {
        public GerenXinxi t1;

        public changemima()
        {
            InitializeComponent();
        }

        public changemima(GerenXinxi temp)
        {
            InitializeComponent();
            t1 = temp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            t1.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String yuan = textBox1.Text;
            String g1 = textBox2.Text;
            String g2 = textBox3.Text;
            if (yuan == Person.password)
            {
                if (g1 == g2)
                {
                    String command1 = "update user set mima=@mima where id = @id";
                    MySqlParameter[] paras1 = new MySqlParameter[]{
                        new MySqlParameter("@mima", g1),
                        new MySqlParameter("@id", Person.id),

                    };
                    Person.password = g1;
                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, command1, paras1);

                    MessageBox.Show("密码修改成功");
                }
                else
                {
                    MessageBox.Show("两次输入的新密码不相同");
                }
            }
            else
            {
                MessageBox.Show("原密码错误！");
            }
        }
    }
}
