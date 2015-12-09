using UnityEngine;
using System.Collections;

public class StartItems : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		gameObject.GetComponent<ItemGen> ().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
