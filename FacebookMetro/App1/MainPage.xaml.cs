using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Facebook;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Authentication.Web;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        string oauthUrl = "https://www.facebook.com/dialog/oauth?client_id={0}&redirect_uri={1}&scope={2}&display=popup&response_type=token";
        string facebookAppId = "134217053385938";
        string facebookAuthScope = "email";
        string redirectUri = "https://www.facebook.com/connect/login_success.html";

        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var result = await WebAuthenticationBroker.AuthenticateAsync(
                                                    WebAuthenticationOptions.None,
                                                    new Uri(String.Format(oauthUrl, facebookAppId, redirectUri, facebookAuthScope)),
                                                    new Uri(redirectUri));
            if (result.ResponseStatus == WebAuthenticationStatus.Success)
            {
                var client = new FacebookClient();
                var session = client.ParseOAuthCallbackUrl(new Uri(result.ResponseData));
                AccessToken.Text = session.AccessToken;
            }
        }
    }
}
