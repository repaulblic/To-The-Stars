using UnityEngine;
using System.Collections;

public class Moveonclick : MonoBehaviour {



	bool run = false;
	bool loaded = false;
	//bool finished = false;
	bool started;
	Animation ani;


	void Start(){
		ani = GetComponent<Animation> ();
	}


	 void Update()
	{
		if (Input.anyKeyDown & !run) {
			started = true;
			StartCoroutine("animat");
			run = true;
		}

		if (!loaded & !ani.isPlaying & started) {
			Application.LoadLevelAdditive (1);
			loaded = true;
		}


	}

	IEnumerator animat() {
		ani.Play (ani.clip.name);
		DestroyObject(GameObject.Find("AnyButton"));
		yield return null;
	}

}