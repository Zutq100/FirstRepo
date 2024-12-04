using AdvertisingAgency.Context;
using AdvertisingAgency.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace AdvertisingAgency
{
    /// <summary>
    /// Логика взаимодействия для AddOrUpdateReviewsWindow.xaml
    /// </summary>
    public partial class AddOrUpdateReviewsWindow : Window
    {
        MainWindow _owner;
        AdvertisingAgencyContext _context;
        ReviewsTable target;
        public AddOrUpdateReviewsWindow()
        {
            InitializeComponent();
            _context = new AdvertisingAgencyContext();
            cmbOrders.ItemsSource = _context.Orders.Include(nameof(OrdersTable.Client)).ToList();
        }
        public AddOrUpdateReviewsWindow(MainWindow owner) : this() => _owner = owner;
        public AddOrUpdateReviewsWindow(MainWindow owner, ReviewsTable table) : this(owner)
        {
            target = table;
            cmbOrders.SelectedIndex = new AdvertisingAgencyContext().Orders.ToList().FindIndex(x => x.ID == table.OrderID);
            tbReviews.Text = table.DescriptionReviews;
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {

            if (_owner.lbText.SelectedItem == null)
            {
                _context.Reviews.Add(new ReviewsTable() { OrderID = ((OrdersTable)cmbOrders.SelectedItem).ID, DescriptionReviews = tbReviews.Text });
                _context.SaveChanges();
                _owner.Visibility = Visibility.Visible;
                Close();
                return;
            }
            target.DescriptionReviews = tbReviews.Text;
            target.OrderID = ((OrdersTable)cmbOrders.SelectedItem).ID;

            _context.Reviews.Update(target);
            _context.SaveChanges();
            _context.Dispose();
            _owner.Visibility = Visibility.Visible;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
            => Close();

        private void Window_Closed(object sender, EventArgs e)
        {
            _owner.Visibility = Visibility.Visible;
        }
    }
}
