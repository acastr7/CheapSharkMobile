using System;
using Xamarin.Forms;

namespace CheapSharkMobile
{
	public class DetailsSub : ContentView
	{
		public DetailsSub (CardViewModel card)
		{
			var labelStyle = new Style (typeof(Label))
				.Set (Label.FontSizeProperty, 8)
				.Set (Label.TextColorProperty, StyleKit.MediumGrey)
				.Set (Image.VerticalOptionsProperty, LayoutOptions.Center);

			var iconStyle = new Style (typeof(Image))
				.Set (Image.HeightRequestProperty, 10)
				.Set (Image.WidthRequestProperty, 10)
				.Set (Image.VerticalOptionsProperty, LayoutOptions.Center);

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
					new Label () {
						Text = card.MetaCriticScore.ToString (),
						Style = labelStyle,
					},
					new BoxView () { Color = Color.Transparent, WidthRequest = 20 },
					new FontAwesomeLabel () {
						Text = FontAwesomeLabel.FACalendar,
						FontSize = 10,
						BackgroundColor = Xamarin.Forms.Color.Transparent,
						XAlign = Xamarin.Forms.TextAlignment.Center,
						YAlign = Xamarin.Forms.TextAlignment.Center
					},
					new Label () {
						Text = card.ReleaseDate.ToString ("d"),
						Style = labelStyle,
					}
				}
			};

			Content = stack;
		}
	}
}

