using System;
using Xamarin.Forms;

namespace CheapSharkMobile
{
	public class DetailsSub : ContentView
	{
		public DetailsSub ()
		{
			var labelStyle = new Style (typeof(Label))
				.Set (Label.FontSizeProperty, 8)
				.Set (Label.TextColorProperty, StyleKit.MediumGrey)
				.Set (Image.VerticalOptionsProperty, LayoutOptions.Center);

			var iconStyle = new Style (typeof(Image))
				.Set (Image.HeightRequestProperty, 10)
				.Set (Image.WidthRequestProperty, 10)
				.Set (Image.VerticalOptionsProperty, LayoutOptions.Center);

			var metaLabel = new Label () {
				Style = labelStyle,
			};

			metaLabel.SetBinding (Label.TextProperty, "MetaCriticScore");
			var releaseLabel = new Label () {
				Style = labelStyle,
			};
			releaseLabel.SetBinding (Label.TextProperty, new Binding (path: "ReleaseDate", stringFormat: "{0:d}"));
			var stack = new StackLayout () {
				VerticalOptions = LayoutOptions.Center,
				HeightRequest = 20,
				Padding = new Thickness (0),
				Orientation = StackOrientation.Horizontal,
				Children = {
					new FontAwesomeLabel () {
						Text = FontAwesomeLabel.FAStar,
						FontSize = 10,
						BackgroundColor = Xamarin.Forms.Color.Transparent,
						XAlign = Xamarin.Forms.TextAlignment.Center,
						YAlign = Xamarin.Forms.TextAlignment.Center
					},
					metaLabel,
					new BoxView () { Color = Color.Transparent, WidthRequest = 20 },
					new FontAwesomeLabel () {
						Text = FontAwesomeLabel.FACalendar,
						FontSize = 10,
						BackgroundColor = Xamarin.Forms.Color.Transparent,
						XAlign = Xamarin.Forms.TextAlignment.Center,
						YAlign = Xamarin.Forms.TextAlignment.Center
					},
					releaseLabel
				}
			};

			Content = stack;
		}
	}
}

