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
    /// kullaniciSil.xaml etkileşim mantığı
    /// </summary>
    public partial class kullaniciSil : Window
    {
        public kullaniciSil()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(kullaniciSil_Loaded);
        }

        void kullaniciSil_Loaded(object sender ,RoutedEventArgs e)
        {
            GridDoldur();
        }

        private void btnKullaniciSil_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (ORNEKPROJEEntities1 ctx = new ORNEKPROJEEntities1())
                {
                    Users kul = (Users)dgKullanicilar.SelectedItem;
                    ctx.Users.Remove(ctx.Users.Where(c => c.UserID == kul.UserID).FirstOrDefault());
                    ctx.SaveChanges();
                    GridDoldur();
                    MessageBox.Show("Kayıt Silme Başarılı");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: ", ex.Message);
            }
        }

        private void GridDoldur()
        {
            try
            {
                using (ORNEKPROJEEntities1 ctx = new ORNEKPROJEEntities1())
                {
                    var kullanicilar = from k in ctx.Users
                                       select k;

                    dgKullanicilar.ItemsSource = kullanicilar.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: ", ex.Message);
            }
        }
    }
}
