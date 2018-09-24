using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Search;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Exam_Paper
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

        }
        private async void SearchButton(object sender, RoutedEventArgs e)
        {
            string fileName = this.FileName.Text;
            string content = this.ContentText.Text;

            try
            {


                StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                string contentAsync = await FileIO.ReadTextAsync(file);
                if (contentAsync.Contains(content))
                {
                    DisplayNotification("Success ", "File Found ");
                }

                else
                {
                    DisplayNotification("Warning", "File found but text not found!");
                }

            }
            catch (Exception exception)
            {
                if (exception.GetType() == typeof(FileNotFoundException))
                {
                    DisplayNotification("Warning ", "File Not Found");
                }
                else
                {
                    DisplayNotification("Warning ", "Other err");

                }

            }
           

        }

        private async void DisplayNotification(string title, string content)
        {
            ContentDialog notification = new ContentDialog()
            {
                Title = title,
                Content = content,
                CloseButtonText = "ok"
            };
            await notification.ShowAsync();
        }
    }
}
