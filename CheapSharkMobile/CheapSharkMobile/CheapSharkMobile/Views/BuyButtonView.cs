using System;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace CheapSharkMobile
{
	public class BuyButtonView : IconLabelView
	{
		public BuyButtonView (string fontIcon, string text) : base (fontIcon, text)
		{
			var tapGestureRecognizer = new TapGestureRecognizer ();
			tapGestureRecognizer.SetBinding (TapGestureRecognizer.CommandProperty, "BuyDealCommand");

			this.GestureRecognizers.Add (tapGestureRecognizer);

			tapGestureRecognizer.Tapped += async delegate(object sender, EventArgs e) {
				await this.ScaleTo (0.8, 65, Easing.CubicInOut);
				await this.ScaleTo (1.0, 65, Easing.CubicInOut);
			};
		}
	}
}

