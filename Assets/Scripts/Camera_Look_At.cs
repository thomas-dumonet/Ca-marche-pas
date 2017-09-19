//SmoothLookAt.cs
//Written by Jake Bayer
//Written and uploaded November 18, 2012
//This is a modified C# version of the SmoothLookAt JS script.  Use it the same way as the Javascript version.

using UnityEngine;
using System.Collections;

///<summary>
///Looks at a target
///</summary>
[AddComponentMenu("Camera-Control/Smooth Look At CS")]
public class Camera_Look_At : MonoBehaviour {
	public Transform target;

	public Transform targetHand;
	public Transform targetScreen;

	public bool lookScreen;

	public GameObject WhereScriptIs;
	//an Object to lock on to
	public float damping = 6.0f;	//to control the rotation 
	public bool smooth = true;
	public float minDistance = 10.0f;	//How far the target is from the camera
	public string property = "";

	private Color color;
	private float alpha = 1.0f;
	private Transform _myTransform;

	public Follow_mouse AcessScript_FM;

	void Awake() {
		_myTransform = transform;
	}


	void Start () {
		AcessScript_FM = WhereScriptIs.GetComponent<Follow_mouse> ();
		lookScreen = false;


	}

	// Update is called once per frame
	void Update () {

	


	}
	void LateUpdate() {

		if (AcessScript_FM.Hand_Touch == true && AcessScript_FM.CameraOnKeyboard == true) {
			
			print ("gros pééééddéééééé");
			StartCoroutine (LookScreen ());
		}

		if (lookScreen == false) {
			target = targetHand;
		}


		if(target) {
			if(smooth) {

				//Look at and dampen the rotation
				Quaternion rotation = Quaternion.LookRotation(target.position - _myTransform.position);
				_myTransform.rotation = Quaternion.Slerp(_myTransform.rotation, rotation, Time.deltaTime * damping);
			}
			else { //Just look at
				_myTransform.rotation = Quaternion.FromToRotation(-Vector3.forward, (new Vector3(target.position.x, target.position.y, target.position.z) - _myTransform.position).normalized);

				float distance = Vector3.Distance(target.position, _myTransform.position);

				if(distance < minDistance) {
					alpha = Mathf.Lerp(alpha, 0.0f, Time.deltaTime * 2.0f);
				}
				else {
					alpha = Mathf.Lerp(alpha, 1.0f, Time.deltaTime * 2.0f);


				}
			}
		}



	}

	IEnumerator LookScreen() {
		float RandomTime = Random.Range (0.5f, 2.0f);
		float RandomTimeScreenWatching = Random.Range (2.0f, 10.0f);
		yield return new WaitForSeconds(RandomTime);
		lookScreen = true;
		target = targetScreen;
		yield return new WaitForSeconds(RandomTimeScreenWatching);
		lookScreen = false;


	}

}