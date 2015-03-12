using System;
using System.Collections.ObjectModel;

namespace UltimateTasksManager.Model
{
	public class TasksCollection : ObservableCollection<TaskEntity>
	{
		private static TasksCollection Instance;

		public TasksCollection ()
		{}

		public static TasksCollection GetInstance()
		{
			if (Instance == null) {
				Instance = new TasksCollection ();
			}

			return Instance;
		}
	}
}

