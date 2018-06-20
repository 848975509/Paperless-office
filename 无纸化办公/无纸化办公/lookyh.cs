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
    public partial class lookyh : Form
    {
        public yhgl t1;

        public lookyh()
        {
            InitializeComponent();
        }

        public lookyh(yhgl temp)
        {
            InitializeComponent();
            t1 = temp;

            listView1.Columns.Add("账号", 105, HorizontalAlignment.Center);
            listView1.Columns.Add("姓名", 105, HorizontalAlignment.Center);
            listView1.Columns.Add("职称", 105, HorizontalAlignment.Center);
            

            listView1.Items.Clear();//每次点击事件后将ListView中的数据清空，重新显示

            listView1.GridLines = true;//表格是否显示网格线
            listView1.FullRowSelect = true;//是否选中整行
            listView1.View = View.Details;//设置显示方式
            listView1.Scrollable = true;//是否自动显示滚动条
            listView1.MultiSelect = true;//是否可以选择多行


            String cmd = "select * from user";
            MySqlDataReader dgv = MySqlHelper.ExecuteReader(MySqlHelper.Conn, CommandType.Text, cmd, null);
            while (dgv.Read())
            {
                Add(dgv);
            }
        }

        private void Add(MySqlDataReader dgv)
        {
            ListViewItem item = new ListViewItem();
            listView1.Items.Add(item);
            item.SubItems.Clear();
            /* 设置subitem的Font, ForeColor, BackColor，为false时，只设置单个subitem,而不影响同一行的其他subitem */
            item.UseItemStyleForSubItems = false;
            item.SubItems[0].Text = dgv.GetString("id");
            //添加subitem
            item.SubItems.Add(new ListViewItem.ListViewSubItem());
            item.SubItems[1].Text = dgv.GetString("name");
            item.SubItems.Add(new ListViewItem.ListViewSubItem());
            item.SubItems[2].Text = dgv.GetString("work");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            t1.Show();
            this.Close();
        }
    }
}
