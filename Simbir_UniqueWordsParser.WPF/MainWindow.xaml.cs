using Simbir_UniqueWordParser.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Simbir_UniqueWordsParser.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            string url = tbxUrl.Text;

            if (!IsUrlAddressValid(url))
                return;

            btnStart.IsEnabled = false;

            try
            {
                List<WordStat> wordsStat = HtmlUtils.GetUniqueWordsStatisticsByUrl(url);
                lbxWordsStat.ItemsSource = wordsStat;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            btnStart.IsEnabled = true;
        }

        private bool IsUrlAddressValid(string url)
        {
            if (!url.StartsWith("https://"))
            {
                MessageBox.Show("Введите ссылку, начинающуюся с https://");
                return false;
            }

            // Валидация
            Match match = Regex.Match(url, @"^https://\w+\..+");
            if (!match.Success)
            {
                MessageBox.Show("Введите ссылку в формате: https://site.com");
                return false;
            }

            return true;
        }
    }
}
