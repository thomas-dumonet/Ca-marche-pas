using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class real_time_lighting : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		System.DateTime CurrentDate = new System.DateTime();
		CurrentDate = System.DateTime.Now;

		int DaySeconds = (CurrentDate.Hour * 3600) + (CurrentDate.Minute * 60) + (CurrentDate.Second);

		float SunRotationDegrees = DaySeconds * 0.0041667F - 90;//transform.Rotate (SunRotationDegree,0,0);
		SunRotationDegrees %= 360;
		Debug.Log (CurrentDate.Hour);
		transform.eulerAngles = new Vector3(SunRotationDegrees, 0, 0);
	}
}
