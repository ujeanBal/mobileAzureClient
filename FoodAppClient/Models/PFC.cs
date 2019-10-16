using System;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;

namespace FoodAppClient.Models
{
    public class PFC : ObservableObject
    {
        private int _proteins;

        private int _fats;

        private int _carbohydrates;

        [JsonProperty(PropertyName = "proteins")]
        public int Proteins
        {
            get => _proteins;
            set => Set(ref _proteins, value);
        }

        [JsonProperty(PropertyName = "fats")]
        public int Fats
        {
            get => _fats;
            set => Set(ref _fats, value);
        }

        [JsonProperty(PropertyName = "carbohydrates")]
        public int Carbohydrates
        {
            get => _carbohydrates;
            set => Set(ref _carbohydrates, value);
        }
        public PFC()
        {
        }
    }
}
