using Microsoft.OpenApi.Extensions;
using StorageWPF.Client.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StorageWPF.Client.Views
{
    /// <summary>
    /// Логика взаимодействия для ItemDetailsView.xaml
    /// </summary>
    public partial class ItemDetailsView : UserControl
    {
        public ItemDetailsView()
        {
            InitializeComponent();
        }
        public Dictionary<MovementType, string> MovementTypes { get; } = new()
    {
        { MovementType.Receipt, "Приход" },
        { MovementType.Consumption, "Расход" },
        { MovementType.Transfer, "Перемещение" },
        { MovementType.Adjustment, "Корректировка" }
    };

    }
}
