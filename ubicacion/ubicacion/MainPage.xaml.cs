using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace ubicacion
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            GetCurrentLocation();
        }

        private async void OnMyLocationButtonClicked(object sender, EventArgs e)
        {
            GetCurrentLocation();
        }

        private async void GetCurrentLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.High);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    var position = new Position(location.Latitude, location.Longitude);
                    map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(1)));
                }
            }
            catch (FeatureNotSupportedException)
            {
                // La geolocalización no es compatible en este dispositivo
            }
            catch (Exception ex)
            {
                // Manejo de errores
            }
        }
    }
}
