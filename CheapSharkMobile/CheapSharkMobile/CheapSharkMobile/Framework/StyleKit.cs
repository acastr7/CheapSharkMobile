﻿using System;
using Xamarin.Forms;

namespace CheapSharkMobile
{
	public static class StyleKit
	{
		public static Color MediumGrey = Color.FromHex ("9F9F9F");
		public static Color CardBorderColor = Color.FromHex ("E3E3E3");
		public static Color LightTextColor = Color.FromHex ("383838");

		public static Color BarBackgroundColor = Color.FromHex ("375587");
		public static Color CardFooterBackgroundColor = Color.FromHex ("F6F6F6");

		public static class Status
		{
			public static Color CompletedColor = Color.FromHex ("00A2D3");
			public static Color AlertColor = Color.FromHex ("E74C3C");
			public static Color UnresolvedColor = Color.FromHex ("C5C5C5");
		}

		public class Icons
		{
			public static FileImageSource Steam = new FileImageSource () { File = "steam.png" };
			public static FileImageSource GamersGate = new FileImageSource () { File = "gamersgate.png" };
			public static FileImageSource GreenManGaming = new FileImageSource () { File = "greenmangaming.png" };
			public static FileImageSource Amazon = new FileImageSource () { File = "amazon.png" };
			public static FileImageSource BundleStars = new FileImageSource () { File = "bundlestars.png" };
			public static FileImageSource GamesRocket = new FileImageSource () { File = "gamesrocket.png" };
			public static FileImageSource GoG = new FileImageSource () { File = "gog.png" };
			public static FileImageSource Origin = new FileImageSource () { File = "origin.png" };
			public static FileImageSource GetGames = new FileImageSource () { File = "getgames.png" };


			public static FileImageSource Alert = new FileImageSource () { File = "Alert.png" };
			public static FileImageSource Resume = new FileImageSource () { File = "Resume.png" };
			public static FileImageSource Completed = new FileImageSource () { File = "Completed.png" };
			public static FileImageSource Report = new FileImageSource () { File = "Report.png" };
			public static FileImageSource Unresolved = new FileImageSource () { File = "Unresolved.png" };
			public static FileImageSource Cog = new FileImageSource () { File = "Config.png" };
			public static FileImageSource SmallCalendar = new FileImageSource () { File = "Calendarmini.png" };
			public static FileImageSource SmallClock = new FileImageSource () { File = "Clockmini.png" };

			public static FileImageSource Shadow0240 = new FileImageSource () { File = "Shadow-0-2-4-0.png" };
		}
	}
}

