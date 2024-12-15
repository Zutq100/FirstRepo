using FaculityInform.EFCore.Models;
using FaculityInform.Repository;
using FaculityInform.Windows;
using System.Windows;
using System.Windows.Controls;

namespace FaculityInform
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cmbSelectTable.SelectedIndex = 0;
        }

        private void cmbSelectTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = cmbSelectTable.SelectedIndex;
            lbText.Items.Clear();
            switch (index)
            {
                case 0:
                    new Repository<Students>().GetAll(nameof(Students.Group)).ForEach(x => lbText.Items.Add(x));
                    break;
                case 1:
                    new Repository<Groups>().GetAll(nameof(Groups.Directions)).ForEach(x => lbText.Items.Add(x));
                    break;
                case 2:
                    new Repository<Directions>().GetAll(nameof(Directions.Department)).ForEach(x => lbText.Items.Add(x));
                    break;
                case 3:
                    new Repository<Departments>().GetAll().ForEach(x => lbText.Items.Add(x));
                    break;
                case 4:
                    new Repository<CompositionOfTeachers>().GetAll(nameof(CompositionOfTeachers.Department)).ForEach(x => lbText.Items.Add(x));
                    break;
            }
        }

        private void miCreate_Click(object sender, RoutedEventArgs e)
        {
            var index = cmbSelectTable.SelectedIndex;
            var windowQuality = new AddOrUpdateWindow(this);
            windowQuality.Show();
            this.Visibility = Visibility.Collapsed;
        }

        private void miUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lbText.SelectedItem == null)
                return;
            var index = cmbSelectTable.SelectedIndex;
            switch (index)
            {
                case 0:
                    var windowStudents = new AddOrUpdateWindow(this, lbText.SelectedItem as Students);
                    windowStudents.Show();
                    this.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    var windowGroup = new AddOrUpdateWindow(this, lbText.SelectedItem as Groups);
                    windowGroup.Show();
                    this.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    var windowDirections = new AddOrUpdateWindow(this, lbText.SelectedItem as Directions);
                    windowDirections.Show();
                    this.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    var windowDepartments = new AddOrUpdateWindow(this, lbText.SelectedItem as Departments);
                    windowDepartments.Show();
                    this.Visibility = Visibility.Collapsed;
                    break;
                case 4:
                    var windowTeachers = new AddOrUpdateWindow(this, lbText.SelectedItem as CompositionOfTeachers);
                    windowTeachers.Show();
                    this.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void miDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lbText.SelectedItem == null)
                return;
            var index = cmbSelectTable.SelectedIndex;
            switch (index)
            {
                case 0:
                    new Repository<Students>().Delete((lbText.SelectedItem as Students).Id);
                    break;
                case 1:
                    new Repository<Groups>().Delete((lbText.SelectedItem as Groups).Id);
                    break;
                case 2:
                    new Repository<Directions>().Delete((lbText.SelectedItem as Directions).Id);
                    break;
                case 3:
                    new Repository<Departments>().Delete((lbText.SelectedItem as Departments).Id);
                    break;
                case 4:
                    new Repository<CompositionOfTeachers>().Delete((lbText.SelectedItem as CompositionOfTeachers).Id);
                    break;
            }
            cmbSelectTable_SelectionChanged(null, null);
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
            => cmbSelectTable_SelectionChanged(null, null);

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var content = tbSearch.Text;
            if (content.Length >= 1)
            {
                lbText.Items.Clear();
                var keyWords = content.Split(' ').ToList();
                switch (cmbSelectTable.SelectedIndex)
                {
                    case 0:
                        var resultStudent = new Repository<Students>().GetAll(nameof(Students.Group));
                        foreach (var result in resultStudent.Where(x => keyWords.All(kw => x.ToString().ToLower().Contains(kw.ToLower()))))
                            lbText.Items.Add(result);
                        return;
                    case 1:
                        var resultGroup = new Repository<Groups>().GetAll(nameof(Groups.Directions));
                        foreach (var result in resultGroup.Where(x => keyWords.All(kw => x.ToString().ToLower().Contains(kw.ToLower()))))
                            lbText.Items.Add(result);
                        return;
                    case 2:
                        var resultDirections = new Repository<Directions>().GetAll(nameof(Directions.Department));
                        foreach (var result in resultDirections.Where(x => keyWords.All(kw => x.ToString().ToLower().Contains(kw.ToLower()))))
                            lbText.Items.Add(result);
                        return;
                    case 3:
                        var resultDepartment = new Repository<Departments>().GetAll();
                        foreach (var result in resultDepartment.Where(x => keyWords.All(kw => x.ToString().ToLower().Contains(kw.ToLower()))))
                            lbText.Items.Add(result);
                        return;
                    case 4:
                        var resultTeacher = new Repository<CompositionOfTeachers>().GetAll(nameof(CompositionOfTeachers.Department));
                        foreach (var result in resultTeacher.Where(x => keyWords.All(kw => x.ToString().ToLower().Contains(kw.ToLower()))))
                            lbText.Items.Add(result);
                        return;
                }
            }
            cmbSelectTable_SelectionChanged(null, null);
        }
    }
}