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
    public partial class Main : Form
    {
        public login t1;
        public Main()
        {
            InitializeComponent();
        }
        public Main(login temp)
        {
            InitializeComponent();
            t1 = temp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t1.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GerenXinxi tm = new GerenXinxi(this);
            this.Hide();
            tm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            yhgl tm = new yhgl(this);
            this.Hide();
            tm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            jiaoliu tm = new jiaoliu(this);
            this.Hide();
            tm.Show();
        }
    }
}
