using UnityEngine;
using System.Collections;

public class MenuScripts : MonoBehaviour {


	public GameObject TF;
	public int index=0;


	public void push(){

		TF.SetActive (true);
	}


	public void NextLevelButton(int index)
	{
		Application.LoadLevel(index);
	}
	

	public void reset(string randseed){

		GameObject go = GameObject.Find ("GameManager");
		int activeseed;
		
		if (randseed.Length>0) {
			activeseed = randseed.GetHashCode ();
			UnityEngine.Random.seed = activeseed;
		} 
		
		else {
			Debug.Log ("RandSeed is Null");
			activeseed = Random.seed;
			Debug.Log (activeseed);	
		}
		
		GameControl.control.seed = activeseed;
	}


	public void loadpush(){
		GameControl.control.load();
		Application.LoadLevel(2);
		
	}




}
