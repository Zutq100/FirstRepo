using StorageWPF.Client.Services;
using StorageWPF.Client.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace StorageWPF.Client.ViewsModels
{
    public class ItemDetailViewModel : ViewModelBase
    {
        private readonly ApiClient _apiClient;
        private readonly MainViewModel _mainViewModel;
        private StorageItem _item;
        private ObservableCollection<StorageMovement> _movements = new();

        public ItemDetailViewModel(ApiClient apiClient, MainViewModel mainViewModel, StorageItem item)
        {
            _apiClient = apiClient;
            _mainViewModel = mainViewModel;
            _item = item;

            LoadMovementsCommand = new RelayCommand(async _ => await LoadMovements());
            EditItemCommand = new RelayCommand(_ => EditItem());
            BackCommand = new RelayCommand(_ => BackToList());

            _ = LoadMovements();
        }

        public StorageItem Item
        {
            get => _item;
            set
            {
                _item = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<StorageMovement> Movements
        {
            get => _movements;
            set
            {
                _movements = value;
                OnPropertyChanged();
            }
        }

        public string Title => $"Item Details: {Item.Name}";

        public ICommand LoadMovementsCommand { get; }
        public ICommand EditItemCommand { get; }
        public ICommand BackCommand { get; }

        private async Task LoadMovements()
        {
            var movements = await _apiClient.GetMovementsAsync(Item.Id);
            Movements = new ObservableCollection<StorageMovement>(movements);
        }

        private void EditItem()
        {
            _mainViewModel.CurrentViewModel = new ItemEditViewModel(_apiClient, _mainViewModel, Item);
        }

        private void BackToList()
        {
            _mainViewModel.CurrentViewModel = new ItemsViewModel(_apiClient, _mainViewModel);
        }
    }
}
