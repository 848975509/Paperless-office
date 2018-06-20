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
    public partial class yhgl : Form
    {

        public Main t1;

        public yhgl()
        {
            InitializeComponent();
        }

        public yhgl(Main temp)
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
            lookyh tm = new lookyh(this);
            this.Hide();
            tm.Show();
        }
    }
}
