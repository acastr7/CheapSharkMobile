using System;
using Xamarin.Forms;

namespace CheapSharkMobile
{
	public class CardView : ViewCell
	{
		public CardView ()
		{
			Grid grid = new Grid {
				Padding = new Thickness (5, 5, 10, 5),
				RowSpacing = 1,
				ColumnSpacing = 1,		
				BackgroundColor = StyleKit.CardBorderColor,
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions = {
					new RowDefinition { Height = new GridLength (70, GridUnitType.Absolute) },
					new RowDefinition { Height = new GridLength (30, GridUnitType.Absolute) }
				},
				ColumnDefinitions = {
					new ColumnDefinition { Width = new GridLength (4, GridUnitType.Absolute) },
					new ColumnDefinition { Width = new GridLength (100, GridUnitType.Absolute) },
					new ColumnDefinition { Width = new GridLength (50, GridUnitType.Absolute) }
				}
			};

			grid.Children.Add (new CardDetailsView (), 1, 4, 0, 1);

			grid.Children.Add (
				new IconLabelView (
					FontAwesomeLabel.FAMoney
				)
				, 1, 1);


			grid.Children.Add (new ConfigIconView (), 2, 1);

			grid.Children.Add (
				new BuyButtonView (
					FontAwesomeLabel.FAExternalLink,
					"Buy"
				)
				, 3, 1);


			View = grid;
		}

	}
}

