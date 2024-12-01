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
using EducationQualityInfoSystem.EFCore.Repository;
using EducationQualityInfoSystem.EFCore.Models;
using System.DirectoryServices.ActiveDirectory;

namespace EducationQualityInfoSystem
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private MainWindow _main;
        public Window1()
        {
            InitializeComponent();
        }

        public Window1(MainWindow main) : this()
        {
            _main = main;
            if (_main.cmbSelectTable.SelectedIndex == 1)
                tbFirst.Visibility = Visibility.Visible;
            if (_main.cmbSelectTable.SelectedIndex == 2)
            {
                cmbFirst.Visibility = Visibility.Visible;
                cmbSecond.Visibility = Visibility.Visible;
                cmbThird.Visibility = Visibility.Visible;
                cmbFirst.ItemsSource = new MainRepository<StudentsModel>().GetAll();
                cmbSecond.ItemsSource = new MainRepository<DisciplinesModel>().GetAll();
                cmbThird.ItemsSource = new MainRepository<DayOfWeekModel>().GetAll();
            }
        }

        public Window1(MainWindow main, StudentsModel model) : this(main)
        {
            var repo = new MainRepository<StudentsModel>();
            tbFirst.Text = repo.Get(model.ID).FullName;
            lblName.Content = "Редактор учащегося";
        }

        public Window1(MainWindow main, QualityModel model) : this(main)
        {
            var repoStudent = new MainRepository<StudentsModel>();
            var repoDisciplines = new MainRepository<DisciplinesModel>();
            var repoDayOfWeek = new MainRepository<DayOfWeekModel>();

            lblName.Content = "Редактор успеваемости";
            cmbFirst.ItemsSource = repoStudent.GetAll();
            cmbSecond.ItemsSource = repoDisciplines.GetAll();
            cmbThird.ItemsSource = repoDayOfWeek.GetAll();
            cmbFirst.SelectedIndex = repoStudent.GetAll().IndexOf(repoStudent.Get(model.StudentID));
            cmbSecond.SelectedIndex = repoDisciplines.GetAll().IndexOf(repoDisciplines.Get(model.DisciplineID));
            cmbThird.SelectedIndex = repoDayOfWeek.GetAll().IndexOf(repoDayOfWeek.Get(model.DayOfWeekID));
        }

        private void btnAddUpd_Click(object sender, RoutedEventArgs e)
        {
            if (_main.lbMain.SelectedItem is null)
            {
                AddUpd();
                this.Close();
                return;
            }

            var index = _main.cmbSelectTable.SelectedIndex;
            
            switch (index)
            {
                case 1:
                    AddUpd(new MainRepository<StudentsModel>().Get((_main.lbMain.SelectedItem as StudentsModel).ID));
                    _main.lbMain.Items.Clear();
                    new MainRepository<StudentsModel>().GetAll().ForEach(x => _main.lbMain.Items.Add(x));
                    goto default;
                case 2:
                    AddUpd(new MainRepository<QualityModel>().Get((_main.lbMain.SelectedItem as QualityModel).Id));
                    _main.lbMain.Items.Clear();
                    new MainRepository<QualityModel>().GetAll(new List<string> { nameof(QualityModel.Student), nameof(QualityModel.Disciplines), nameof(QualityModel.DayOfWeek) }).ForEach(x => _main.lbMain.Items.Add(x));
                    goto default;
                default:
                    this.Close();
                    break;
            }
        }
        private void AddUpd(StudentsModel model)
        {
            model.FullName = tbFirst.Text;
            new MainRepository<StudentsModel>().Update(model);
        }

        private void AddUpd(QualityModel model)
        {
            model.StudentID = (cmbFirst.SelectedItem as StudentsModel).ID;
            model.DisciplineID = (cmbSecond.SelectedItem as DisciplinesModel).ID;
            model.DayOfWeekID = (cmbThird.SelectedItem as DayOfWeekModel).ID;
            new MainRepository<QualityModel>().Update(model);
        }

        private void AddUpd()
        {
            var index = _main.cmbSelectTable.SelectedIndex;
            switch (index)
            {
                case 1:
                    new MainRepository<StudentsModel>().Create(new StudentsModel() { FullName = tbFirst.Text.TrimStart().TrimEnd()});
                    _main.lbMain.Items.Clear();
                    new MainRepository<StudentsModel>().GetAll().ForEach(x => _main.lbMain.Items.Add(x));
                    break;
                case 2:
                    new MainRepository<QualityModel>().Create(new QualityModel() { StudentID = (cmbFirst.SelectedItem as StudentsModel).ID, DisciplineID = (cmbSecond.SelectedItem as DisciplinesModel).ID, DayOfWeekID = (cmbThird.SelectedItem as DayOfWeekModel).ID });
                    _main.lbMain.Items.Clear();
                    new MainRepository<QualityModel>().GetAll(new List<string> { nameof(QualityModel.Student), nameof(QualityModel.Disciplines), nameof(QualityModel.DayOfWeek) }).ForEach(x => _main.lbMain.Items.Add(x));
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
            => this.Close();

        private void Window_Closed(object sender, EventArgs e)
        {
            _main.Visibility = Visibility.Visible;
        }
    }
}
