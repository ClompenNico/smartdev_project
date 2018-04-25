using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Core.Models;

namespace WeatherApp.Core.ViewModels
{
    public class NotificationsViewModel : MvxViewModel
    {
        /*
        private IMvxFileStore _fileStore;
        private string _folderName;
        private string _fileName;
        private string Tekst;
        */

        public NotificationsViewModel(/*IMvxFileStore fileStore*/)
        {
            /*
            _fileStore = fileStore;

            if (GlobalVariables.ToggleDailyValue == true)
            {
                string vs = "super";
            }
            */
        }

        //HIER KAN JE DE WAARDE PROBEREN OPSLAAN VOOR MOCHT DE APP AFGESLOTEN ZIJN :)

        /*
        private void SaveToFile()
        {
            try
            {
                if (!_fileStore.FolderExists(_folderName))
                    _fileStore.EnsureFolderExists(_folderName);

                _fileStore.WriteFile(_folderName + "/" + _fileName, Tekst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ReadFromFile()
        {
            try
            {
                string contents = string.Empty;
                _fileStore.TryReadTextFile(_folderName + "/" + _fileName, out Tekst);
                Tekst = contents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        */
    }
}
