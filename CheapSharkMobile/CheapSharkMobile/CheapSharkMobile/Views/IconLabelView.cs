using System;
using Xamarin.Forms;
using NControl.Abstractions;
using System.Diagnostics;

namespace CheapSharkMobile
{
	public class IconLabelView : NControlView
	{
		public Label TextLabel { get; set; }

		public IconLabelView (string fontIcon)
		{
			BackgroundColor = StyleKit.CardFooterBackgroundColor;

			TextLabel = new Label () {
				FontSize = 15,
				FontAttributes = FontAttributes.Bold,
				TextColor = StyleKit.LightTextColor,
				XAlign = Xamarin.Forms.TextAlignment.Center,
				YAlign = Xamarin.Forms.TextAlignment.Center
			};

			TextLabel.SetBinding (Label.TextProperty, "Price");

			var stack = new StackLayout () {
				Padding = new Thickness (5),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.Center,
				Children = {
					new FontAwesomeLabel () {
						Text = fontIcon,
						BackgroundColor = Xamarin.Forms.Color.Transparent,
						XAlign = Xamarin.Forms.TextAlignment.Center,
						YAlign = Xamarin.Forms.TextAlignment.Center
					},
					TextLabel
				}
			};

			Content = stack;
		}
			
	}
}

