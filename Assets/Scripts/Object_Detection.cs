using UnityEngine;
using System.Collections;

public class Object_Detection : MonoBehaviour {


	public bool Hand_Low;
	public bool Hand_Touch;
	// Use this for initialization
	void Start () {
		Hand_Low = false;
		Hand_Touch = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Hand_Low == true) {
			if (Input.GetMouseButtonDown (0)) {
				Hand_Touch = true;
				StartCoroutine (BackToLow ());

			}

		}
	
	}

	void OnTriggerStay (Collider other) {
		if (other.gameObject.tag == "Interactive_Object") {
			print ("tu es au dessus d'un objet gros FDP");
			Hand_Low = true;

		}

	}


	void OnTriggerExit (Collider other) {
		if (other.gameObject.tag == "Interactive_Object") {
			Hand_Low = false;

		}


	}

	IEnumerator BackToLow() {
		yield return new WaitForSeconds(0.5f);
		Hand_Touch = false;
	}


}
