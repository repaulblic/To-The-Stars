using UnityEngine;
using System.Collections;

public class fuelbar : MonoBehaviour {

	public Texture2D emptyProgressBar; // Set this in inspector.
	public Texture2D fullProgressBar; // Set this in inspector.


	void OnGUI() {
			
		GUI.DrawTexture(new Rect(0, 0, 100, 50), emptyProgressBar);
		GUI.DrawTexture(new Rect(0, 0, 100, 50), fullProgressBar);
	
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUI.Label(new Rect(0, 0, 100, 50), string.Format("Fuel"));
	}



}
