using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Graphics;
using CheapSharkMobile;
using CheapSharkMobile.Droid;

[assembly: ExportRenderer (typeof(FontAwesomeLabel), typeof(FontAwesomeLabelRenderer))]
namespace CheapSharkMobile.Droid
{
	public class FontAwesomeLabelRenderer: LabelRenderer
	{
		/// <summary>
		/// Raises the element changed event.
		/// </summary>
		/// <param name="e">E.</param>
		protected override void OnElementChanged (ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged (e);

			if (Control == null)
				return;

			var typeface = Typeface.CreateFromAsset (Forms.Context.Assets, "Fonts/FontAwesome.ttf");
			Control.SetTypeface (typeface, TypefaceStyle.Normal);

		}
	}
}

