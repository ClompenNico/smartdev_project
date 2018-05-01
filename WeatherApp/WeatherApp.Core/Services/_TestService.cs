/*
using MvvmCross.Plugins.File;
using MvvmCross.Plugins.Messenger;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Core.Messages;
using WeatherApp.Core.Model;

namespace WeatherApp.Core.Services
{
    public class FavouriteLocationService : IFavouriteLocationService
    {
        private IMvxFileStore _mvxFileStore;
        private IMvxMessenger _messenger;
        public FavouriteLocationService(IMvxFileStore mvxFileStore, IMvxMessenger messenger)
        {
            _mvxFileStore = mvxFileStore;
            _messenger = messenger;
        }


        private string _folder = "Test";
        private string _fileName = "Test";
        private String LocalFavouriteListJson;
        private CityFavouriteNames LocalFavouriteListObject = new CityFavouriteNames();

        private List<CityFavouriteNames.Citys> _favouriteCitysList = new List<CityFavouriteNames.Citys>();
        public List<CityFavouriteNames.Citys> favouriteCitysList
        {
            get { return _favouriteCitysList; }
            set
            {
                _favouriteCitysList = value;
            }
        }


        public void SaveCityToFile(CityFavouriteNames.Citys city)
        {
            try
            {
                //Als men wilt deleten deleten
                //_mvxFileStore.DeleteFile(_folder + "/" + _fileName);

                if (!_mvxFileStore.FolderExists(_folder))
                    _mvxFileStore.EnsureFolderExists(_folder);

                //Krijg de laaste upgedate file
                ReadFromFile();


                //Kijken of al in de lijst bevindt.
                if (!favouriteCitysList.Any(item => item.Name == city.Name))
                {
                    favouriteCitysList.Add(city);


                    LocalFavouriteListObject.citys = favouriteCitysList;

                    LocalFavouriteListJson = JsonConvert.SerializeObject(LocalFavouriteListObject);

                    _mvxFileStore.WriteFile(_folder + "/" + _fileName, LocalFavouriteListJson);

                }

                //Lijst updaten
                ReadFromFile();

                PublishList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CityFavouriteNames.Citys>> ReadFromFile()
        {
            try
            {
                string contents = string.Empty;
                _mvxFileStore.TryReadTextFile(_folder + "/" + _fileName, out contents);
                if (contents != null)
                {
                    LocalFavouriteListObject = JsonConvert.DeserializeObject<CityFavouriteNames>(contents);
                    favouriteCitysList = LocalFavouriteListObject.citys;
                    return favouriteCitysList;
                }
                return favouriteCitysList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void RemoveCity(int index)
        {
            favouriteCitysList.RemoveAt(index);

            LocalFavouriteListObject.citys = favouriteCitysList;

            LocalFavouriteListJson = JsonConvert.SerializeObject(LocalFavouriteListObject);

            _mvxFileStore.WriteFile(_folder + "/" + _fileName, LocalFavouriteListJson);

            //Lijst upaten
            ReadFromFile();

            PublishList();
        }

        private void PublishList()
        {
            var message = new FavouriteCityMessage(this, LocalFavouriteListObject);

            _messenger.Publish(message);
        }
    }
}
*/