using UnityEngine;
using System.Collections;

public class EscPress : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape) & Application.loadedLevel == 3) {
			
			Application.LoadLevel (Application.loadedLevel - 1);
			
		} 
		if(Input.GetKeyDown (KeyCode.Escape) & Application.loadedLevel < 3) {

			Application.LoadLevel (0);

		}
	
	}
}
