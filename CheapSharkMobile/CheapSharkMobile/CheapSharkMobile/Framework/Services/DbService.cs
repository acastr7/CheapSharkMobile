using System;
using SQLite.Net;
using GalaSoft.MvvmLight.Ioc;
using System.Linq.Expressions;
using System.Linq;

namespace CheapSharkMobile
{
	public class DbService
	{
		readonly SQLiteConnection database;

		public DbService ()
		{
			database = SimpleIoc.Default.GetInstance<ISQLite> ().GetConnection ();
			database.CreateTable<FilterSetting> ();

		}

		public FilterSetting GetSettingByName (string name)
		{
			return database.Table<FilterSetting> ().FirstOrDefault (x => x.Setting.Equals (name, StringComparison.CurrentCultureIgnoreCase));
		}

		/// <summary>
		/// Save the specified entity by calling insert or update, if the entity already exists.
		/// </summary>
		/// <param name="pk">The primary key of the entity</param>
		/// <param name="obj">The instance of the entity</param>
		/// <typeparam name="T">The entity type.</typeparam>
		public int Save<T> (object pk, object obj) where T : new()
		{
			if (pk == null || database.Find<T> (pk) == null) {
				return database.Insert (obj);
			}
			return database.Update (obj);
		}

		/// <summary>
		/// Delete entities based on a predicate function
		/// </summary>
		/// <param name="predicate">The predicate specifying which entities to delete</param>
		/// <typeparam name="T">The entity type.</typeparam>
		public void Delete<T> (Expression<Func<T, bool>> predicate) where T : new()
		{
			var records = database.Table<T> ().Where (predicate).ToList ();
			foreach (var record in records) {
				database.Delete (record);
			}
		}
	}
}

