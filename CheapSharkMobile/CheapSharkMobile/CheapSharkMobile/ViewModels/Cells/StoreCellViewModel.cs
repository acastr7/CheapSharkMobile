using System;
using GalaSoft.MvvmLight;

namespace CheapSharkMobile
{
	public class StoreCellViewModel : ViewModelBase
	{
		bool on;

		public bool On { 
			get{ return on; } 
			set{ Set (() => On, ref on, value); }
		}

		public string StoreName{ get; set; }

		int storeId;

		public int StoreId {
			get{ return storeId; }
			set {
				Set (() => StoreId, ref storeId, value);
			}
		}
	}
}

