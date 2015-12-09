using UnityEngine;
using System.Collections;

public class SunRotate : MonoBehaviour {

	public float timevar;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate (0, 0.01f*timevar, 0);
	}
}
