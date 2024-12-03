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
    /// Логика взаимодействия для AddOrUpdateClientsWindow.xaml
    /// </summary>
    public partial class AddOrUpdateClientsWindow : Window
    {
        MainWindow _owner;
        AdvertisingAgencyContext _context;
        ClientsTable target;
        public AddOrUpdateClientsWindow()
        {
            InitializeComponent();
            _context = new AdvertisingAgencyContext();
        }

        public AddOrUpdateClientsWindow(MainWindow owner) : this() => _owner = owner;
        public AddOrUpdateClientsWindow(MainWindow owner, ClientsTable table) : this(owner)
        {
            target = table;
            var listName = table.FullName.Split(' ');
            tbSecondName.Text = listName[0];
            tbFirstName.Text = listName[1];
            tbLastName.Text = listName[2];
            tbEmail.Text = table.Email;
            tbAge.Text = table.Age.ToString();
            tbTelephone.Text = table.Telephone;
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            int age;
            if (int.TryParse(tbAge.Text, out age) is false)
            {
                MessageBox.Show("Неправильный формат возвраста");
                return;
            }
            if(_owner.lbText.SelectedItem == null)
            {
                var fullName = $"{tbSecondName.Text} {tbFirstName.Text} {tbLastName.Text}";
                _context.Clients.Add(new ClientsTable() { FullName = fullName, Age = int.Parse(tbAge.Text), Email = tbEmail.Text, Telephone = tbTelephone.Text });
                _context.SaveChanges();
                _owner.Visibility = Visibility.Visible;
                Close();
                return;
            }
            target.Telephone = tbTelephone.Text;
            target.Email = tbEmail.Text;
            target.FullName = $"{tbSecondName.Text} {tbFirstName.Text} {tbLastName.Text}";
            target.Age = int.Parse(tbAge.Text);
            _context.Update(target);
            _context.SaveChanges();
            _owner.Visibility = Visibility.Visible;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
            => Close();
    }
}
