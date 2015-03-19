using System;
using UIKit;
using Foundation;
using System.Collections.Generic;

namespace UltimateTasksManager.Model
{
	public class PriorityPickerModel : UIPickerViewModel
	{
		private List<string> Rows;

		public PriorityPickerModel()
		{
			Rows = new List<string> (Enum.GetNames (typeof(TaskPriority)));
		}

		public override nint GetComponentCount (UIPickerView picker)
		{
			return 1;
		}

		public override nint GetRowsInComponent (UIPickerView picker, nint component)
		{
			return Rows.Count;
		}

		public override string GetTitle (UIPickerView picker, nint row, nint component)
		{

			return Rows [(int)row];
		}
	}
}

