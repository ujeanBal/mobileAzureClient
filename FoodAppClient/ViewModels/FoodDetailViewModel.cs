using System;
using System.Threading.Tasks;
using FoodAppClient.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace FoodAppClient.ViewModels
{
    public class FoodDetailViewModel : BaseViewModel
    {
        public Food Item { get; set; }

        public RelayCommand<Food> SendToMainCommand { get; set; }

        public NotifycationType ActionMsg { get; set; }

        private string actionTitle = string.Empty;


        public string ActionTitle
        {
            get { return actionTitle; }
            set { SetProperty(ref actionTitle, value); }
        }

        public FoodDetailViewModel(Food item = null)
        {
            if (item != null)
            {
                Title = item.Name;
                Item = item;
            }
            SendToMainCommand = new RelayCommand<Food>((Food food) => SendMessageToAdd(food));
        }


        private void SendMessageToAdd(Food food)
        {
            MessengerInstance.Send(new NotificationMessage<Food>(food, ((int)ActionMsg).ToString()));
        }


    }
}
