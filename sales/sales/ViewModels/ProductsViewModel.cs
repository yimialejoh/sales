using sales.common.Models;
using sales.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace sales.ViewModels
{
    public class ProductsViewModel :BaseViewModel
    {
        private apiService apliservice;
        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get { return this.products; }
            set { this.SetValue(ref this.products, value); }
        }

        public ProductsViewModel()
        {
            this.apliservice = new apiService();
            this.loadProducts();
        }

        private async void loadProducts()
        {
            var response = await this.apliservice.Getlist<Product>("https://salesitmapi.azurewebsites.net", "/api", "/Products");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }
            var list = (List<Product>)response.Result;
            this.Products = new ObservableCollection<Product>(list);
        }
    }
}
