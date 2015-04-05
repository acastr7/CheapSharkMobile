using System;
using Newtonsoft.Json;

namespace CheapSharkMobile
{
	public class EpochToDateTimeConverter : JsonConverter
	{
		#region implemented abstract members of JsonConverter

		public override bool CanConvert (Type objectType)
		{
			return objectType == typeof(DateTime);
		}

		public override object ReadJson (JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var t = (long)reader.Value;
			return new DateTime (1970, 1, 1).AddSeconds (t);
		}

		public override void WriteJson (JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException ();
		}

		#endregion

		public EpochToDateTimeConverter ()
		{
		}
	}
}

