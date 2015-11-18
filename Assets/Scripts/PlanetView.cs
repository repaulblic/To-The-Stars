using UnityEngine;
using System.Collections;

public class PlanetView : MonoBehaviour {

	// Use this for initialization
	void Start () {



		placePlanet (0);
		placePlanet (1);
		placePlanet (2);
		placePlanet (3);
		placePlanet (4);
		placePlanet (5);
		placePlanet (6);
		placePlanet (7);
		placePlanet (8);

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void placePlanet(int i){

		Vector3[] list = new[] {new Vector3(-40,40,0),new Vector3(40,40,0),new Vector3(0,40,0),new Vector3(-40,0,0),new Vector3(40,0,0),new Vector3(0,0,0),
			new Vector3(-40,-40,0),new Vector3(40,-40,0),new Vector3(0,-40,0)};

		//int[] numbers = {1, 2, 3, 4, 5};

		GameObject go_0 = new GameObject ();
		
		
		go_0.AddComponent<MeshFilter> ();
		go_0.AddComponent<MeshRenderer> ();
		go_0.GetComponent<MeshRenderer> ().material = (Material)Resources.Load ("Grass", typeof(Material));
		
		go_0.GetComponent<MeshFilter> ().mesh = (Mesh)Resources.Load ("test"+i,typeof(Mesh));
		go_0.AddComponent<MeshCollider> ();

		go_0.GetComponent<Transform> ().Translate (list[i]);
		go_0.GetComponent<Transform> ().localScale = new Vector3 (10, 10, 10);
	


	}
}
