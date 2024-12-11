using System.Text;
using System.Windows;
using FaculityInform.EFCore.Context;
using FaculityInform.EFCore.Models;
using FaculityInform.Repository;

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
            new Repository<Students>().GetAll(nameof(Students.Group)).ForEach(x => lbText.Items.Add(x));
        }


    }
}