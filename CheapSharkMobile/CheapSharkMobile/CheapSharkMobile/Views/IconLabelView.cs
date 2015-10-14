using System;
using Xamarin.Forms;
using NControl.Abstractions;
using System.Diagnostics;

namespace CheapSharkMobile
{
	public class IconLabelView : NControlView
	{
		public IconLabelView (string fontIcon, string text)
		{
			BackgroundColor = StyleKit.CardFooterBackgroundColor;

			var label = new Label () {
				Text = text,
				FontSize = 15,
				FontAttributes = FontAttributes.Bold,
				TextColor = StyleKit.LightTextColor,
				XAlign = Xamarin.Forms.TextAlignment.Center,
				YAlign = Xamarin.Forms.TextAlignment.Center
			};

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
					label
				}
			};

			Content = stack;
		}
			
	}
}

