using MvvmCross.Platform;
using Plugin.Fingerprint.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Fingerprint_test
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnAuthenticate(object sender, EventArgs e)
        {
            lblStatus.Text = "";

            var fpService = Mvx.Resolve<IFingerprint>();
            var result = await fpService.AuthenticateAsync("Prove you have fingers!");

            await SetResultAsync(result);
        }


        private async Task SetResultAsync(FingerprintAuthenticationResult result)
        {
            if (result.Authenticated)
            {
                await Navigation.PushAsync(new SecretView());
            }
            else
            {
                lblStatus.Text = $"{result.Status}: {result.ErrorMessage}";
            }
        }
    }
}
