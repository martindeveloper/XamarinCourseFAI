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

		public void SetSource(TasksTableViewSource source)
		{
			TasksCollection.GetInstance().CollectionChanged += (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => {
				ReloadData();
			};

			Source = source;
		}
	}
}

