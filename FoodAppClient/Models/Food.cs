using System;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;

namespace FoodAppClient.Models
{
    public class Food : ObservableObject
    {

        public string Id { get; set; }

        private string _name = String.Empty;

        private long _kkal;

        private long _weight;

        private long _proteins;

        private long _fats;

        private long _carbohydrates;

        private string _image;

        public string Image
        {
            get => this._image;
            set => Set(ref _image, value, "Image");
        }

        public string Name
        {
            get => this._name;
            set => Set(ref _name, value, "Name");
        }


        public long Kkal
        {
            get => this._kkal;
            set => Set(ref _kkal, value, "Kkal");
        }

        public long Weight
        {
            get => this._weight;
            set => Set(ref _weight, value, "Weight");
        }

        public long Proteins
        {
            get => _proteins;
            set => Set(ref _proteins, value, "Proteins");
        }


        public long Fats
        {
            get => _fats;
            set => Set(ref _fats, value, "Fats");
        }


        public long Carbohydrates
        {
            get => _carbohydrates;
            set => Set(ref _carbohydrates, value, "Carbohydrates");
        }



        public Food()
        {

        }
    }
}
