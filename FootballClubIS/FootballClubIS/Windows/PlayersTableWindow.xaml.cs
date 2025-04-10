using FootballClubIS.Context;
using FootballClubIS.Models;
using FootballClubIS.Repositories;
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

namespace FootballClubIS.Windows
{
    /// <summary>
    /// Логика взаимодействия для PlayersTableWindow.xaml
    /// </summary>
    public partial class PlayersTableWindow : Window
    {
        Repository<Players> _repo;
        public PlayersTableWindow()
        {
            InitializeComponent();
            _repo = new Repository<Players>();
            _repo.GetList().ForEach(x => lbText.Items.Add(x));
        }

        private void cbiMain_Selected(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void cbiTeam_Selected(object sender, RoutedEventArgs e)
        {
            new FootballTeamTableWindow().Show();
            Close();
        }

        private void cbiAchivement_Selected(object sender, RoutedEventArgs e)
        {
            new AchivementsTableWindow().Show();
            Close();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var content = tbSearch.Text;
            if (content.Length >= 1)
            {
                lbText.Items.Clear();
                var keyWords = content.Split(' ').ToList();
                var resultStudent = _repo.GetList();
                foreach (var result in resultStudent.Where(x => keyWords.All(kw => x.ToString().ToLower().Contains(kw.ToLower()))))
                    lbText.Items.Add(result);
                return;
            }
            lbText.Items.Clear();
            _repo.GetList().ForEach(x => lbText.Items.Add(x));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lbText.SelectedItem == null)
                return;
            _repo.Delete((lbText.SelectedItem as Players).Id);
            lbText.Items.Clear();
            _repo.GetList().ForEach(x => lbText.Items.Add(x));
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            new AddOrUpdateWindow(this).Show();
            Visibility = Visibility.Collapsed;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lbText.SelectedItem == null)
                return;
            var windowPlayers = new AddOrUpdateWindow(lbText.SelectedItem as Players, this);
            windowPlayers.Show();
            Visibility = Visibility.Collapsed;
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            lbText.Items.Clear();
            _repo.GetList().ForEach(x => lbText.Items.Add(x));
        }
    }
}
