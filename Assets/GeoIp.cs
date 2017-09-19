using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class GeoIP
{
	public string ip;
	public string country_code;
	public string country_name;
	public string region_code;
	public string region_name;
	public string city;
	public int zip_code;
	public string time_zone;
	public float latitude;
	public float longitude;
}

[Serializable]
public class Woeid
{
	public string woeid;
}

[Serializable]
public class Weather
{
	public string weather_state_name;
	public string the_temp;
}