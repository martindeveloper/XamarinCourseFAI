using System;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Collections.Generic;

namespace UltimateTasksManager.Model
{
	public struct Weather
	{
		public int Temperature;
		public string Text;
		public DateTime Timestamp;
	}

	public class WeatherModel
	{
		private const string Endpoint = "https://query.yahooapis.com/v1/public/yql?q=select%20item.condition%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22{0}%22)%20and%20u%3D'c'&format=xml&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";

		private static Dictionary<string, Weather> RequestCache = new Dictionary<string, Weather> ();
		private static int RequestCacheLifeTimeInHours = 2;

		public WeatherModel ()
		{
			// TODO: create cache provider model
		}

		public async Task<Weather> FetchWeatherForLocationAsync(string location)
		{
			string cacheKey = location.ToLower ();

			// Check if result is already in cache
			if (RequestCache.ContainsKey (cacheKey)) {

				// Cache is older than life time?
				if (RequestCache [cacheKey].Timestamp.AddHours(RequestCacheLifeTimeInHours) > DateTime.Now) {
					return RequestCache [cacheKey];
				}
			}

			// Insert location into API URL
			string url = String.Format (Endpoint, Uri.EscapeUriString (location));

			HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create (new Uri (url));
			request.Method = "GET";

			WebResponse response;

			try{
				response = await request.GetResponseAsync ();
			}catch(WebException ex){
				throw new WeatherModelException ("API request failed! " + ex.Message);
			}

			using (StreamReader reader = new StreamReader(response.GetResponseStream()))
			{
				string textResult = reader.ReadToEnd();

				XmlDocument resultXml = new XmlDocument ();
				// TODO: Try/catch here
				resultXml.LoadXml (textResult);

				// "condition" node is in namespace, its easier to use FirstChild than NamespaceManager and stuff
				XmlNode node = resultXml.DocumentElement.SelectSingleNode("/query/results/channel/item");

				if (node == null) {
					// Something is wrong - bad response...
					throw new WeatherModelException ("Invalid location provided!");
				}

				node = node.FirstChild;

				int temperature = Int16.Parse(node.Attributes["temp"].Value);
				string text = node.Attributes["text"].Value;

				Weather currentWeather = new Weather {
					Temperature = temperature,
					Text = text,
					Timestamp = DateTime.Now
				};

				// Insert to cache
				RequestCache.Add (cacheKey, currentWeather);

				return currentWeather;
			}
		}
	}
}

