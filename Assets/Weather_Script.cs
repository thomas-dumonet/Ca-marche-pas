using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Weather_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(Get_geoip());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Get_geoip()
	{
		GeoIP my_geoip_data;
		WWW www = new WWW("freegeoip.net/json");
		yield return www;
		my_geoip_data = JsonUtility.FromJson<GeoIP> (www.text);
		//print (my_geoip_data.country_name);
		//print (my_geoip_data.longitude);
		//print (my_geoip_data.latitude);
		StartCoroutine(Get_location_data(my_geoip_data.latitude, my_geoip_data.longitude));
	}

	IEnumerator Get_location_data(float lattitude, float longitude)
	{
		Woeid my_woeid;
		//print ("www.metaweather.com/api/location/search/.lattlong=" + lattitude + "," + longitude);
		WWW www = new WWW("www.metaweather.com/api/location/search/?lattlong="+lattitude+","+longitude);
		yield return www;

		string pattern = @"[^\[].+?(?=}).";
		Regex regex = new Regex (pattern, RegexOptions.None);
		Match m = regex.Match (www.text);

		my_woeid = JsonUtility.FromJson<Woeid> (m.Value);
		StartCoroutine (Get_weather (my_woeid.woeid));
	}

	IEnumerator Get_weather(string woeid){
		WWW www = new WWW ("https://www.metaweather.com/api/location/" + woeid);
		yield return www;

		string pattern = @"(?<=:\[)[^:].+?(?=}).";
		Regex regex = new Regex (pattern, RegexOptions.None);
		Match m = regex.Match (www.text);

		Weather my_weather;
		my_weather = JsonUtility.FromJson<Weather> (m.Value);
		print (my_weather.weather_state_name);
		print (my_weather.the_temp);
	}

}
