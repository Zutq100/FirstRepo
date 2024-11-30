using EducationQualityInfoSystem.EFCore.Models;
using EducationQualityInfoSystem.EFCore.Repository;
using System.Windows;
using System.Windows.Controls;

namespace EducationQualityInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
                    new MainRepository<QualityModel>().GetAll(new List<string> { nameof(QualityModel.Student), nameof(QualityModel.Disciplines), nameof(QualityModel.DayOfWeek) }).ForEach(x => lbMain.Items.Add(x));
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
                    var results = new MainRepository<QualityModel>().GetAll(new List<string> { nameof(QualityModel.Student), nameof(QualityModel.Disciplines), nameof(QualityModel.DayOfWeek) });
                    foreach (var result in results.Where(x => keyWords.All(kw => x.ToString().ToLower().Contains(kw.ToLower()))))
                        lbMain.Items.Add(result);
                    return;
                }
            }
            cmbSelectTable_SelectionChanged(null, null);
        }
    }
}