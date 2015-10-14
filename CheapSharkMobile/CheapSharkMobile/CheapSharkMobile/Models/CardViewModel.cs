using System;
using Xamarin.Forms;
using GalaSoft.MvvmLight.Command;
using System.Diagnostics;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;

namespace CheapSharkMobile
{
	public class CardViewModel : ViewModelBase
	{
		RelayCommand configIconTapCommand;

		public RelayCommand ConfigIconTapCommand {
			get {
				return configIconTapCommand ?? (configIconTapCommand = new RelayCommand (ConfigIconTapped));
			}
		}

		RelayCommand buyDealCommand;

		public RelayCommand BuyDealCommand {
			get {
				return buyDealCommand ?? (buyDealCommand = new RelayCommand (delegate {
					Device.OpenUri (new Uri (DealUrl));
				}));
			}
		}

		readonly INavigationService Navigation;

		public CardViewModel (INavigationService navigation)
		{
			Navigation = navigation;
		}

		public string Price { get; set; }

		public string GameImage { get; set; }

		public FormattedString Title { get; set; }

		public string Description { get; set; }

		public string MetaCriticScore { get; set; }

		public DateTime ReleaseDate { get; set; }

		public string DealUrl { get; set; }

		public int GameId { get; set; }


		void ConfigIconTapped ()
		{
			Navigation.NavigateTo ("EmailNotificationsModal", new object[]{ Title.ToString (), GameId });
		}
	}

}

