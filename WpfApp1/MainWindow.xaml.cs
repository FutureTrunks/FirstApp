using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary> // xd ajk jestli je tohle poslední změna tak to funguje
    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        int poziceBtn;
        int skore;
        public MainWindow()
        {
            InitializeComponent();

            novyPriklad();
        }

        public void novyPriklad()     // vygeneruje přiklad a spočítá ho.
        {
            int cislo1 = rnd.Next(0, 11); 
            int cislo2 = rnd.Next(0, 11); 
            int znaminko = rnd.Next(1, 4);
            poziceBtn = rnd.Next(1, 3);
            string priklad = "";
            priklad += cislo1;

            switch (znaminko) {      //random znamínko +-* podle int znaminko
                case 1:
                    priklad += "+";
                    break;
                case 2:
                    priklad += "-";
                    break;
                case 3:
                    priklad += "*";
                    break;
                default:
                    break;
            }

            priklad += cislo2;
            Popisek.Content = priklad;

            DataTable dt = new DataTable();
            if (poziceBtn == 1)
            {
                butt1.Content = dt.Compute(priklad, "");
                butt2.Content = (int)dt.Compute(priklad, "") - rnd.Next(1, 11);
            }
            else
            {
                butt2.Content = dt.Compute(priklad, "");
                butt1.Content = (int)dt.Compute(priklad, "") - rnd.Next(1, 11);
            }
        }
        private void butt1_Click(object sender, RoutedEventArgs e)     //funkce po kliknutí na butt1
        {
            if (poziceBtn == 1)
            {
                ProgressBar1.Value += 5;
                skore += 1;
                Spravne.Content = skore;
            }
            else
            {
                ProgressBar1.Value -= 5;
                if (skore == 0)  //protekce proti zápornému skore
                {
                    skore = 0;
                }
                else
                {
                    skore -= 1;
                }
                Spravne.Content = skore;
            }
            novyPriklad();   //generovaní nových čísel a přikladu
        }

        private void butt2_Click(object sender, RoutedEventArgs e)     //funkce po kliknutí na butt2
        {
            if (poziceBtn == 2)  
            {
                ProgressBar1.Value += 5;
                skore += 1;
                Spravne.Content = skore;

            }
            else
            {
                ProgressBar1.Value -= 5;  //odečtení od progress baru

                if (skore == 0)  //protekce proti zápornému skore
                {
                    skore = 0;
                }
                else
                {
                    skore -= 1;
                }

                Spravne.Content = skore;  //vypsání skore
            }
            novyPriklad();
        }

        private void UlozSkore_Click(object sender, RoutedEventArgs e)
        {
            SavedSkore.Content = skore;
        }
    }
}
