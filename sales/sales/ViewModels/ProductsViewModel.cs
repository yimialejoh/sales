using GalaSoft.MvvmLight.Command;
using sales.common.Models;
using sales.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace sales.ViewModels
{
    public class ProductsViewModel :BaseViewModel
    {
        private apiService apliservice;

        private bool isRefreshing;

        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get { return this.products; }
            set { this.SetValue(ref this.products, value); }
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }

        public ProductsViewModel()
        {
            this.apliservice = new apiService();
            this.LoadProducts();
        }

        private async void LoadProducts()
        {

            this.IsRefreshing = true;

            var connection = await this.apliservice.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");
                return;
            }

            var url = Application.Current.Resources["UrlAPI"].ToString();
            var response = await this.apliservice.Getlist<Product>(url, "/api", "/Products");
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }
            var list = (List<Product>)response.Result;
            this.Products = new ObservableCollection<Product>(list);
            this.IsRefreshing = false;
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadProducts);
            }
         }
    }
}
