using AdvertisingAgency.Context;
using AdvertisingAgency.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using System.Windows;
using System.Windows.Controls;

namespace AdvertisingAgency
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AdvertisingAgencyContext _context;
        public MainWindow()
        {
            InitializeComponent();
            _context = new AdvertisingAgencyContext();
            cmbFilter.SelectedIndex = 3;
            cmbBase.SelectedIndex = 0;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            switch (cmbBase.SelectedIndex)
            {
                case 0:
                    if (lbText.SelectedItem != null)
                    {
                        var window = new AddOrUpdateClientsWindow(this, lbText.SelectedItem as ClientsTable);
                        window.Show();
                        this.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        var window = new AddOrUpdateClientsWindow(this);
                        window.Show();
                        this.Visibility = Visibility.Collapsed;
                    }
                    break;
                case 1:
                    if (lbText.SelectedItem != null)
                    {
                        var window = new AddOrUpdateOrderWindow(this, lbText.SelectedItem as OrdersTable);
                        window.Show();
                        this.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        var window = new AddOrUpdateOrderWindow(this);
                        window.Show();
                        this.Visibility = Visibility.Collapsed;
                    }
                    break;
                case 2:
                    if (lbText.SelectedItem != null)
                    {
                        var window = new AddOrUpdateReviewsWindow(this, lbText.SelectedItem as ReviewsTable);
                        window.Show();
                        this.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        var window = new AddOrUpdateReviewsWindow(this);
                        window.Show();
                        this.Visibility = Visibility.Collapsed;
                    }
                    break;
                default:
                    break;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lbText.SelectedItem is null)
            {
                MessageBox.Show("Элемент для удаления не выбран");
                return;
            }
            switch (cmbBase.SelectedIndex)
            {
                case 0:
                    _context.Remove<ClientsTable>(lbText.SelectedItem as ClientsTable);
                    goto default;
                case 1:
                    _context.Remove<OrdersTable>(lbText.SelectedItem as OrdersTable);
                    _context.SaveChanges();
                    cmbFilter_SelectionChanged(null, null);
                    break;
                case 2:
                    _context.Remove<ReviewsTable>(lbText.SelectedItem as ReviewsTable);
                    goto default;
                default:
                    _context.SaveChanges();
                    cmbBase_SelectionChanged(null, null);
                    break;
            }
        }

        private void btnStatus_Click(object sender, RoutedEventArgs e)
        {
            if (cmbBase.SelectedIndex != 1)
                return;
            if (lbText.SelectedItem == null)
            {
                MessageBox.Show("Элемент для изменения не выбран");
                return;
            }

            var target = lbText.SelectedItem as OrdersTable;
            switch (target.Status)
            {
                case "Не принят":
                    target.Status = "Открыт";
                    goto default;
                case "Открыт":
                    target.Status = "Закрыт";
                    goto default;
                case "Закрыт":
                    target.Status = "Открыт";
                    goto default;
                default:
                    _context.Update(target);
                    _context.SaveChanges();
                    cmbFilter_SelectionChanged(null, null);
                    break;
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var content = txtSearch.Text;
            if (content.Length >= 1)
            {
                lbText.ItemsSource = null;
                var keyWords = content.Split(' ').ToList();
                switch (cmbBase.SelectedIndex)
                {
                    case 0:
                        var resultsClients = _context.Clients.ToList();
                        lbText.ItemsSource = resultsClients.Where(x => keyWords.All(kw => x.ToString().ToLower().Contains(kw.ToLower())));
                        return;
                    case 1:
                        var resultsOrders = _context.Orders.Include(nameof(OrdersTable.Client)).ToList();
                        if (cmbFilter.SelectedIndex == 0)
                            resultsOrders = resultsOrders.Where(x => x.Status == "Не принят").ToList();
                        if (cmbFilter.SelectedIndex == 1)
                            resultsOrders = resultsOrders.Where(x => x.Status == "Открыт").ToList();
                        if (cmbFilter.SelectedIndex == 2)
                            resultsOrders = resultsOrders.Where(x => x.Status == "Закрыт").ToList();
                        lbText.ItemsSource = resultsOrders.Where(x => keyWords.All(kw => x.ToString().ToLower().Contains(kw.ToLower())));
                        return;
                    case 2:
                        var resultsReview = _context.Reviews.Include(nameof(ReviewsTable.Order)).ToList();
                        lbText.ItemsSource = resultsReview.Where(x => keyWords.All(kw => x.ToString().ToLower().Contains(kw.ToLower())));
                        return;
                }
            }
            if (cmbFilter.Visibility != Visibility.Visible)
            {
                cmbBase_SelectionChanged(null, null);
                return;
            }
            cmbFilter_SelectionChanged(null, null);
        }

        private void cmbBase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbText.ItemsSource = null;
            switch (cmbBase.SelectedIndex)
            {
                case 0:
                    lbText.ItemsSource = _context.Clients.ToList();
                    cmbFilter.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    lbText.ItemsSource = _context.Orders.Include(nameof(OrdersTable.Client)).ToList();
                    cmbFilter.Visibility = Visibility.Visible;
                    cmbFilter_SelectionChanged(null, null);
                    break;
                case 2:
                    lbText.ItemsSource = _context.Reviews.Include(nameof(ReviewsTable.Order)).ToList();
                    cmbFilter.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void cmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbBase.SelectedIndex != 1)
                return;
            lbText.ItemsSource = null;
            var listOrders = _context.Orders.Include(nameof(OrdersTable.Client)).ToList();
            switch (cmbFilter.SelectedIndex)
            {
                case 0:
                    lbText.ItemsSource = listOrders.Where(x => x.Status == "Не принят");
                    break;
                case 1:
                    lbText.ItemsSource = listOrders.Where(x => x.Status == "Открыт");
                    break;
                case 2:
                    lbText.ItemsSource = listOrders.Where(x => x.Status == "Закрыт");
                    break;
                case 3:
                    lbText.ItemsSource = listOrders;
                    break;
            }
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Visibility == Visibility.Collapsed)
                return;
            cmbBase_SelectionChanged(null, null);
        }
    }
}