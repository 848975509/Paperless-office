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
    public partial class GerenXinxi : Form
    {
        public Main t1;
        public GerenXinxi()
        {
            InitializeComponent();
        }

        public GerenXinxi(Main temp)
        {
            InitializeComponent();
            t1 = temp;
            init();
        }

        private void init()
        {
            label8.Text = Person.id;
            label9.Text = "******";
            label10.Text = Person.name;
            label11.Text = Person.work;
            label12.Text = Person.age.ToString();
            label13.Text = Person.Flag == "1" ? "是" : "否";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            t1.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changemima tm = new changemima(this);
            tm.Show();
            this.Hide();
        }
    }
}
