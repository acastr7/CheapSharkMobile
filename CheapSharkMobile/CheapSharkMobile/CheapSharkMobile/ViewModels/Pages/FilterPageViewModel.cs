using System;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Xamarin.Forms;
using GalaSoft.MvvmLight.Messaging;

namespace CheapSharkMobile
{
	public class FilterPageViewModel : BasePageViewModel
	{
		RelayCommand doneCommand;

		public RelayCommand DoneCommand {
			get {
				return doneCommand ?? (doneCommand = new RelayCommand (delegate {
					Messenger.Default.Send (new RefreshDealsPageMessage ());
					Navigation.GoBack ();
				}));
			}
		}

		int minSliderValue;

		public int MinSliderValue {
			get {
				return minSliderValue;
			}
			set {
				if (value > maxSliderValue) {
					MaxSliderValue = value;
				}
				Application.Current.Properties ["lowerPrice"] = value;
				Set (() => MinSliderValue, ref minSliderValue, value);
			}
		}

		int maxSliderValue = 50;

		public int MaxSliderValue {
			get {
				return maxSliderValue;
			}
			set {
				if (value < minSliderValue) {
					MinSliderValue = value;
				}
				Application.Current.Properties ["upperPrice"] = value;
				Set (() => MaxSliderValue, ref maxSliderValue, value);
			}
		}

		int metaSliderValue;

		public int MetaSliderValue {
			get{ return metaSliderValue; }
			set {
				Application.Current.Properties ["metacritic"] = value;
				Set (() => MetaSliderValue, ref metaSliderValue, value);
			}
		}

		bool tripleA;

		public bool TripleA {
			get{ return tripleA; }
			set {
				Application.Current.Properties ["aaa"] = value;
				Set (() => TripleA, ref tripleA, value);
			}
		}

		bool steamworks;

		public bool Steamworks {
			get { return steamworks; }
			set {
				Application.Current.Properties ["steamworks"] = value;
				Set (() => Steamworks, ref steamworks, value);
			}
		}

		bool onSale;

		public bool OnSale {
			get { return onSale; }
			set {
				Application.Current.Properties ["onSale"] = value;
				Set (() => OnSale, ref onSale, value);
			}
		}

		readonly INavigationService Navigation;

		public FilterPageViewModel (INavigationService navigation)
		{
			Title = "Filters";
			Navigation = navigation;
		}
	}
}

