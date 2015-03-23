using System;
using System.IO;
using SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace UltimateTasksManager
{
	public class GenericSqliteStorage<T> where T : new()
	{
		public string DatabaseVersionString = "v1";
		protected string PathToDatabase;
		protected SQLiteAsyncConnection ConnectionAsync;

		public GenericSqliteStorage ()
		{
			string documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			PathToDatabase = Path.Combine(documents, String.Format("Database_{0}.db", DatabaseVersionString));
		}

		~GenericSqliteStorage ()
		{
			CloseAllConnections ();
		}

		public void CreateConnection ()
		{
			ConnectionAsync = new SQLiteAsyncConnection (PathToDatabase);
		}

		public void CloseAllConnections ()
		{
			SQLiteConnectionPool.Shared.Reset ();
		}

		public bool IsDatabaseFileExist()
		{
			return File.Exists (PathToDatabase);
		}

		public async Task CreateDatabase()
		{
			await ConnectionAsync.CreateTableAsync<T> ();
		}

		public async Task<List<T>> GetAll ()
		{
			AsyncTableQuery<T> tasksTable = ConnectionAsync.Table<T> ();
			List<T> list = await tasksTable.ToListAsync ();

			return list;
		}

		public async Task<int> Add (T task)
		{
			int id = await ConnectionAsync.InsertAsync (task);

			return id;
		}

		public async void Delete (T task)
		{
			// No need to wait
			await ConnectionAsync.DeleteAsync (task);
		}

		public async void Update (T task)
		{
			// no need to wait
			await ConnectionAsync.UpdateAsync (task);
		}
	}
}

