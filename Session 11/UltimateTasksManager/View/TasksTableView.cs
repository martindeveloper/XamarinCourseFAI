using System;
using Foundation;
using UIKit;
using UltimateTasksManager.Model;

namespace UltimateTasksManager.View
{
	[Register ("TasksTableView")]
	public class TasksTableView : UITableView
	{
		public TasksTableView (IntPtr ptr) : base (ptr)
		{
		}

		public void SetSourceAndSubscribeToEvent(TasksTableViewSource source, TasksRepository model)
		{
			model.TasksCollectionChanged += (TasksCollection tasks) => {
				((TasksTableViewSource)Source).SetNewTasksCollection(tasks);
				ReloadData();
			};

			Source = source;
		}
	}
}

