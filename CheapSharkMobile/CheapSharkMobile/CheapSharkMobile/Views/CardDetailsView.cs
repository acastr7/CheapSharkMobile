using System;
using Xamarin.Forms;

namespace CheapSharkMobile
{
	public class CardDetailsView : ContentView
	{
		public CardDetailsView (CardViewModel card)
		{
			BackgroundColor = Color.White;

			Label TitleText = new Label () {
				FormattedText = card.Title,
				FontSize = 18,
				TextColor = StyleKit.LightTextColor,
				LineBreakMode = LineBreakMode.TailTruncation
			};

			Label DescriptionText = new Label () {
				FormattedText = card.Description,
				FontSize = 12,
				TextColor = StyleKit.LightTextColor
			};

			var heading = new StackLayout () {
				Spacing = 0,
				Padding = new Thickness (10, 0, 0, 0),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Children = {
					TitleText,
					DescriptionText,
				}
			};

			var headingContainer = new StackLayout () {
				Spacing = 0,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Horizontal,
				Children = {
					new Image {
						Source = card.GameImage,
						HorizontalOptions = LayoutOptions.Start,
						WidthRequest = 70
					},
					heading,
				}
			};


			var stack = new StackLayout () {
				Spacing = 0,
				Padding = new Thickness (10, 0, 0, 0),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Children = {
					headingContainer,
					new DetailsSub (card)
				}
			};

			Content = stack;
		}
	}
}

