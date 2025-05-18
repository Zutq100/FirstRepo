using StorageApi.DTO;
using StorageWPF.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using StorageWPF.Client.Models;
using StorageWPF.Client.Views;
using System.Security.Policy;

namespace StorageWPF.Client.ViewsModels
{
    public class AddQuintyMovementModel : ViewModelBase
    {
        private readonly ApiClient _apiClient;
        private readonly Action _refreshCallback;

        public string WindowTitle { get; }
        public string ItemName { get; }
        public bool CanDelete { get; }

        public StorageMovement CurrentMovement { get; set; }
        public StorageMovement NewMovement { get; set; }
        public Dictionary<MovementType, string> MovementTypes { get; } = new()
    {
        { MovementType.Receipt, "Приход" },
        { MovementType.Consumption, "Расход" },
        { MovementType.Transfer, "Перемещение" },
        { MovementType.Adjustment, "Корректировка" }
    };

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand CancelCommand { get; }

        public AddQuintyMovementModel(ApiClient apiClient, int itemId, string itemName,
                               StorageMovement movement = null,
                               Action refreshCallback = null)
        {
            _apiClient = apiClient;
            ItemName = itemName;
            CurrentMovement = movement;
            _refreshCallback = refreshCallback;
            if (CurrentMovement == null)
            {
                NewMovement = new StorageMovement()
                {
                    MovementDate = DateTime.Now,
                    StorageItemId = itemId
                };
            }

            CanDelete = movement != null;
            WindowTitle = movement != null ? "Редактирование перемещения" : "Новое перемещение";
            

            SaveCommand = new RelayCommand(async _ => await SaveMovement());
            DeleteCommand = new RelayCommand(async _ => await DeleteMovement());
            CancelCommand = new RelayCommand(_ => CloseWindow());
        }

        private async Task SaveMovement()
        {
            try
            {
                if (CurrentMovement == null)
                {
                    await _apiClient.CreateMovementAsync(NewMovement);
                }
                else
                {
                    await _apiClient.UpdateMovementAsync(CurrentMovement.Id, CurrentMovement);
                }
                _refreshCallback?.Invoke();
                CloseWindow();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private async Task DeleteMovement()
        {
            if (MessageBox.Show("Удалить это перемещение?", "Подтверждение",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    await _apiClient.DeleteMovementAsync(CurrentMovement.Id);
                    _refreshCallback?.Invoke();
                    CloseWindow();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления: {ex.Message}");
                }
            }
        }

        private void CloseWindow()
        {

            Application.Current.Windows.OfType<AddQuintyMovementWindow>()
                .FirstOrDefault(w => w.DataContext == this)?
                .Close();
        }
    }
}
