using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XFAES
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Padding = new Thickness(0,
                Device.OnPlatform(20, 0, 0), 0, 0);

            List<string> month = new List<string>
            {
                "01", "02", "03", "04", "05", "06", "07",
                "08", "09", "10", "11", "12"
            };
            pckrMonth.ItemsSource = month;
            pckrInstallment.ItemsSource = month;
            List<string> year = new List<string>
            {
                "2017", "2016", "2015"
            };
            pckrYear.ItemsSource = year;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var Crypto = DependencyService.Get<ICreditCardCryptor>()
                .AESEncryption(new CreditCard
                {
                    Cvv = txtCvv.Text,
                    Name = txtName.Text,
                    Surname = txtSurname.Text,
                    Number = txtNumber.Text,
                    InstallmentNumber = pckrInstallment.SelectedItem
                    .ToString(),
                    Month = pckrMonth.SelectedItem.ToString(),
                    Year = pckrYear.SelectedItem.ToString()
                });

            var encrypted = Crypto;

            var decrypted = DependencyService.Get<ICreditCardCryptor>
                ().AESDecryption(Crypto);

        }
    }
}