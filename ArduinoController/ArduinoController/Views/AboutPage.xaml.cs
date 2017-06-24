
using Plugin.BluetoothLE;
using Plugin.BluetoothLE.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArduinoController.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Bluetooth();
        }
        public void Bluetooth()
        {
            var request = HttpWebRequest.CreateHttp("http://192.168.4.1/LEDOn");
            var response = request.GetResponseAsync();
        }
    }
}
