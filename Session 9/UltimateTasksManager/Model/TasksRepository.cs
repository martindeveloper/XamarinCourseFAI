using System;
using System.Linq;

namespace UltimateTasksManager.Model
{
	public class TasksRepository
	{
		private TasksCollection Tasks;

		public delegate void TasksCollectionChangedHandler (TasksCollection tasks);
		public event TasksCollectionChangedHandler TasksCollectionChanged;

		public TasksRepository ()
		{
			Tasks = RefreshDataFromDatabase ();
		}

		private TasksCollection RefreshDataFromDatabase ()
		{
			return new TasksCollection ();
		}

		private void InvokeEventTasksCollectionChanged ()
		{
			if (TasksCollectionChanged != null) {
				TasksCollection tasks = GetAll (); // Get copy of collection
				TasksCollectionChanged (tasks);
			}
		}

		public void Add (TaskEntity task)
		{
			Tasks.Add (task);

			// TODO: Insert into DB async
			InvokeEventTasksCollectionChanged();
		}

		public void Update (TaskEntity task, bool InvokeEvent = true)
		{
			TaskEntity source = Tasks.Find (item => (task.Id == item.Id));

			source.Id = task.Id;
			source.State = task.State;
			// TODO: Update all properties here OR create update method in task entity class
			// TODO: Think more about InvokeEvent problem

			if (InvokeEvent) {
				InvokeEventTasksCollectionChanged ();
			}
		}

		public void Delete (TaskEntity task)
		{
			Tasks.Remove (Tasks.Find(item => (task.Id == item.Id)));

			// TODO: Insert into DB async
			InvokeEventTasksCollectionChanged();
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

