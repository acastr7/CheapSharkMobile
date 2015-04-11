using System;
using SQLite.Net.Attributes;

namespace CheapSharkMobile
{
	public class FilterSetting
	{
		[PrimaryKey, AutoIncrement, Column ("_id")]
		public int Id { get; set; }

		public string Setting { get; set; }

		public int Value { get; set; }
	}
}

