using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace not_defteri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        bool islem;
        string dadi = "Yeni Metin Belgesi";

        private void geriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void ileriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void tümünüSeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void solaHizalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void ortalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void sağaHizalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void yazıTipiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            DialogResult tus = fd.ShowDialog();
            if (tus == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fd.Font;
            }
            
        }

        private void renkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            DialogResult tus = cd.ShowDialog();
            if (tus == DialogResult.OK)
            {
                richTextBox1.SelectionColor = cd.Color;
            }
        }

        private void istatistikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 istatistikler = new Form2();
            istatistikler.metin = richTextBox1.Text;
            istatistikler.Show();
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1= new AboutBox1();
            aboutBox1.Show();
        }

        private void sözcükKaydırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sözcükKaydırToolStripMenuItem.Checked == true )
            {
                sözcükKaydırToolStripMenuItem.Checked = false;
                richTextBox1.WordWrap= false;

            }
            else
            {
                sözcükKaydırToolStripMenuItem.Checked = true;
                richTextBox1.WordWrap= true;
            }
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (islem == true)
            {
                DialogResult tus = MessageBox.Show("Yaptığınız Değişikleri Kaydetmek İstiyor musunuz ? ", "Kayıt İşlemi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (tus == DialogResult.Yes)
                {
                    DosyaKaydet();
                    richTextBox1.Clear();
                    islem = false; 
                    dadi = "Yeni Metin Belgesi";
                }
                else if (tus == DialogResult.No)
                {
                    richTextBox1.Clear();
                    islem = false;
                    dadi = "Yeni Metin Belgesi";
                }
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            islem = false;
            dadi = " - Yeni Metin Belgesi";
            this.Text += dadi;
        }

        private void açToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (islem == true)
            {
                DialogResult tus = MessageBox.Show("Dosya Açmadan Önce  Yaptığınız Değişikleri Kaydetmek İstiyor musunuz ? ", "Kayıt İşlemi",  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (tus == DialogResult.Yes)
                {
                    DosyaKaydet();
                }
            }
            DosyaAc();
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DosyaKaydet();
            islem = false;
        }

        private void farklıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DosyaFarkliKaydet();
            islem = false;
        }

        private void yazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            pd.ShowDialog();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            islem = true;
        }
        void DosyaKaydet()
        {
            if (islem == true)
            {
                if (dadi == "Yeni Metin Belgesi")
                {
                    SaveFileDialog sf = new SaveFileDialog();
                    sf.InitialDirectory = "C:\\Users\\ibrah\\OneDrive\\Belgeler";
                    sf.Filter = "Text Dosyalar (*.txt) | *.txt | Tüm Dosyalar (*.*) | *.* ";
                    DialogResult tus = sf.ShowDialog();
                    if (tus == DialogResult.OK)
                    {
                        StreamWriter sw = new StreamWriter(sf.FileName);
                        sw.WriteLine(richTextBox1.Text);
                        sw.Close();
                        dadi = sf.FileName;
                    }
                }
                else
                {
                    StreamWriter sw = new StreamWriter(dadi);
                    sw.WriteLine(richTextBox1.Text);
                    sw.Close();
                }
                islem = false;
            }
        }

        void DosyaFarkliKaydet()
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.InitialDirectory = "C:\\Users\\ibrah\\OneDrive\\Belgeler";
            sf.Filter = "Text Dosyalar (*.txt) | *.txt | Tüm Dosyalar (*.*) | *.* ";
            DialogResult tus = sf.ShowDialog();
            if (tus == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sf.FileName);
                sw.WriteLine(richTextBox1.Text);
                sw.Close();
                dadi = sf.FileName;
            }
            islem = false;
        }

        void DosyaAc ()
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Title = "Aç";
            of.InitialDirectory = "C:\\Users\\ibrah\\OneDrive\\Belgeler";
            of.Filter = "Text Dosyalar (*.txt) | *.txt | Tüm Dosyalar (*.*) | *.*";
            DialogResult tus = of.ShowDialog();
            if (tus == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(of.FileName);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
                this.Text = of.SafeFileName + " - Not Defteri";
                islem = false;
                dadi = of.FileName;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (islem == true)
            {
                DialogResult tus = MessageBox.Show("Yaptığınız değişikleri istiyor musunuz ? " , "Kayıt İşlemi" , MessageBoxButtons.YesNoCancel , MessageBoxIcon.Question);
                if (tus == DialogResult.Yes)
                {
                    DosyaKaydet();
                }
                else if (tus == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
    
}
