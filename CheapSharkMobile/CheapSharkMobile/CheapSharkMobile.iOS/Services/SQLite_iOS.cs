using System;
using System.IO;

namespace CheapSharkMobile.iOS
{
	public class SQLite_iOS : ISQLite
	{
		public SQLite_iOS ()
		{
		}

		public SQLite.Net.SQLiteConnection GetConnection ()
		{
			var sqliteFilename = "CheapSharkMobile.db3";
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
			string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
			var path = Path.Combine (libraryPath, sqliteFilename);
			#if DEBUG
			Console.WriteLine ("###### Database Path: {0}", path);
			#endif

			// Create the connection
			var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS ();
			var conn = new SQLite.Net.SQLiteConnection (plat, path);
			// Return the database connection
			return conn;
		}

	}
}

