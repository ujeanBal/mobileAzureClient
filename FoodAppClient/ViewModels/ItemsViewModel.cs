using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FoodAppClient.iOS.ViewModel;
using FoodAppClient.Models;
using FoodAppClient.ViewModels;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;

namespace FoodAppClient
{
    public class ItemsViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        public ObservableCollection<Food> Items { get; set; }

        public RelayCommand LoadItemsCommand { get; set; }

        public RelayCommand<Food> AddItemCommand { get; set; }

        public RelayCommand<Food> DeleteItemCommand { get; set; }

        public RelayCommand<FoodDetailViewModel> DetailNavigateCommand { get; set; }

        public RelayCommand NewNavigateCommand { get; set; }

        public ItemsViewModel(INavigationService navigationService)
        {
            Title = "Browse";
            Items = new ObservableCollection<Food>();
            LoadItemsCommand = new RelayCommand(async () => await ExecuteLoadItemsCommand());
            AddItemCommand = new RelayCommand<Food>(async (Food food) => await AddItem(food));
            DeleteItemCommand = new RelayCommand<Food>(async (Food food) => await DeleteItem(food));
            DetailNavigateCommand = new RelayCommand<FoodDetailViewModel>(
                (FoodDetailViewModel food) => DetailNavigate(food));
            NewNavigateCommand = new RelayCommand(() => NewNavigate());
            _navigationService = navigationService;
            MessengerInstance.Register<NotificationMessage<Food>>(this, ParsingMessages);

        }

        private async void ParsingMessages(NotificationMessage<Food> obj)
        {
            int notify = Convert.ToInt32(obj.Notification);
            switch (notify)
            {
                case (int)NotifycationType.NeedCreate: await AddItem(obj.Content); break;
                case (int)NotifycationType.NeedUpdate:
                    await UpdateItem(obj.Content); break;
            }
        }

        private void DetailNavigate(FoodDetailViewModel parameter)
        {
            parameter.ActionMsg = NotifycationType.NeedUpdate;
            parameter.ActionTitle = "Update";
            _navigationService.NavigateTo(App.Locator.Details, parameter);
        }

        private void NewNavigate()
        {
            _navigationService.NavigateTo(App.Locator.NewFood,
                new FoodDetailViewModel(new Food())
                {
                    ActionMsg = NotifycationType.NeedCreate,
                    ActionTitle = "Add"
                });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();

                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public double SumKkal
        {
            get => Items?.Count > 0 ? Items.Sum(x => Convert.ToDouble(x.Kkal)) : 0;
        }

        async Task AddItem(Food item)
        {
            IsBusy = true;

            Items.Add(item);
            await DataStore.AddItemAsync(item);

            IsBusy = false;
        }

        async Task DeleteItem(Food item)
        {
            IsBusy = true;

            Items.Remove(item);
            await DataStore.DeleteItemAsync(item.Id);

            IsBusy = false;

        }

        async Task UpdateItem(Food item)
        {
            IsBusy = true;

            await DataStore.UpdateItemAsync(item);

            IsBusy = false;

        }
    }
}
