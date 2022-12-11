using System;
using System.IO;
using System.Threading.Tasks;

using Xamarin.Essentials;

namespace AppForTest.FileHelpers
{
    public class FileOpener
    {
        public async Task<string> PickFile()
        {
            try
            {
                var file = await FilePicker.PickAsync(
                    new PickOptions 
                    {
                        FileTypes =  FilePickerFileType.Pdf,
                        PickerTitle = "Pick a pdf file"
                    });

                if (file == null)
                    return "";

                return file.FullPath;
            }
            catch (Exception)
            {
                return "Error";
            }
        }

        public async Task<bool> OpenFile(string filePath)
        {
            if(!File.Exists(filePath))
                return false;

            await Launcher.OpenAsync(new OpenFileRequest
            {
                File = new ReadOnlyFile(filePath)
            });
            return true;
        }
    }
}
