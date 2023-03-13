using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace not_defteri
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public string metin;
        private void Form2_Load(object sender, EventArgs e)
        {
            string [] kelimeler = metin.Split(' ');
            string [] cumleler = metin.Split('.');
            string bosluklukaraktersayisi = metin.Length.ToString();
            string bosluksuzkaraktersayisi = (metin.Length - kelimeler.Length - 1).ToString();
            label5.Text = kelimeler.Length.ToString();
            label6.Text = cumleler.Length.ToString();
            label7.Text = bosluklukaraktersayisi;
            label8.Text = bosluksuzkaraktersayisi;
        }
    }
}
