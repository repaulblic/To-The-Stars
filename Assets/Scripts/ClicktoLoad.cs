using UnityEngine;
using System.Collections;

public class ClicktoLoad : MonoBehaviour {
	public int index = 3;
	bool forward = false;

	// Use this for initialization
	void Start () {

		forward = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {

		if (!forward) {
			DontDestroyOnLoad (gameObject);
			gameObject.transform.position = Vector3.zero;
			gameObject.GetComponent<EarthMove> ().enabled = false;
			forward = true;
			Application.LoadLevel (index);

			//gameObject.GetComponent<ItemGen> ().enabled = true;
			//DontDestroyOnLoad}
		}
	}
}
