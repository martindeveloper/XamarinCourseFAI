using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace UltimateTasksManager.Model
{
	public class TasksCollection : ObservableCollection<TaskEntity>
	{
		private static TasksCollection Instance;

		private TasksCollection ()
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

