using UnityEngine;
using System.Collections;

public class Follow_mouse : MonoBehaviour {

	//Script to make an object follow the mouse, based on mouse position, in the game screen.

	public GameObject ObjectToMove;
	public GameObject Hand_Control;
	public GameObject Empty_Hand;
	public GameObject Finger;

	public GameObject raycast_destination;

	public Vector3 handPos;

	public Vector3 mousePosInit;
	public Vector3 MousePosStop;
	public Vector3 CameraStop;

	public Vector3 Ymoving;
	public Vector3 YmovingLast;
	public Vector3 YLow;
	public Vector3 YTouch;

	public float hitForce = 500.0f;

	public bool Follow;
	public bool FollowCam;

	public bool CameraOnKeyboard;
	public bool BacktoMolette;

	//public bool lookScreen;

	public bool Hand_Low;
	public bool Hand_Touch;

	public float minFov = 40f;
	public float maxFov = 60f;
	public float sensitivity= 10f;
	public float zoomSpeed = 1.0f;

	float fov;




	// Use this for initialization
	void Start () {
		float fov = Camera.main.fieldOfView;
		Follow = true;
		FollowCam = true;

		Hand_Low = false;
		Hand_Touch = false;
		BacktoMolette = true;

		//lookScreen = false;

		fov = Camera.main.fieldOfView;

		CameraOnKeyboard = false;



	
	}




	// Update is called once per frame
	void Update () {





		/*RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		Vector3 down = transform.TransformDirection(Vector3.down) ;
		Debug.DrawLine(transform.position, Vector3.down, Color.green);

		if (Physics.Raycast(transform.position, ray, 50) && hit.transform.gameObject.tag == "Interactive_Object" ) {
			
				print ("tu es au dessus d'un objet gros FDP");
				Hand_Low = true;



			// Do something with the object that was hit by the raycast.
		}*/


		//Debug.DrawRay(transform.position, down, Color.green);

	

		//Camera.main.fieldOfView = fov;
		if (BacktoMolette == true) {
			fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
			fov = Mathf.Clamp(fov, minFov, maxFov);
			print ("molette=ok");

		}


		if (CameraOnKeyboard == true) {
			fov = 20f;
			BacktoMolette = false;
		}

		if (BacktoMolette == false && CameraOnKeyboard == false) {
			StartCoroutine (BacktoNormalView ());


		}
	


		//______________________________________________________________________________________

		mousePosInit = Input.mousePosition;
		mousePosInit.z = 27.0f;



		//Empty_Hand.transform.position = Camera.main.ScreenToWorldPoint (mousePosInit);
		handPos = Camera.main.ScreenToWorldPoint (mousePosInit);
		Hand_Control.transform.position = handPos;
		Empty_Hand.transform.position = handPos;
		ObjectToMove.transform.position = new Vector3 (Finger.transform.position.x, Finger.transform.position.y, Finger.transform.position.z);




		if (Follow == true && Hand_Low == false) {
			Ymoving = new Vector3 (handPos.x, (Mathf.Clamp (handPos.y, 15.0F, 20.0F)) , handPos.z);	
			Finger.transform.position = Ymoving;
				//print ("je follow");
				}

					if (Follow == false) {

						// *It follows est false, car la main à atteint la limite de la table. En conséquence, elle garde la position qu'elle à touché au moment d'arrivé au bout.*

						Finger.transform.position = MousePosStop;
						//print ("je_touche_le_bord");
						}

		if (FollowCam == true) {

			Empty_Hand.transform.position = Camera.main.ScreenToWorldPoint (mousePosInit);
			//print ("je follow");
		}

		if (FollowCam == false) {

			// *It follows est false, car la main à atteint la limite de la table. En conséquence, elle garde la position qu'elle à touché au moment d'arrivé au bout.*

			Empty_Hand.transform.position = CameraStop;
			//print ("je_touche_le_bord");
		}




		if (Follow == true && Hand_Low == true) {
			//Ymoving = new Vector3 (handPos.x, (Mathf.Clamp (handPos.y, 15.0F, 20.0F)) , handPos.z);	
			YLow = new Vector3 (handPos.x, (Mathf.Clamp (handPos.y, 12.0F, 15.0F)) , handPos.z);	
			//Finger.transform.position = Vector3.Lerp (YmovingLast, YLow, 1 * Time.deltaTime);
			Finger.transform.position = YLow;
			//print ("nik sa mere");
			if (Input.GetMouseButtonDown (0)) {
				Hand_Touch = true;
				StartCoroutine (BackToLow ());

			}
		}


		// _____________________Partie "Je suis au dessus d'un objet"______________________________________


			

		if (Hand_Touch == true) {
			YTouch = new Vector3 (handPos.x, (Mathf.Clamp (handPos.y, 4.0f, 6.0f)) , handPos.z);	
			//Finger.transform.position = Vector3.Lerp (YmovingLast, YLow, 1 * Time.deltaTime);
			Finger.transform.position = YTouch;
		}


		if (Hand_Low == true) {
			if (Input.GetMouseButtonDown (0)) {
				Hand_Touch = true;
				StartCoroutine (BackToLow ());

			}

		}


	}


	void LateUpdate () {

		Camera.main.fieldOfView = Mathf.Lerp (Camera.main.fieldOfView, fov, Time.deltaTime * zoomSpeed);
	}



	/*void FixedUpdate()
	{
		RaycastHit hit;

		if (Physics.Raycast(transform.position, Vector3.down, out hit, 100.0f)) {
			print("Found an object - distance: " + hit.distance);
			Debug.DrawRay(transform.position, Vector3.down, Color.green);
	}
}*/






		void OnTriggerStay (Collider other) {
		if (other.gameObject.tag == "Limits") {
			Follow = false;
			// * la position de la souris au moment de la collision*

		
		}
		if (other.gameObject.tag == "Limits_02") {
			FollowCam = false;
			// * la position de la souris au moment de la collision*


		}

		if (other.gameObject.tag == "Interactive_Object") {
			print ("tu es au dessus d'un objet gros FDP");
			Hand_Low = true;

		}

		if (other.gameObject.tag == "Clavier") {
			Hand_Low = true;
			CameraOnKeyboard = true;
		}

	}

		void OnTriggerEnter (Collider other) {
			
		if (other.gameObject.tag == "Limits") {
			Follow = false;
			// * la position de la souris au moment de la collision*
			MousePosStop = new Vector3 (Finger.transform.position.x, Finger.transform.position.y, Finger.transform.position.z);

		}

		if (other.gameObject.tag == "Limits_02") {
			FollowCam = false;
			// * la position de la souris au moment de la collision*
			CameraStop = new Vector3 (Empty_Hand.transform.position.x, Empty_Hand.transform.position.y, Empty_Hand.transform.position.z);
		}

		if (other.gameObject.tag == "Interactive_Object") {
			YmovingLast = Ymoving;
			Hand_Low = true;
		}


		if (other.gameObject.tag == "Clavier") {
			CameraOnKeyboard = true;
		}

	}

				void OnTriggerExit (Collider other) {
					if (other.gameObject.tag == "Limits") {
					Follow = true;
					FollowCam = true;
					}
	
					if (other.gameObject.tag == "Interactive_Object") {
						Hand_Low = false;

					}

					if (other.gameObject.tag == "Clavier") {
						CameraOnKeyboard = false;
						Hand_Low = false;
					}
				}

				



				IEnumerator BackToLow() {
		float RandomTime = Random.Range (0.1f, 0.3f);
		yield return new WaitForSeconds(RandomTime);
					Hand_Touch = false;
				}

				IEnumerator BacktoNormalView() {
					float RandomTime = Random.Range (0.1f, 0.3f);
					yield return new WaitForSeconds(RandomTime);
					fov = 55;
					yield return new WaitForSeconds(RandomTime);
					BacktoMolette = true;


				}



}
