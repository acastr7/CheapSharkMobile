using System;
using Xamarin.Forms;
using NControl.Abstractions;

namespace CheapSharkMobile
{
	public class ConfigIconView : NControlView
	{
		public ConfigIconView ()
		{
			BackgroundColor = StyleKit.CardFooterBackgroundColor;

			Content = new FontAwesomeLabel () {
				Text = FontAwesomeLabel.FAEnvelope,
				XAlign = Xamarin.Forms.TextAlignment.Center,
				YAlign = Xamarin.Forms.TextAlignment.Center
			};

			var tapGestureRecognizer = new TapGestureRecognizer ();
			tapGestureRecognizer.SetBinding (TapGestureRecognizer.CommandProperty, "ConfigIconTapCommand");

			this.GestureRecognizers.Add (tapGestureRecognizer);

			tapGestureRecognizer.Tapped += async delegate(object sender, EventArgs e) {
				await this.ScaleTo (0.8, 65, Easing.CubicInOut);
				await this.ScaleTo (1.0, 65, Easing.CubicInOut);
			};
		}
	}
}

