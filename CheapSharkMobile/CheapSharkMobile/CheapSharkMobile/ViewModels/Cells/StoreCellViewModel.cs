using System;
using GalaSoft.MvvmLight;
using Xamarin.Forms;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Ioc;

namespace CheapSharkMobile
{
	public class StoreCellViewModel : ViewModelBase
	{

		bool on;

		public bool On { 
			get{ return on; } 
			set { 
				if (Application.Current.Properties.ContainsKey ("StoreFilters")) {
					var filters = Application.Current.Properties ["StoreFilters"] as Dictionary<int,bool>;
					if (filters.ContainsKey (storeId)) {
						filters [storeId] = value;
					} else {
						filters.Add (storeId, value);
					}
				}
				Messenger.Default.Send (new RefreshDealsPageMessage ());
				Set (() => On, ref on, value); 
			}
		}

		public string StoreName{ get; set; }

		int storeId;

		public int StoreId {
			get{ return storeId; }
			set {
				Set (() => StoreId, ref storeId, value);
			}
		}


		public StoreCellViewModel ()
		{
			
		}
	}
}

