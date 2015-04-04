using System;
using SQLite.Net;

namespace CheapSharkMobile
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection ();
	}
}

