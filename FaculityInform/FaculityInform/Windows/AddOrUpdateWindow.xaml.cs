using FaculityInform.EFCore.Models;
using FaculityInform.Repository;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;

namespace FaculityInform.Windows
{
    public partial class AddOrUpdateWindow : Window
    {
        readonly MainWindow _window;
        int _index;
        object _entity;
        public AddOrUpdateWindow()
        {
            InitializeComponent();
        }

        public AddOrUpdateWindow(MainWindow window) : this()
        {
            _window = window;
            _index = window.cmbSelectTable.SelectedIndex;
            switch (_index)
            {
                case 0:
                    cmbFirst.ItemsSource = new Repository<Groups>().GetAll(nameof(Groups.Directions));
                    cmbFirst.Visibility = Visibility.Visible;
                    tbOne.Visibility = Visibility.Visible;
                    lblSecond.Content = "ФИО учащегося";
                    lblFirst.Content = "Группа учащегося";
                    break;
                case 1:
                    cmbFirst.ItemsSource = new Repository<Directions>().GetAll(nameof(Directions.Department));
                    cmbFirst.Visibility = Visibility.Visible;
                    tbOne.Visibility = Visibility.Visible;
                    lblSecond.Content = "Название группы";
                    lblFirst.Content = "Направление";
                    break;
                case 2:
                    cmbFirst.ItemsSource = new Repository<Departments>().GetAll();
                    cmbFirst.Visibility = Visibility.Visible;
                    lblSecond.Content = "Название направления";
                    lblThird.Content = "Код направления";
                    lblFourth.Content = "Профиль направления";
                    lblFirst.Content = "Кафедра направления";
                    tbOne.Visibility = Visibility.Visible;
                    tbSecond.Visibility = Visibility.Visible;
                    lblThird.Visibility = Visibility.Visible;
                    break;
                case 3:
                    lblSecond.Content = "Название кафедры";
                    tbOne.Visibility = Visibility.Visible;
                    break;
                case 4:
                    cmbFirst.Visibility = Visibility.Visible;
                    cmbFirst.ItemsSource = new Repository<Departments>().GetAll();
                    lblSecond.Content = "ФИО Преподавателя";
                    lblThird.Content = "Должность преподавателя";
                    lblFirst.Content = "Кафедра преподавателя";
                    tbOne.Visibility = Visibility.Visible;
                    tbSecond.Visibility = Visibility.Visible;
                    break;
            }
        }

        public AddOrUpdateWindow(MainWindow window, Students students) : this(window)
        {
            _entity = students;
            var repo = new Repository<Students>();
            var repoGroup = new Repository<Groups>();
            tbOne.Text = repo.Get(students.Id).FullName;
            cmbFirst.SelectedIndex = repoGroup.GetAll().IndexOf(repoGroup.Get(students.Group.Id));
            btnCreateOrUpdate.Content = "Обновление";
        }

        public AddOrUpdateWindow(MainWindow window, Groups groups) : this(window)
        {
            _entity = groups;
            var repo = new Repository<Groups>();
            var repoDirection = new Repository<Directions>();
            tbOne.Text = repo.Get(groups.Id).Title;
            cmbFirst.SelectedItem = repoDirection.GetAll().IndexOf(repoDirection.Get(groups.Directions.Id));
            btnCreateOrUpdate.Content = "Обновление";
        }

        public AddOrUpdateWindow(MainWindow window, Directions directions) : this(window)
        {
            _entity = directions;
            var repo = new Repository<Directions>();
            var repoDepartment = new Repository<Departments>();
            var directionsTarget = repo.Get(directions.Id);
            tbOne.Text = directionsTarget.Title;
            tbSecond.Text = directionsTarget.GroupCode;
            tbThird.Text = directionsTarget.Profile;
            cmbFirst.SelectedIndex = repoDepartment.GetAll().IndexOf(repoDepartment.Get(directions.Department.Id));
            btnCreateOrUpdate.Content = "Обновление";
        }

        public AddOrUpdateWindow(MainWindow window, Departments departments) : this(window)
        {
            _entity = departments;
            var repo = new Repository<Departments>();
            tbOne.Text = repo.Get(departments.Id).Title;
            btnCreateOrUpdate.Content = "Обновление";
        }

        public AddOrUpdateWindow(MainWindow window, CompositionOfTeachers teachers) : this(window)
        {
            _entity = teachers;
            var repo = new Repository<CompositionOfTeachers>();
            var repoDepartments = new Repository<Departments>();
            tbOne.Text = repo.Get(teachers.Id).FullName;
            tbSecond.Text = repo.Get(teachers.Id).Post;
            cmbFirst.SelectedIndex = repoDepartments.GetAll().IndexOf(repoDepartments.Get(teachers.Department.Id));
            btnCreateOrUpdate.Content = "Обновление";
        }

        private void Window_Closed(object sender, EventArgs e)
            => _window.Visibility = Visibility.Visible;

        private void btnCancel_Click(object sender, RoutedEventArgs e)
            => Close();

        private void btnCreateOrUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (_entity is null)
            {
                AddEntity();
                Close();
                return;
            }
            UpdateEntity();
            Close();
        }

        private void AddEntity()
        {
            switch (_index)
            {
                case 0:
                    new Repository<Students>().Create(new Students { FullName = tbOne.Text, GroupId = (cmbFirst.SelectedItem as Groups).Id });
                    break;
                case 1:
                    new Repository<Groups>().Create(new Groups { Title = tbOne.Text, DirectionsId = (cmbFirst.SelectedItem as Directions).Id });
                    break;
                case 2:
                    new Repository<Directions>().Create(new Directions { Title = tbOne.Text, GroupCode = tbSecond.Text, Profile = tbThird.Text, DepartmentId = (cmbFirst.SelectedItem as Departments).Id});
                    break;
                case 3:
                    new Repository<Departments>().Create(new Departments { Title = tbOne.Text });
                    break;
                case 4:
                    new Repository<CompositionOfTeachers>().Create(new CompositionOfTeachers { FullName = tbOne.Text, Post = tbSecond.Text, DepartmentId = (cmbFirst.SelectedItem as Departments).Id });
                    break;
            }
        }

        private void UpdateEntity()
        {
            switch (_index)
            {
                case 0:
                    var entityStudent = new Repository<Students>().Get((_entity as Students).Id);
                    entityStudent.FullName = tbOne.Text;
                    entityStudent.GroupId = (cmbFirst.SelectedItem as Groups).Id;
                    new Repository<Students>().Update(entityStudent);
                    break;
                case 1:
                    var entityGroup = new Repository<Groups>().Get((_entity as Groups).Id);
                    entityGroup.Title = tbOne.Text;
                    entityGroup.DirectionsId = (cmbFirst.SelectedItem as Directions).Id;
                    new Repository<Groups>().Update(entityGroup);
                    break;
                case 2:
                    var entityDirection = new Repository<Directions>().Get((_entity as Directions).Id);
                    entityDirection.Title = tbOne.Text;
                    entityDirection.GroupCode = tbSecond.Text;
                    entityDirection.Profile = tbThird.Text;
                    entityDirection.DepartmentId = (cmbFirst.SelectedItem as Departments).Id;
                    new Repository<Directions>().Update(entityDirection);
                    break;
                case 3:
                    var entityDepartment = new Repository<Departments>().Get((_entity as Departments).Id);
                    entityDepartment.Title = tbSecond.Text;
                    new Repository<Departments>().Update(entityDepartment);
                    break;
                case 4:
                    var entityTeacher = new Repository<CompositionOfTeachers>().Get((_entity as CompositionOfTeachers).Id);
                    entityTeacher.FullName = tbOne.Text;
                    entityTeacher.Post = tbSecond.Text;
                    new Repository<CompositionOfTeachers>().Update(entityTeacher);
                    break;
            }
        }
    }
}
