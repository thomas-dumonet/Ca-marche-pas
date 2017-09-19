using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboardKey : MonoBehaviour {
	public bool is_random=false;
	public List<marcEvent> scripts;
	public AudioSource audiosc;
	private float xpos, ypos, zpos;
	private float xrot, yrot, zrot;
	public float travel_height=0;
	// Use this for initialization
	void Start () {
		xpos = transform.position.x;
		ypos = transform.position.y;
		zpos = transform.position.z;

		xrot = transform.rotation.eulerAngles.x;
		yrot = transform.rotation.eulerAngles.y;
		zrot = transform.rotation.eulerAngles.z;
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y > ypos) {
			transform.position = new Vector3 (xpos, ypos, zpos);
		} else if (transform.position.y < (ypos - travel_height)) {
			transform.position = new Vector3 (xpos, (ypos - travel_height), zpos);
		} else {
			transform.position = new Vector3 (xpos, transform.position.y, zpos);
		}
		transform.rotation = Quaternion.Euler (xrot, yrot, zrot);
	}
}
