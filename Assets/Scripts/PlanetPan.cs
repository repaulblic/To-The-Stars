using UnityEngine;
using System.Collections;

public class PlanetPan : MonoBehaviour {


	public float speed = 2F;
	int rotAmount = 45;
	Vector3 destEuler = Vector3.zero;
	Vector3 currEuler;


	void Start () {

		currEuler = destEuler;
		transform.eulerAngles = destEuler;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.RightArrow)) {

			destEuler.y += rotAmount;

		}
		if (Input.GetAxis("Horizontal") < 0) {
			destEuler.y -= rotAmount;
		}

		currEuler = Vector3.Slerp(currEuler, destEuler, Time.deltaTime * speed);
		transform.eulerAngles = currEuler;
	}
}
