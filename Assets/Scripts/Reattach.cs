using UnityEngine;
using System.Collections;

public class Reattach : MonoBehaviour {
//		
//This class takes a string input and sets the random seed.=
//
	// Use this for initialization
	public void reset(string randseed){
		Debug.Log (randseed);

		GameObject go = GameObject.Find ("GameManager");
		int activeseed;

		if (randseed.Length>0) {
			
			Debug.Log ("RandSeed is not Null");
			Debug.Log ("Ranseed Length:"+randseed.Length);
			activeseed = randseed.GetHashCode ();
			UnityEngine.Random.seed = activeseed;
			Debug.Log (activeseed);
		} 

		else {
			Debug.Log ("RandSeed is Null");
			activeseed = Random.seed;
			Debug.Log (activeseed);
			
		}

		go.GetComponent<GameControl> ().seed = activeseed;
		
		
		
	}
}
