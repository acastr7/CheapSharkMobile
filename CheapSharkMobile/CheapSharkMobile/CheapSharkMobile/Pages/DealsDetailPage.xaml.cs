﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;


namespace CheapSharkMobile
{
	public partial class DealsDetailPage : ContentPage
	{
		readonly string DealId;

		public DealsDetailPage (string dealId)
		{
			InitializeComponent ();
			DealId = dealId;
			this.BindViewModel<DealsDetailPageViewModel> ();
			this.GetViewModel<DealsDetailPageViewModel> ().IsBusy = true;
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			var model = BindingContext as DealsDetailPageViewModel;
			if (model != null) {
				model.GetDeal (DealId);
			}
		}


	}
}

