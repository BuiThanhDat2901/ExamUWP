using ExamUWP.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ExamUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            List<Contact> listContact = Data.DatabaseInitialize.ListContact();
            
        }

        private async void Add(object sender, RoutedEventArgs e)
        {
            var contact = new Contact()
            {
                Name = txtName.Text,
                PhoneNumber = txtPhone.Text,
            };
            ContentDialog contentDialog = new ContentDialog();
            if (Data.DatabaseInitialize.SaveTables(contact))
            {
                contentDialog.Title = "Acction success";
                contentDialog.Content = "Them thanh cong";
            }
            else
            {
                contentDialog.Title = "Acction fail";
                contentDialog.Content = "Them that bai";
            }
            contentDialog.CloseButtonText = "OK";
            await contentDialog.ShowAsync();
            List<Contact> listContact = Data.DatabaseInitialize.ListContact();
            
        }

        private async void Search(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Contact> listContact = Data.DatabaseInitialize.searchContactByName(txtSearch.Text);
              
            }
            catch
            {
                ContentDialog contentDialog = new ContentDialog();
                contentDialog.Title = "Lỗi!";
                contentDialog.Content = "Contact not found";
                contentDialog.CloseButtonText = "Oke";
                await contentDialog.ShowAsync();
            }
        }
    }
}
