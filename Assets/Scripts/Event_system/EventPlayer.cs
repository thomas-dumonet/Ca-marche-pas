using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPlayer : MonoBehaviour{
	private AudioSource audiosrc;
	private marcEvent global_override_event;

	void Start () {
		audiosrc = gameObject.GetComponent<AudioSource> ();
	}

	public void Set_Override_Event(marcEvent m_event){
		global_override_event = m_event;
	}

	public bool Play_Event(marcEvent m_Event){
		if ((audiosrc.isPlaying) == true)
		{
			return false;
		}
		if (global_override_event == null) {
			// ajouter délai
			audiosrc.PlayOneShot (m_Event.sound, 1.0F);
			// set text écran
			// zoom sur écran
			// chargement connerie
			// délais zoom
			// dézoom
			return true;
		} else {
			audiosrc.PlayOneShot (global_override_event.sound, 1.0F);
			global_override_event = null;
			return false;
		}
	}

	public void StopEvent(){
		audiosrc.Stop();
	}
}
