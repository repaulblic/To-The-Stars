using UnityEngine;
using System.Collections;

public class Check : MonoBehaviour {

	// Use this for initialization
	void Start () {

		PlayerController pc = GetComponent<PlayerController> ();
		pc.enabled = true;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
