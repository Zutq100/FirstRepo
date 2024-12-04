using AdvertisingAgency.Context;
using AdvertisingAgency.Models;
using System.Windows;

namespace AdvertisingAgency
{
    /// <summary>
    /// Логика взаимодействия для AddOrUpdateOrderWindow.xaml
    /// </summary>
    public partial class AddOrUpdateOrderWindow : Window
    {
        MainWindow _owner;
        AdvertisingAgencyContext _context;
        OrdersTable target;
        public AddOrUpdateOrderWindow()
        {
            InitializeComponent();
            _context = new AdvertisingAgencyContext();
            cmbClient.ItemsSource = _context.Clients.ToList();
        }
        public AddOrUpdateOrderWindow(MainWindow owner) : this() => _owner = owner;
        public AddOrUpdateOrderWindow(MainWindow owner, OrdersTable orders) : this(owner)
        {
            target = orders;
            tbBudget.Text = orders.Budget.ToString();
            tbDescription.Text = orders.Description;
            cmbClient.SelectedIndex = new AdvertisingAgencyContext().Clients.ToList().FindIndex(x => x.ID == orders.ClientID);
            try
            {
                var date = DateTime.Parse(orders.TermOfRealization);
                dpTerms.SelectedDate = date;
            }
            catch (Exception ex)
            {

            }
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            if (_owner.lbText.SelectedItem == null)
            {
                _context.Orders.Add(new OrdersTable() { ClientID = ((ClientsTable)cmbClient.SelectedItem).ID, Budget = int.Parse(tbBudget.Text), Description = tbDescription.Text, TermOfRealization = dpTerms.SelectedDate == null ? "Неограничен" : dpTerms.SelectedDate.ToString() });
                _context.SaveChanges();
                _owner.Visibility = Visibility.Visible;
                Close();
                return;
            }
            target.Budget = int.Parse(tbBudget.Text);
            target.Description = tbDescription.Text;
            target.ClientID = ((ClientsTable)cmbClient.SelectedItem).ID;
            target.Client = (ClientsTable)cmbClient.SelectedItem;
            if (dpTerms.SelectedDate != null)
                target.TermOfRealization = dpTerms.SelectedDate.ToString();
            _context.Update(target);
            _context.SaveChanges(true);
            _context.Dispose();
            _owner.Visibility = Visibility.Visible;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _owner.Visibility = Visibility.Visible;
            Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _owner.Visibility = Visibility.Visible;
        }
    }
}
