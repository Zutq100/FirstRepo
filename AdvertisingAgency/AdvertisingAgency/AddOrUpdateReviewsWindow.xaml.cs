using AdvertisingAgency.Context;
using AdvertisingAgency.Models;
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

namespace AdvertisingAgency
{
    /// <summary>
    /// Логика взаимодействия для AddOrUpdateReviewsWindow.xaml
    /// </summary>
    public partial class AddOrUpdateReviewsWindow : Window
    {
        MainWindow _owner;
        AdvertisingAgencyContext _context;
        public AddOrUpdateReviewsWindow()
        {
            InitializeComponent();
            _context = new AdvertisingAgencyContext();
        }
        public AddOrUpdateReviewsWindow(MainWindow owner) : this() => _owner = owner;
        public AddOrUpdateReviewsWindow(MainWindow owner, ReviewsTable table) : this(owner)
        {

        }
    }
}
