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
    /// Логика взаимодействия для AddOrUpdateWindow.xaml
    /// </summary>
    public partial class AddOrUpdateWindow : Window
    {
        object? _entity;
        int? _index;
        readonly FootballTeamTableWindow? _teamTable;
        readonly AchivementsTableWindow? _achivementsTable;
        readonly PlayersTableWindow? _playersTable;
        public AddOrUpdateWindow()
        {
            InitializeComponent();
        }
        public AddOrUpdateWindow(FootballTeamTableWindow window) : this()
        {
            _index = 0;
            _teamTable = window;
            cmbFirst.ItemsSource = new Repository<Players>().GetList();
            cmbSecond.ItemsSource = new Repository<TypeTeam>().GetList();
            lblPlayer.Visibility = Visibility.Visible;
            lblTeam.Visibility = Visibility.Visible;
            tbFirst.Visibility = Visibility.Collapsed;
            tbSecond.Visibility = Visibility.Collapsed;
            tbThird.Visibility = Visibility.Collapsed;
        }

        public AddOrUpdateWindow(AchivementsTableWindow window) : this()
        {
            _index = 1;
            _achivementsTable = window;
            cmbFirst.ItemsSource = new Repository<Players>().GetList();
            cmbSecond.Items.Add("Клуб");
            cmbSecond.Visibility = Visibility.Collapsed;
            lblFullName.Visibility = Visibility.Visible;
            tbSecond.Visibility= Visibility.Collapsed;
            tbThird.Visibility = Visibility.Collapsed;
            Grid.SetColumnSpan(tbFirst, 3);
            lblFullName.Content = "Введите достижение";
            Grid.SetColumnSpan(lblFullName, 3);
            lblPlayer.Visibility= Visibility.Visible;
        }

        public AddOrUpdateWindow(PlayersTableWindow window) : this()
        {
            _index = 2;
            _playersTable = window;
            cmbFirst.Visibility = Visibility.Collapsed;
            cmbSecond.Visibility = Visibility.Collapsed;
            lblFullName.Visibility = Visibility.Visible;
            lblNumber.Visibility = Visibility.Visible;
            lblPosition.Visibility = Visibility.Visible;
        }

        public AddOrUpdateWindow(FootballTeam team, FootballTeamTableWindow window) : this(window)
        {
            _entity = team;
            var repo = new Repository<FootballTeam>();
            var repoPlayers = new Repository<Players>();
            var repoType = new Repository<TypeTeam>(); 
            cmbFirst.SelectedIndex = repoPlayers.GetList().IndexOf(repoPlayers.Get(team.PlayerId));
            cmbSecond.SelectedIndex = repoType.GetList().IndexOf(repoType.Get(team.TypeId));
        }

        public AddOrUpdateWindow(AchievementsFootballClub achievements, AchivementsTableWindow window) : this(window)
        {
            _entity = achievements;
            var repo = new Repository<AchievementsFootballClub>();
            var repoPlayers = new Repository<Players>();
            var target = repo.Get(achievements.Id);
            cmbFirst.SelectedIndex = repoPlayers.GetList().IndexOf(repoPlayers.Get(target.PlayerId));
            tbFirst.Text = target.Achievement;
        }
        public AddOrUpdateWindow(Players players, PlayersTableWindow window) : this(window)
        {
            _entity = players;
            var repo = new Repository<Players>();
            var target = repo.Get(players.Id);
            tbFirst.Text = target.FullName;
            tbSecond.Text = target.Number.ToString();
            tbThird.Text = target.Position;
        }


        private void btnCreateOrUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (_entity is null)
            {
                try
                {
                    switch (_index)
                    {
                        case 0:
                            new Repository<FootballTeam>().Create(new FootballTeam { PlayerId = (cmbFirst.SelectedItem as Players).Id, TypeId = (cmbSecond.SelectedItem as TypeTeam).Id });
                            break;
                        case 1:
                            new Repository<AchievementsFootballClub>().Create(new AchievementsFootballClub { Achievement = tbSecond.Text, PlayerId = (cmbFirst.SelectedItem as Players).Id });
                            break;
                        case 2:
                            new Repository<Players>().Create(new Players { FullName = tbFirst.Text, Number = int.Parse(tbSecond.Text), Position = tbThird.Text });
                            break;
                    }
                    WindowUpdate();
                    Close();
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            switch (_index)
            {
                case 0:
                    var team = new Repository<FootballTeam>().Get((_entity as FootballTeam).Id);
                    team.PlayerId = (cmbFirst.SelectedItem as Players).Id;
                    team.TypeId = (cmbSecond.SelectedItem as TypeTeam).Id;
                    new Repository<FootballTeam>().Update(team);
                    break;
                case 1:
                    var achievement = new Repository<AchievementsFootballClub>().Get((_entity as AchievementsFootballClub).Id);
                    achievement.PlayerId = (cmbFirst.SelectedItem as Players).Id;
                    achievement.Achievement = tbSecond.Text;
                    new Repository<AchievementsFootballClub>().Update(achievement);
                    break;
                case 2:
                    var player = new Repository<Players>().Get((_entity as Players).Id);
                    try
                    {
                        player.FullName = tbFirst.Text;
                        player.Number = int.Parse(tbSecond.Text);
                        player.Position = tbThird.Text;
                        new Repository<Players>().Update(player);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    break;
            }
            WindowUpdate();
            Close();
        }

        private void WindowUpdate()
        {
            switch (_index)
            {
                case 0:
                    _teamTable.Visibility = Visibility.Visible;
                    break;
                case 1:
                    _achivementsTable.Visibility = Visibility.Visible;
                    break;
                case 2:
                    _playersTable.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
            => Close();

        private void Window_Closed(object sender, EventArgs e) => WindowUpdate();
    }
}
