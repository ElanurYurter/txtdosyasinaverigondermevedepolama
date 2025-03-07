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

namespace txtdosyasinaverigondermevedepolama
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            katilimcilariGetir();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                if (!string.IsNullOrEmpty(tb_soyisim.Text))
                {
                    if (!string.IsNullOrEmpty(tb_telefonno.Text))
                    {
                        if (!string.IsNullOrEmpty(tb_mail.Text))
                        {
                            string dosyaisim = tb_isim.Text + " " + tb_soyisim.Text + ".txt";
                            try
                            {
                                //StreamWriter yazici = new StreamWriter("C://Katilimcilar/"+dosyaisim); //C'ye ise
                                StreamWriter yazici = new StreamWriter("katilimcilar/"+ dosyaisim); //proje üzerinden dosyayı file explorer'dan açıp katilimcilar isminde bir dosya açıldı, uygulama üzerinde oldu C degil.
                                yazici.WriteLine(tb_isim.Text);
                                yazici.WriteLine(tb_soyisim.Text);
                                yazici.WriteLine(tb_mail.Text);
                                yazici.WriteLine(tb_mail.Text);
                                yazici.WriteLine(tb_kimlikno.Text);
                                yazici.WriteLine(tb_telefonno.Text);
                                if (rb_erkek.Checked)
                                {
                                    yazici.WriteLine("Erkek");
                                }
                                else
                                {
                                    yazici.WriteLine("Kadın");
                                }

                                if (rb_Evli.Checked)
                                {
                                    yazici.WriteLine("Evli");
                                }
                                else
                                {
                                    yazici.WriteLine("Bekar");
                                }
                                yazici.Close();
                                katilimcilariGetir();
                                MessageBox.Show("Katılımcı Başarıyla Kaydedilmiştir" , "Başarılı");

                            }
                            catch
                            {
                                MessageBox.Show("Kayıt sırasında bir hata oluştu.", "Hata");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mail boş bırakılamaz!", "Hata");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Telefon Numarası boş bırakılamaz!", "Hata");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Soysim boş bırakılamaz!", "Hata");
                }

            }
            else
            {
                MessageBox.Show("İsim boş bırakılamaz!" , "Hata");
            }
        }

        private void katilimcilariGetir()
        {
            //DirectoryInfo di = new DirectoryInfo("C://katilimcilar"); //C üzerinde yapıldıysa

            DirectoryInfo di = new DirectoryInfo("katilimcilar");
            List<FileInfo> dosyalar = di.GetFiles().ToList();

            lb_katilimcilar.Items.Clear();

            foreach(FileInfo dosya in dosyalar)
            {
                //lb_katilimcilar.Items.Add(dosya.Name); //sonunda .txt görünür
                string dosyaadi = dosya.Name.Substring(0, dosya.Name.Length - 4); //sondan 4 karakteri sildi, .txt görünen isimde silinerek duruşu düzeldi.
                lb_katilimcilar.Items.Add(dosyaadi);
            }
        }

        private void lb_katilimcilar_DoubleClick(object sender, EventArgs e)
        {
            string secilen = lb_katilimcilar.SelectedItem.ToString();
            string dosyaadi = secilen + ".txt";
            StreamReader okuyucu = new StreamReader("katilimcilar/"+dosyaadi);
            tb_isim.Text = okuyucu.ReadLine();
            tb_soyisim.Text = okuyucu.ReadLine();
            tb_kimlikno.Text = okuyucu.ReadLine();
            tb_telefonno.Text = okuyucu.ReadLine();
            if (okuyucu.ReadLine() == "Erkek")
            {
                rb_erkek.Checked = true;
            }
            else
            {
                rb_kadin.Checked = true;
            }

            if (okuyucu.ReadLine() == "Evli")
            {
                rb_Evli.Checked = true;
            }
            else
            {
                rb_bekar.Checked = true;
            }
        }
    }
}
