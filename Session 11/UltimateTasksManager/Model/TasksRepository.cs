using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UltimateTasksManager.Model
{
	public class TasksRepository
	{
		private TasksCollection Tasks;
		private TasksSqliteStorage Database;
	
		public delegate void TasksCollectionChangedHandler (TasksCollection tasks);
		public event TasksCollectionChangedHandler TasksCollectionChanged;

		public TasksRepository (TasksSqliteStorage database)
		{
			Database = database;

			Tasks = new TasksCollection ();
		}

		public async Task RefreshDataFromDatabase ()
		{
			Tasks = new TasksCollection ();
			List<TaskEntity> list = await Database.GetAll ();

			list.ForEach (task => {
				Tasks.Add(task);
			});
		}

		private void InvokeEventTasksCollectionChanged ()
		{
			if (TasksCollectionChanged != null) {
				TasksCollection tasks = GetAll (); // Get copy of collection
				TasksCollectionChanged (tasks);
			}
		}

		private TaskEntity FindOriginalEntityByCopy (TaskEntity copy)
		{
			return Tasks.Find (item => (copy.Id == item.Id));
		}

		public async void Add (TaskEntity task)
		{
			int id = await Database.Add (task);

			task.Id = id;
			Tasks.Add (task);

			InvokeEventTasksCollectionChanged();
		}

		public void Update (TaskEntity task, bool InvokeEvent = true)
		{
			TaskEntity source = FindOriginalEntityByCopy (task);
			source.CopyDataFromTaskEntity (task);

			// TODO: Think more about InvokeEvent problem
			if (InvokeEvent) {
				InvokeEventTasksCollectionChanged ();
			}

			Database.Update (source);
		}

		public void Delete (TaskEntity task)
		{
			TaskEntity originalTask = FindOriginalEntityByCopy (task);
			Tasks.Remove (originalTask);

			InvokeEventTasksCollectionChanged();

			Database.Delete (originalTask);
		}

		public TasksCollection GetAll ()
		{
			TasksCollection copy = new TasksCollection ();

			Tasks.ForEach ((item) => {
				copy.Add ((TaskEntity)item.Clone ()); // Clone every TaskEntity inside
			});

			return copy;
		}
	}
}

