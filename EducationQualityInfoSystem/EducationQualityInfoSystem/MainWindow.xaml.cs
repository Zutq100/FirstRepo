using EducationQualityInfoSystem.EFCore.Models;
using EducationQualityInfoSystem.EFCore.Repository;
using System.Windows;
using System.Windows.Annotations;

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
        private void cmbSelectTable_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var index = cmbSelectTable.SelectedIndex;
            lbMain.Items.Clear();
            switch (index)
            {
                case 0:
                    new MainRepository<MainModel>().GetAll().ForEach(x => lbMain.Items.Add(x));
                    break;
                case 1:
                    new MainRepository<StudentsModel>().GetAll().ForEach(x => lbMain.Items.Add(x));
                    break;
                case 2:
                    new MainRepository<QualityModel>().GetAll().ForEach(x => lbMain.Items.Add(x));
                    break;
                case 3:
                    new MainRepository<DisciplinesModel>().GetAll().ForEach(x => lbMain.Items.Add(x));
                    break;
                case 4:
                    new MainRepository<DayOfWeekModel>().GetAll().ForEach(x => lbMain.Items.Add(x));
                    break;
            }
        }
    }
}