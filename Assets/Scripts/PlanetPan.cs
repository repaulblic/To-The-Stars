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

		if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {

			destEuler.y += rotAmount;

		}
		if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
			destEuler.y -= rotAmount;
		}

		currEuler = Vector3.Slerp(currEuler, destEuler, Time.deltaTime * speed);
		transform.eulerAngles = currEuler;

	}
}
