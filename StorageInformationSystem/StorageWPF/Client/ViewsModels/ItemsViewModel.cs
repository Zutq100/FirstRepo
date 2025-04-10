using StorageWPF.Client.Models;
using StorageWPF.Client.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StorageWPF.Client.ViewsModels
{
    public class ItemsViewModel : ViewModelBase
    {
        private readonly ApiClient _apiClient;
        private readonly MainViewModel _mainViewModel;
        private ObservableCollection<StorageItem> _items = new();
        private string _searchText = string.Empty;

        public ItemsViewModel(ApiClient apiClient, MainViewModel mainViewModel)
        {
            _apiClient = apiClient;
            _mainViewModel = mainViewModel;

            LoadItemsCommand = new RelayCommand(async _ => await LoadItems());
            AddItemCommand = new RelayCommand(_ => AddItem());
            EditItemCommand = new RelayCommand(EditItem);
            DeleteItemCommand = new RelayCommand(async item => await DeleteItem(item as StorageItem));
            ViewDetailsCommand = new RelayCommand(ViewDetails);
            _ = LoadItems();
        }

        public ObservableCollection<StorageItem> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                _ = LoadItems();
            }
        }

        public ICommand LoadItemsCommand { get; }
        public ICommand AddItemCommand { get; }
        public ICommand EditItemCommand { get; }
        public ICommand DeleteItemCommand { get; }
        public ICommand ViewDetailsCommand { get; }

        private async Task LoadItems()
        {
            var items = await _apiClient.GetItemsAsync();
            var filteredItems = string.IsNullOrWhiteSpace(SearchText)
                ? items
                : items.Where(i =>
                    i.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                    i.ArticleNumber.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                    (i.Description?.Contains(SearchText, StringComparison.OrdinalIgnoreCase) == true));

            Items = new ObservableCollection<StorageItem>(filteredItems);
        }

        private void AddItem()
        {
            var newItem = new StorageItem();
            _mainViewModel.CurrentViewModel = new ItemEditViewModel(_apiClient, _mainViewModel, newItem);
        }

        private void EditItem(object? parameter)
        {
            if (parameter is StorageItem item)
            {
                _mainViewModel.CurrentViewModel = new ItemEditViewModel(_apiClient, _mainViewModel, item);
            }
        }

        private async Task DeleteItem(StorageItem? item)
        {
            if (item != null)
            {
                await _apiClient.DeleteItemAsync(item.Id);
                await LoadItems();
            }
        }

        private void ViewDetails(object? parameter)
        {
            if (parameter is StorageItem item)
            {
                _mainViewModel.CurrentViewModel = new ItemDetailViewModel(_apiClient, _mainViewModel, item);
            }
        }
    }
}
