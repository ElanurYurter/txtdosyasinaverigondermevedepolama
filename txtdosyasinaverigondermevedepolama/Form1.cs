using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics.Eventing.Reader;

namespace txtdosyasinaverigondermevedepolama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //dosyaisim = "";



        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            //dosyaisim += tb_isim.Text;

            //FileInfo fi = new FileInfo("C://Deneme2/" + dosyaisim + ".txt");
            

            if (tb_isim.Text == null || tb_tc.Text == null || lb_cinsiyet.SelectedItem == null)
            {
                MessageBox.Show("İsim, tc veya cinsiyet boş bırakılamaz!", "Hata!");
            }
            //else if (btn_kaydet.Click += ) ;
            else
            {

            }
            FileInfo fi = new FileInfo("C://Deneme2/Kişiler.txt");
            File.Create("C://Deneme2/Kaydedilenler.txt");
            MessageBox.Show("Oluşturuldu", "Başarılı");

            try
            {
                StreamWriter sw = new StreamWriter("C://Deneme2/Kaydedilenler.txt");
                sw.WriteLine(tb_isim.Text);
                sw.WriteLine(tb_soyisim.Text);
                sw.WriteLine(tb_tc.Text);
                sw.WriteLine(tb_mail.Text);
                sw.WriteLine(tb_numara.Text);
                sw.WriteLine(lb_cinsiyet.Text);
                sw.Close();
            }
            catch
            {
                MessageBox.Show("Yazdırılırken bir hata oluştu.", "Hata!");
            }

        }

        private void btn_dosyaolustur_Click(object sender, EventArgs e)
        {
            ////dosyaisim += tb_isim.Text;

            ////FileInfo fi = new FileInfo("C://Deneme2/" + dosyaisim + ".txt");
            //FileInfo fi = new FileInfo("C://Deneme2/Kişiler.txt");
            //File.Create("C://Deneme2/Kaydedilenler.txt");
            //MessageBox.Show("Oluşturuldu", "Başarılı");
        }
    }   
}
