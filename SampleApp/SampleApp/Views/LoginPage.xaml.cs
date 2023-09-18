using SampleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtUsername.Text))
                {
                    if (!string.IsNullOrEmpty(txtPassword.Text))
                    {
                        if (txtUsername.Text.Equals("faizan") && txtPassword.Text.Equals("password"))
                            await Shell.Current.GoToAsync("//main");
                        else
                            await Shell.Current.GoToAsync("//login/invaliduser");
                    }
                    else
                    {
                        AppServices.ShortAlert("Enter Password");
                    }
                }
                else
                {
                    AppServices.ShortAlert("Enter Username");
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                await Shell.Current.GoToAsync($"//login/registration");
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }
    }
}