using StorageWPF.Client.ViewsModels;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;

namespace StorageWPF
{
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _timer;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(MainViewModel viewModel) : this()
        {
            DataContext = viewModel;
            _timer = new DispatcherTimer(
                TimeSpan.FromSeconds(1),
                DispatcherPriority.Normal,
                UpdateCurrentDateTime,
                Dispatcher);

            Closing += MainWindow_Closing;
        }

        private void UpdateCurrentDateTime(object? sender, EventArgs e)
        {
            if (DataContext is MainViewModel vm)
            {
                vm.CurrentDateTime = DateTime.Now;
            }
        }

        private void MainWindow_Closing(object? sender, CancelEventArgs e)
        {
            _timer.Stop();

            if (DataContext is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}