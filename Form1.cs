using System;
using System.Windows.Forms;

namespace _1kelime1islemtemiz01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void userControlIslem1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            userControlGiris1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userControlIslem1.BringToFront();
            lbl_baslik.Text = "İşlem Oyunu";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userControlGiris1.BringToFront();
            lbl_baslik.Text = "Hoşgeldiniz";
        }
    }
}
