using UnityEngine;
using System.Collections;

public class EnemyGenerator: MonoBehaviour
{
	public GameObject enemy;
	public int Amount=15;
	private FauxGravityAttractor plane;

	// Use this for initialization
	void Start () {



		//plane = GameObject.Find("Planet").GetComponent<FauxGravityAttractor>();
		plane = gameObject.GetComponent<FauxGravityAttractor>();

		GenEnemy();

	}

	// Update is called once per frame
	void Update () {

	}

	Vector3 GeneratedPosition ()

	{
		return Random.onUnitSphere * 110;
	}

	void GenEnemy()
	{
		for(int i = 0; i < Amount; i++)
		{
			GameObject item = (GameObject)Instantiate(enemy, GeneratedPosition(), Quaternion.identity);
			FauxGravityBody fgb = item.GetComponent<FauxGravityBody>();
			fgb.attractor = plane;

			//Instantiate(cube, GeneratedPosition(), Quaternion.identity);
		}
	}
}