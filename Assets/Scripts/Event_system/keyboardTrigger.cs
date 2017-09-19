using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboardTrigger : MonoBehaviour {
	private string script1, script2, script3;
	private keyboardKey pressed_key;
	public EventPlayer eplayer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		marcEvent mon_event;
		if (col.gameObject.GetComponent<keyboardKey> ()) {
			pressed_key = col.gameObject.GetComponent<keyboardKey> ();
			if (pressed_key.scripts.Count != 0) {
				if (pressed_key.is_random==true) {
					mon_event = pressed_key.scripts [Random.Range (0, pressed_key.scripts.Count)];
				} else {
					mon_event = pressed_key.scripts [0];
				}
				print (mon_event.name);
				if (eplayer.Play_Event(mon_event) == true) {
					pressed_key.scripts.Remove (mon_event);
				}
			} else {
				print ("Cannot play event");
			}
		}
	}
}
