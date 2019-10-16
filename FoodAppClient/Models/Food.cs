using System;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;

namespace FoodAppClient.Models
{
    public class Food : ObservableObject
    {
        public string Id { get; set; }

        private string _name = String.Empty;

        private int _kkal;

        private int _weight;

        [JsonProperty(PropertyName = "name")]
        public string Name
        {
            get => this._name;
            set => Set(ref _name, value, "Name");
        }

        [JsonProperty(PropertyName = "kkal")]
        public int Kkal
        {
            get => this._kkal;
            set => Set(ref _kkal, value, "Kkal");
        }

        [JsonProperty(PropertyName = "weight")]
        public int Weight
        {
            get => this._weight;
            set => Set(ref _weight, value);
        }

        public PFC Description { get; set; }

        public Food()
        {
            Description = new PFC();
        }
    }
}
