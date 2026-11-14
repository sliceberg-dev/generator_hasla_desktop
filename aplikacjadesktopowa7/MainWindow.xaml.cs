using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace aplikacjadesktopowa7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string lastHaslo = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        private string GeneratePassword()
        {
            int ilosc = int.Parse(textBoxIlosc.Text);
            var sb = new StringBuilder(ilosc);
            char[] litery = { 'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z' };
            char[] cyfry = { '0','1','2','3','4','5','6','7','8','9' };
            char[] literyDuze = { 'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z' };
            char[] znakiSpecjalne = { '!','@','#','$','%','^','&','*','(',')','_','+','-','=' };
            var rnd = new Random();

            for (int i = 0; i < ilosc; i++)
            {
                int r;
                if (i == 0 && IfWielkie.IsChecked == true)
                {
                    r = rnd.Next(0, literyDuze.Length);
                    sb.Append(literyDuze[r]);
                }
                else if (i == 1 && IfCyfry.IsChecked == true)
                {
                    r = rnd.Next(0, cyfry.Length);
                    sb.Append(cyfry[r]);
                }
                else if (i == 2 && IfZnaki.IsChecked == true)
                {
                    r = rnd.Next(0, znakiSpecjalne.Length);
                    sb.Append(znakiSpecjalne[r]);
                }
                else
                {
                    r = rnd.Next(0, litery.Length);
                    sb.Append(litery[r]);
                }
            }

            return sb.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lastHaslo = GeneratePassword();
            MessageBox.Show(lastHaslo);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(lastHaslo))
            {
               
                lastHaslo = GeneratePassword();
            }

            MessageBox.Show(
              "Dane pracownika: " + imie.Text + " " + nazwisko.Text + " " + stanowisko.SelectedValue?.ToString() + " Hasło: " + lastHaslo);
        }
    }
}