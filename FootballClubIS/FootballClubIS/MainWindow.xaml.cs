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
using FootballClubIS.Context;
using FootballClubIS.Windows;

namespace FootballClubIS
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

        private void cmbPageFirst_Selected(object sender, RoutedEventArgs e)
        {
            new PlayersTableWindow().Show();
            Close();
        }

        private void cmbPageSecond_Selected(object sender, RoutedEventArgs e)
        {
            new FootballTeamTableWindow().Show();
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cmbPageThird_Selected(object sender, RoutedEventArgs e)
        {
            new AchivementsTableWindow().Show();
            Close();
        }
    }
}