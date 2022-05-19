using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Odev
{
    /// <summary>
    /// kullaniciGuncelle.xaml etkileşim mantığı
    /// </summary>
    public partial class kullaniciGuncelle : Window
    {
        public kullaniciGuncelle()
        {
            InitializeComponent();
        }

        int kID;
        private void btnKullanci_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                kID = Convert.ToInt32(txtKullaniciID.Text);

                using (ORNEKPROJEEntities1 ctx = new ORNEKPROJEEntities1())
                {
                    Sifirla();

                    var kulCek = ctx.Users.Where(c => c.UserID == kID).FirstOrDefault();

                    txtKullaniciID.Text = kulCek.UserID.ToString();
                    txtKullaniciAdi.Text = kulCek.UserName;
                    txtAd.Text = kulCek.FName;
                    txtSoyad.Text = kulCek.LName;
                    txtKullaniciAdi.Text = kulCek.UserName;
                    txtEmail.Text = kulCek.Email;
                    txtTelefon.Text = kulCek.Phone;
                    dtPicker.SelectedDate = kulCek.BirthDate;
                    txtAdres.Text = kulCek.Address;

                    if (kulCek.Gender == true)
                    {
                        radErkek.IsChecked = true;
                    }
                    else
                    {
                        RadKadin.IsChecked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: ", ex.Message);
            }
        }

        private void btnGuncelle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (ORNEKPROJEEntities1 ctx = new ORNEKPROJEEntities1())
                {
                    Users kulUpdate = (from ku in ctx.Users
                                       where ku.UserID == kID
                                       select ku).First();

                    kulUpdate.FName = txtAd.Text;
                    kulUpdate.LName = txtSoyad.Text;
                    kulUpdate.UserName = txtKullaniciAdi.Text;
                    kulUpdate.Phone = txtTelefon.Text;
                    kulUpdate.Address = txtAdres.Text;
                    kulUpdate.Email = txtEmail.Text;
                    kulUpdate.BirthDate = dtPicker.SelectedDate;

                    if (radErkek.IsChecked == true)
                    {
                        kulUpdate.Gender = true;
                    }
                    else
                    {
                        kulUpdate.Gender = false;
                    }

                    ctx.SaveChanges();

                    btnGuncelle.Content = "Güncelle (Başarılı)";
                }
            }
            catch (Exception ex)
            {
                btnGuncelle.Content = "Güncelle (Başarısız)";
                MessageBox.Show("Hata:", ex.Message);
            }
        }

        private void btnTemizle_Click_1(object sender, RoutedEventArgs e)
        {
            Sifirla();
            btnGuncelle.Content = "Güncelle";
        }

        private void Sifirla()
        {
            txtAd.Text = string.Empty;
            txtSoyad.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtKullaniciAdi.Text = string.Empty;
            txtTelefon.Text = string.Empty;
            txtAdres.Text = string.Empty;
            dtPicker.SelectedDate = null;
            radErkek.IsChecked = false;
            RadKadin.IsChecked = false;

        }
    }
}
