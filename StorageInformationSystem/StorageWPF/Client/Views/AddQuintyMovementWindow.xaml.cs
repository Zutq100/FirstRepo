using StorageWPF.Client.Models;
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

namespace StorageWPF.Client.Views
{
    /// <summary>
    /// Логика взаимодействия для AddQuintyMovementWindow.xaml
    /// </summary>
    public partial class AddQuintyMovementWindow : Window
    {
        public AddQuintyMovementWindow()
        {
            InitializeComponent();
            
        }
        

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
