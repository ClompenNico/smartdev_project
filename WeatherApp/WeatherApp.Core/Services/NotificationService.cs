using MvvmCross.Plugins.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Core.Models;

namespace WeatherApp.Core.Services
{
    public class NotificationService
    {
        public NotificationService(IMvxFileStore fileStore)
        {
            _fileStore = fileStore;
        }

        private static IMvxFileStore _fileStore;
        private static string _folderName = "Notification";
        private static string _fileName = "DailySummary";
        private static string Tekst = GlobalVariables.ToggleDailyValue.ToString();
        //private readonly GlobalVariables _globalVariables;

        public static void SaveToFile()
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

        public static void ReadFromFile()
        {
            try
            {
                string contents = string.Empty;
                _fileStore.TryReadTextFile(_folderName + "/" + _fileName, out contents);
                GlobalVariables.FileValue = contents;
                //return Tekst = contents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
    }
}
