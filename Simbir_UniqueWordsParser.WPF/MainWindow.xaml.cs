using Simbir_UniqueWordsParser.Core;
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
        IReader _reader;
        IMessageService _messageService;
        ILogger _logger;

        public MainWindow()
        {
            InitializeComponent();

            _reader = Configuration.GetReader();
            _messageService = Configuration.GetMessageService();
            _logger = Configuration.GetLogger();
        }

        private async void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            string url = tbxUrl.Text;

            btnStart.IsEnabled = false;

            try
            {
                List<WordStat> wordStats = await GetUniqueWordsStatisticsByUrlAsync(url);
                lbxWordsStat.ItemsSource = wordStats;

                if (wordStats != null)
                {
                    await DB.DbUtils.AddStatsToDb(url, BL.Convert.BlToDb.WordStatsList(wordStats));
                }
            }
            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
                _logger.Log(ex.Message);
            }

            btnStart.IsEnabled = true;
        }

        /// <summary>
        /// Метод для запуска задачи асинхронно, дабы не зависал интерфейс во время выполнения
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<List<WordStat>> GetUniqueWordsStatisticsByUrlAsync(string url)
        {
            return await Task.Run(() => _reader.GetUniqueWordsStatisticsByUrl(url));
        }
    }
}
