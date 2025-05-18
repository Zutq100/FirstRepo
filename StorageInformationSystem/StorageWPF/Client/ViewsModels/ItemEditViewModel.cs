using StorageWPF.Client.Models;
using StorageWPF.Client.Services;
using System.Windows.Input;

namespace StorageWPF.Client.ViewsModels
{
    public class ItemEditViewModel : ViewModelBase
    {
        private readonly ApiClient _apiClient;
        private readonly MainViewModel _mainViewModel;
        private StorageItem _item;
        private bool _isNewItem;

        public ItemEditViewModel(ApiClient apiClient, MainViewModel mainViewModel, StorageItem item)
        {
            _apiClient = apiClient;
            _mainViewModel = mainViewModel;
            _item = item;
            _isNewItem = item.Id == 0;

            SaveCommand = new RelayCommand(async _ => await SaveItem());
            CancelCommand = new RelayCommand(_ => Cancel());
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

        public string Title => _isNewItem ? "New Item" : $"Edit Item: {Item.Name}";

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        private async Task SaveItem()
        {
            try
            {
                if (_isNewItem)
                {
                    var createdItem = await _apiClient.CreateItemAsync(Item);
                    Item = createdItem;
                    _isNewItem = false;
                }
                else
                {
                    await _apiClient.UpdateItemAsync(Item);
                }

                _mainViewModel.CurrentViewModel = new ItemsViewModel(_apiClient, _mainViewModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving item: {ex.Message}");
            }
        }

        private void Cancel()
        {
            _mainViewModel.CurrentViewModel = new ItemsViewModel(_apiClient, _mainViewModel);
        }
    }
}
