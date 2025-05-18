using StorageWPF.Client.Services;
using StorageWPF.Client.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using StorageApi.DTO;
using Microsoft.AspNetCore.Mvc.Formatters;
using StorageWPF.Client.Views;
using System.Windows;
using System.Reflection.Metadata;

namespace StorageWPF.Client.ViewsModels
{
    public class ItemDetailViewModel : ViewModelBase
    {
        private readonly ApiClient _apiClient;
        private readonly MainViewModel _mainViewModel;
        private StorageItem _item;
        private StorageMovement _newMovement;
        private ObservableCollection<StorageMovement> _movements;

        public ItemDetailViewModel(ApiClient apiClient, MainViewModel mainViewModel, StorageItem item)
        {
            _apiClient = apiClient;
            _mainViewModel = mainViewModel;
            _item = item;

            LoadMovementsCommand = new RelayCommand(async _ => await LoadMovements());
            EditItemCommand = new RelayCommand(_ => EditItem());
            BackCommand = new RelayCommand(_ => BackToList());
            AddMovementCommand = new RelayCommand(_ => AddMovement());
            UpdateMovementCommand = new RelayCommand(UpdateMovement);

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
        public StorageMovement NewMovement
        {
            get => _newMovement;
            set
            {
                _newMovement = value;
                OnPropertyChanged();
            }
        }
        
        public ObservableCollection<StorageMovement> Movements
        {
            get
            {
                return _movements;
            }

            set
            {
                _movements = value;
                OnPropertyChanged();
            }
        }

        public string Title => $"Item Details: {Item.Name}";

        public ICommand UpdateMovementCommand { get; }
        public ICommand LoadMovementsCommand { get; }
        public ICommand EditItemCommand { get; }
        public ICommand BackCommand { get; }
        public ICommand AddMovementCommand { get; }
        private void AddMovement()
        {
             var vm = new AddQuintyMovementModel(
            _apiClient,
            Item.Id,
            Item.Name,
            refreshCallback: async () =>await LoadMovements());
        
        new AddQuintyMovementWindow { DataContext = vm, Owner = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive)}.ShowDialog();
        }
        private void UpdateMovement(object parameter)
        {
            if (parameter is StorageMovement movement)
            {
                NewMovement = movement;
                var vm = new AddQuintyMovementModel(
                    _apiClient,
                    Item.Id,
                    Item.Name,
                    NewMovement,
                    refreshCallback: async () => await LoadMovements());

                new AddQuintyMovementWindow { DataContext = vm, Owner = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive) }.ShowDialog();
            }
        }
        private async Task LoadMovements()
        {
            Movements = new ObservableCollection<StorageMovement>(await _apiClient.GetMovementsAsync(Item.Id));
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
