using UnityEngine;
using System.Collections;


public class ItemGen : MonoBehaviour {

	public Object Item;
	public int Amount=25;
	private FauxGravityAttractor plane;

	// Use this for initialization
	void Start () {



		plane = GameObject.Find("Planet").GetComponent<FauxGravityAttractor>();

		PlaceCubes();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	Vector3 GeneratedPosition ()
	
	{
		return Random.onUnitSphere * 110;
	}

	void PlaceCubes()
	{
		for(int i = 0; i < Amount; i++)
		{
			GameObject item = (GameObject)Instantiate(Item, GeneratedPosition(), Quaternion.identity);
			//GameObject.Find("Player")
			FauxGravityBody fgb = item.GetComponent<FauxGravityBody>();
			fgb.attractor = plane;

			//Instantiate(cube, GeneratedPosition(), Quaternion.identity);
		}
	}
}
