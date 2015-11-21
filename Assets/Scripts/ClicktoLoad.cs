using UnityEngine;
using System.Collections;

public class ClicktoLoad : MonoBehaviour {
	public int index = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		Application.LoadLevel(index);
	}
}
