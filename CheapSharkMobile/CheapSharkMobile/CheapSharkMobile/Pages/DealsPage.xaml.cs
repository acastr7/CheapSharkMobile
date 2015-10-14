using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace CheapSharkMobile
{
	public partial class DealsPage : ContentPage
	{
		public DealsPage ()
		{
			InitializeComponent ();

			this.BindViewModel<DealsPageViewModel> ();

			DealListView.ItemSelected += (sender, e) => {
				((ListView)sender).SelectedItem = null;
			};
		}
			
	}
}

