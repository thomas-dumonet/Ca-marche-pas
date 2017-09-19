using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_behaviour : MonoBehaviour {

	public string layer_name = "Default";
	public float min = 50f;
	public float max= 90f;
	public float mouse_limit = 300.0f;
	public float angle_limit = 30f;
	public float zoom_speed=0.1f;
	public float rotation_speed = 2.0f;
	public GameObject screen;

	bool lookatscreen = false;
	float mouse_pos;
	float temp;
	int layer_mask;

	// Use this for initialization
	void Start () {
		layer_mask = LayerMask.GetMask(layer_name);
		Debug.Log (layer_mask);
		temp = (gameObject.GetComponent<Camera> ().fieldOfView - min) / (max - min); 
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			lookatscreen = true;
		}
		if (Input.GetKey (KeyCode.B)) {
			lookatscreen = false;
		}

		if (lookatscreen == false) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			mouse_pos = Input.mousePosition.x - Screen.width / 2;

			if (Physics.Raycast (ray, out hit, Mathf.Infinity, layer_mask)) {
				Debug.Log (hit.transform.gameObject.name);
				temp = Mathf.Clamp (temp + zoom_speed, 0.0f, 1.0f);
				gameObject.GetComponent<Camera> ().fieldOfView = (Mathf.Lerp (min, max, temp));
			} else {
				temp = Mathf.Clamp (temp - zoom_speed, 0.0f, 1.0f);
				gameObject.GetComponent<Camera> ().fieldOfView = (Mathf.Lerp (min, max, temp));
			}

			if (mouse_pos >= mouse_limit) {
				this.transform.rotation = Quaternion.Euler (gameObject.transform.rotation.eulerAngles.x, Mathf.Clamp (gameObject.transform.rotation.eulerAngles.y + rotation_speed, -angle_limit, angle_limit), gameObject.transform.rotation.eulerAngles.z);
			} else if (mouse_pos <= -mouse_limit) {
				this.transform.rotation = Quaternion.Euler (gameObject.transform.rotation.eulerAngles.x, Mathf.Clamp (gameObject.transform.rotation.eulerAngles.y - rotation_speed, -angle_limit, angle_limit), gameObject.transform.rotation.eulerAngles.z);
			} else {
		
			}
		} else {
			gameObject.transform.LookAt (screen.transform.position);
			temp = Mathf.Clamp (temp + zoom_speed, 0.0f, 1.0f);
			gameObject.GetComponent<Camera> ().fieldOfView = (Mathf.Lerp (min, max, temp));
		}
	}
}
