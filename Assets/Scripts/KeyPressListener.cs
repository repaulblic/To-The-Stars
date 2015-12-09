using UnityEngine;
using System.Collections;

public class KeyPressListener : MonoBehaviour {
	

	// Update is called once per frame

	private bool ResourceLoad = false;

	void Update () {


		//// Escape Key begin
		if (Input.GetKeyDown (KeyCode.Escape) & Application.loadedLevel == 3) {
			
			Destroy(GameObject.FindGameObjectWithTag("Planet"));

			Application.LoadLevel (Application.loadedLevel - 1);
			
		} 
	
		if(Input.GetKeyDown (KeyCode.Escape) & Application.loadedLevel < 3) {
			


			Application.LoadLevel (0);
			
		}


		if( Input.GetKeyDown (KeyCode.E)){// & !ResourceLoad){
		
			Application.LoadLevelAdditive(4);
			//ResourceLoad = true;
		}

		else if(Input.GetKeyUp (KeyCode.E)){// & ResourceLoad){
			
			Destroy(GameObject.Find("RCanvas"));
			//ResourceLoad =  false;
		}
		//// Escape Key end
		/// 




	
	}
}
