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
    /// kullaniciEkle.xaml etkileşim mantığı
    /// </summary>
    public partial class kullaniciEkle : Window
    {
        public kullaniciEkle()
        {
            InitializeComponent();
        }
        ORNEKPROJEEntities1 entity = new ORNEKPROJEEntities1();
      
        private void Temizle()
        {
            txtAd.Text = string.Empty;
            txtSoyad.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtKullaniciAdi.Text = string.Empty;
            txtTelefon.Text = string.Empty;
            txtAdres.Text = string.Empty;
            dtPicker.SelectedDate = null;
        }

        private void btnKaydet_Click_1(object sender, RoutedEventArgs e)
        {
            Users user = new Users();
            user.FName = txtAd.Text;
            user.LName = txtSoyad.Text;
            user.UserName = txtKullaniciAdi.Text;
            user.Email = txtEmail.Text;
            user.Address = txtAdres.Text;
            user.Phone = txtTelefon.Text;
            user.BirthDate = dtPicker.SelectedDate.Value;

            if (radErkek.IsChecked == true)
            {
                user.Gender = true;
            }
            else
            {
                user.Gender = false;
            }
            entity.Users.Add(user);
            entity.SaveChanges();

            btnKaydet.Content = "Kaydet (Başarılı)";
        }

        private void btnTemizle_Click_1(object sender, RoutedEventArgs e)
        {
            Temizle();
        }
    }
}
