using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 无纸化办公
{
    public partial class jiaoliu : Form
    {
        public Main t1;
        public jiaoliu()
        {
            InitializeComponent();
        }

        public jiaoliu(Main temp)
        {
            InitializeComponent();
            t1 = temp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            t1.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            server tm = new server(this);
            this.Hide();
            tm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            client tm = new client(this);
            this.Hide();
            tm.Show();
        }
    }
}
