using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_object_RB : MonoBehaviour {
	public GameObject object_to_follow;
	private Rigidbody rb;
	private CharacterJoint jnt;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
		jnt = gameObject.GetComponent<CharacterJoint> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		rb.position = object_to_follow.transform.position;
	}
}
