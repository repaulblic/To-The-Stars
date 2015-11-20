using UnityEngine;
using System.Collections;


public class RandomIntArray : MonoBehaviour {

	public string randseed = null;
	public int activeseed;
	// Use this for initialization
	void Start() {

		if (randseed.Length>0) {

			Debug.Log ("RandSeed is not Null");
			Debug.Log ("Ranseed Length:"+randseed.Length);
			activeseed = randseed.GetHashCode ();
			UnityEngine.Random.seed = activeseed;
			Debug.Log (activeseed);
		} else {
			Debug.Log ("RandSeed is Null");
			activeseed = Random.seed;
			Debug.Log (activeseed);

		}

		Random.seed = activeseed;
	}

}	

