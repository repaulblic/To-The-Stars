using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourcesDisplay : MonoBehaviour {
	public Text experienceText;
	public Text metalText;
	public Text waterText;
	public Text iceText;
	public Text fireText;
	public Text woodText;
	// Use this for initialization
	void Start () {
		GameObject theGame = GameObject.Find("GameManager");
		GameControl game = theGame.GetComponent<GameControl>();
		experienceText.text = "Experience: "+GameControl.control.experience.ToString();
		metalText.text = "Metal Resources: " + GameControl.control.metal.ToString ();
		waterText.text = "Water Resources: " + GameControl.control.water.ToString ();
		iceText.text = "Ice Resources: " + GameControl.control.ice.ToString ();
		fireText.text = "Fuel Resources: " + GameControl.control.fire.ToString ();
		woodText.text = "Wood Resources: " + GameControl.control.wood.ToString ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
