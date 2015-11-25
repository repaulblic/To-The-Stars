using UnityEngine;
using System.Collections;

public class KeyPressListener : MonoBehaviour {
	

	// Update is called once per frame
	void Update () {


		//// Escape Key begin
		if (Input.GetKeyDown (KeyCode.Escape) & Application.loadedLevel == 3) {
			
			Application.LoadLevel (Application.loadedLevel - 1);
			
		} 
	
		if(Input.GetKeyDown (KeyCode.Escape) & Application.loadedLevel < 3) {
			
			Application.LoadLevel (0);
			
		}
		//// Escape Key end
		/// 
		if (Input.GetKeyDown (KeyCode.P)) {
			GameControl.control.Save ();
		}



	
	}
}
