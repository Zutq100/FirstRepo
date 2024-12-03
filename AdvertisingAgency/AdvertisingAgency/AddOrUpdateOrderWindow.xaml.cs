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
    /// Логика взаимодействия для AddOrUpdateOrderWindow.xaml
    /// </summary>
    public partial class AddOrUpdateOrderWindow : Window
    {
        MainWindow _owner;
        AdvertisingAgencyContext _context;
        public AddOrUpdateOrderWindow()
        {
            InitializeComponent();
            _context = new AdvertisingAgencyContext();
        }
        public AddOrUpdateOrderWindow(MainWindow owner) :this() => _owner = owner;
        public AddOrUpdateOrderWindow(MainWindow owner, OrdersTable orders) : this(owner)
        {

        }
    }
}
