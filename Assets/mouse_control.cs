using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_control : MonoBehaviour {

	public Plane groundPlane;
	public float rest_height;
	public float lower_height;
	public float speed = 2.5f ;
	public float clampx =0.0f ;
	public float clampz = 0.0f ;
	public GameObject center_empty;

	private bool is_up;
	private Vector3 rest_vector;
	private Vector3 lower_vector;
	// Use this for initialization
	void Start () {
		rest_vector = new Vector3 (0, rest_height, 0);
		lower_vector = new Vector3 (0, lower_height, 0);
		groundPlane = new Plane (Vector3.up, rest_vector);
		is_up = true;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetMouseButtonDown (0)) {
			is_up = false;
		}
		if (Input.GetMouseButtonUp(0)){
			is_up = true;
		}

		//Vector3.Lerp(rest_vector, targPos, Time.deltaTime * speed);
		if (is_up == true) {
			groundPlane.SetNormalAndPosition (Vector3.up, Vector3.Lerp(transform.position, rest_vector, Time.deltaTime * speed));
		} else {
			groundPlane.SetNormalAndPosition (Vector3.up, Vector3.Lerp(transform.position, lower_vector, Time.deltaTime * speed));
		}

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float rayDistance;
		if (groundPlane.Raycast (ray, out rayDistance))
			gameObject.transform.position = ray.GetPoint (rayDistance);
		gameObject.transform.position = new Vector3 (Mathf.Clamp (gameObject.transform.position.x, center_empty.transform.position.x-clampx, center_empty.transform.position.x+clampx), gameObject.transform.position.y, Mathf.Clamp (gameObject.transform.position.z, center_empty.transform.position.z-clampz, center_empty.transform.position.z+clampz));
	}
}
