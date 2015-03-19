using System;
using Foundation;
using UIKit;
using UltimateTasksManager.Model;
using System.Threading.Tasks;

namespace UltimateTasksManager.Controller
{
	[Register ("TaskDetailViewController")]
	partial class TaskDetailViewController : UIViewController
	{
		public TaskEntity SelectedTask { get; set; }
		public TasksRepository TasksModel;

		private WeatherModel WeatherAPI;

		public TaskDetailViewController (IntPtr ptr) : base (ptr)
		{
			WeatherAPI = new WeatherModel ();
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			// Set data from item
			if (SelectedTask != null) {
				TitleLabel.Text = SelectedTask.Title;

				if (SelectedTask.State) {
					TitleLabel.TextColor = UIColor.Green;
				}

				DescriptionLabel.Text = SelectedTask.Description;
				DueDateLabel.Text = SelectedTask.DueDate.ToLongDateString ();
				// TODO: Priority

				// Load weather data
				LoadWeather();
			} else {
				throw new ArgumentException ("You must set SelectedTask property to show detail view!");
			}
		}

		private async void LoadWeather()
		{
			try{
				// TODO: Item will have location itself, not hardcoded in code
				Weather condition = await WeatherAPI.FetchWeatherForLocationAsync("Czech Republic, Zlín");
				ForecastLabel.Text = String.Format ("{0} {1}°C", condition.Text, condition.Temperature);
			}catch(WeatherModelException ex) {
				ForecastLabel.Text = "Forecast unavailable...";

#if DEBUG
				ForecastLabel.Text = ex.Message;
#endif

				ForecastLabel.TextColor = UIColor.Red;
			}
		}

		partial void DeleteButtonTapped (NSObject sender)
		{
			string[] buttons = { "Yes" };
			UIAlertView alert = new UIAlertView ("Confirmation", "Are you sure to delete this task?", null, "No", buttons);

			alert.Clicked += (object alertSender, UIButtonEventArgs e) => {
				switch (e.ButtonIndex) {
				case 0:
					// No
					break;
				case 1:
					// Yes
					TasksModel.Delete (SelectedTask);

					NavigationController.PopViewController (true);
					break;
				}
			};

			alert.Show ();
		}
	}
}

