using SampleApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.ViewModels
{
    
    public class AppShellViewModel : BaseViewModel
    {
        public ICommand LogoutCommand { get; private set; }
        public AppShellViewModel()
        {
            LogoutCommand = new Command(() =>
            {
                Shell.Current.GoToAsync("//login");
            });
        }
    }
}
