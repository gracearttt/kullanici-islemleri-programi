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
    /// kullanicilariGetir.xaml etkileşim mantığı
    /// </summary>
    public partial class kullanicilariGetir : Window
    {
        public kullanicilariGetir()
        {
            InitializeComponent();
        }

        private void btnKullanicileriGetir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (ORNEKPROJEEntities1 ctx = new ORNEKPROJEEntities1())
                {
                    var kullanicilar = from k in ctx.Users
                                       select k;
                    gridKullanicilar.ItemsSource = kullanicilar.ToList();                              
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " ,ex.Message);
            }
        }
    }
}
