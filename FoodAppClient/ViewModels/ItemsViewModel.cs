using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
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

        public RelayCommand<FoodDetailViewModel> DetailNavigateCommand { get; set; }

        public RelayCommand NewNavigateCommand { get; set; }

        public ItemsViewModel(INavigationService navigationService)
        {
            Title = "Browse";
            Items = new ObservableCollection<Food>();
            LoadItemsCommand = new RelayCommand(async () => await ExecuteLoadItemsCommand());
            AddItemCommand = new RelayCommand<Food>(async (Food food) => await AddItem(food));
            DetailNavigateCommand = new RelayCommand<FoodDetailViewModel>((FoodDetailViewModel food) => DetailNavigate(food));
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

        async Task AddItem(Food item)
        {
            Items.Add(item);
            await DataStore.AddItemAsync(item);
        }

        async Task UpdateItem(Food item)
        {
            await DataStore.UpdateItemAsync(item);
        }
    }
}
