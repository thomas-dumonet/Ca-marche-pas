using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class marcEvent{
	public string name;
	public int length;
	public AudioClip sound;
 	public bool is_validated;
	public bool is_interruptor;

	public marcEvent(string iname, int ilength, AudioClip isound, bool iis_validated, bool iis_interruptor){
		name = iname;
		length = ilength;
		sound = isound;
		is_validated = iis_validated;
		is_interruptor = iis_interruptor;
	}
}
