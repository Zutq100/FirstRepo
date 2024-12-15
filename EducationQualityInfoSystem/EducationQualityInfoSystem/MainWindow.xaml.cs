using EducationQualityInfoSystem.EFCore.Models;
using EducationQualityInfoSystem.EFCore.Repository;
using System.Windows;
using System.Windows.Controls;

namespace EducationQualityInfoSystem
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void cmbSelectTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = cmbSelectTable.SelectedIndex;
            lbMain.Items.Clear();
            switch (index)
            {
                case 0:
                    new MainRepository<MainModel>().GetAll(new List<string> { nameof(MainModel.Students) }).ForEach(x => lbMain.Items.Add(x));
                    break;
                case 1:
                    new MainRepository<StudentsModel>().GetAll().ForEach(x => lbMain.Items.Add(x));
                    break;
                case 2:
                    new MainRepository<QualityModel>().GetAll(QualityModel.GetAllIncludes()).ForEach(x => lbMain.Items.Add(x));
                    break;
                case 3:
                    new MainRepository<DisciplinesModel>().GetAll().ForEach(x => lbMain.Items.Add(x));
                    break;
                case 4:
                    new MainRepository<DayOfWeekModel>().GetAll().ForEach(x => lbMain.Items.Add(x));
                    break;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var content = txtSearch.Text;
            if (content.Length >= 1)
            {
                lbMain.Items.Clear();
                var keyWords = content.Split(' ').ToList();
                if (cbiDayOfWeek.IsSelected == true)
                {
                    var results = new MainRepository<DayOfWeekModel>().GetAll();
                    foreach (var result in results.Where(x => keyWords.All(kw => x.ToString().ToLower().Contains(kw.ToLower()))))
                        lbMain.Items.Add(result);
                    return;
                }
                if (cbiQuality.IsSelected == true)
                {
                    var results = new MainRepository<QualityModel>().GetAll(QualityModel.GetAllIncludes());
                    foreach (var result in results.Where(x => keyWords.All(kw => x.ToString().ToLower().Contains(kw.ToLower()))))
                        lbMain.Items.Add(result);
                    return;
                }
            }
            cmbSelectTable_SelectionChanged(null, null);
        }

        private void btnAddUpd_Click(object sender, RoutedEventArgs e)
        {
            var index = cmbSelectTable.SelectedIndex;
            switch (index)
            {
                case 1:
                    var windowStudent = lbMain.SelectedItem == null ? new Window1(this) : new Window1(this, lbMain.SelectedItem as StudentsModel);
                    windowStudent.Show();
                    this.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    var windowQuality = lbMain.SelectedItem == null ? new Window1(this) : new Window1(this, lbMain.SelectedItem as QualityModel);
                    windowQuality.Show();
                    this.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void btnDlt_Click(object sender, RoutedEventArgs e)
        {
            var index = cmbSelectTable.SelectedIndex;
            switch (index)
            {
                case 1:
                    new MainRepository<StudentsModel>().Delete((lbMain.SelectedItem as StudentsModel).ID);
                    break;
                case 2:
                    new MainRepository<QualityModel>().Delete((lbMain.SelectedItem as QualityModel).Id);
                    break;
            }
        }

        private void btnIsEvaluated_Click(object sender, RoutedEventArgs e)
        {
            if (lbMain.SelectedItem is null)
                return;
            if (cmbSelectTable.SelectedIndex != 2)
                return;
            var repo = new MainRepository<QualityModel>();
            var model = lbMain.SelectedItem as QualityModel;
            if (model.IsEvaluated is false)
            {
                model.IsEvaluated = true;
                repo.Update(model);
                UpdateQuality(model);
                return;
            }
            model.IsEvaluated = false;
            repo.Update(model);
            UpdateQuality(model);
        }

        private void btnIsPresent_Click(object sender, RoutedEventArgs e)
        {
            if (lbMain.SelectedItem is null)
                return;
            if (cmbSelectTable.SelectedIndex != 2)
                return;
            var repo = new MainRepository<QualityModel>();
            var model = lbMain.SelectedItem as QualityModel;
            if (model.IsPresent is false)
            {
                model.IsPresent = true;
                repo.Update(model);
                UpdateQuality(model);
                return;
            }
            model.IsPresent = false;
            repo.Update(model);
            UpdateQuality(model);
        }

        public void UpdateQuality(QualityModel target)
        {
            var repoMain = new MainRepository<MainModel>();
            var listQualityStudent = new MainRepository<QualityModel>().GetAll(QualityModel.GetAllIncludes()).Where(x => x.StudentID == target.StudentID);

            double count = listQualityStudent.Count() * 2;
            double countPresent = listQualityStudent.Select(x => x.IsPresent).Where(x => x == true).Count();
            double countEval = listQualityStudent.Select(x => x.IsEvaluated).Where(x => x == true).Count();

            var student = repoMain.GetAll(new List<string> { nameof(MainModel.Students) }).Where(x => x.StudentsID == target.StudentID).First();
            
            var result = (countPresent + countEval) / count * 100;

            student.EducationQuality = (int)result;

            repoMain.Update(student);
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
            => cmbSelectTable_SelectionChanged(null, null);
    }
}