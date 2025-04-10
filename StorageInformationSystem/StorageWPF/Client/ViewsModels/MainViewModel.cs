using StorageWPF.Client.Services;
using StorageWPF.Client.ViewsModels;
using System.Windows.Input;
namespace StorageWPF.Client.ViewsModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ApiClient _apiClient;
        private ViewModelBase _currentViewModel;
        private DateTime _currentDateTime = DateTime.Now;

        public MainViewModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
            CurrentViewModel = new ItemsViewModel(_apiClient, this);

            NavigateToItemsCommand = new RelayCommand(_ =>
                CurrentViewModel = new ItemsViewModel(_apiClient, this));
        }

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public DateTime CurrentDateTime
        {
            get => _currentDateTime;
            set
            {
                _currentDateTime = value;
                OnPropertyChanged();
            }
        }

        public ICommand NavigateToItemsCommand { get; }
    }
}
