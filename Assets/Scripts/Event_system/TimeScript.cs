using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScript : MonoBehaviour {
	public List<marcEvent> m_events;
	public List<int> temps_events;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < m_events.Count; i++) 
		{
			StartCoroutine (Example (m_events[i], temps_events[i]));
		}
	}

	IEnumerator Example(marcEvent m_event, int temps) {
		print(Time.time);
		yield return new WaitForSeconds(temps);
		print(Time.time);
		gameObject.GetComponent<EventPlayer> ().Set_Override_Event(m_event);
	}
}
