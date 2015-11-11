using UnityEngine;
using System.Collections;

public class EarthMove : MonoBehaviour {

	public float speed;
	Vector3 movement;
	Vector3 movement2;
	Vector3 d;
	
	
	private Rigidbody rb;
	
	
	// Use this for initialization
	void Start () {

	}


	// Update is called once per frame
	void FixedUpdate () {

		transform.Rotate(Vector3.down * Time.deltaTime * speed);
		
	}

}
