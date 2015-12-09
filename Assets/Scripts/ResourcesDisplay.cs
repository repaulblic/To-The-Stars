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
		experienceText.text = "Experience: "+game.experience.ToString();
		metalText.text = "Metal Resources: " + game.metal.ToString ();
		waterText.text = "Water Resources: " + game.water.ToString ();
		iceText.text = "Ice Resources: " + game.ice.ToString ();
		fireText.text = "Fuel Resources: " + game.fire.ToString ();
		woodText.text = "Wood Resources: " + game.wood.ToString ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
