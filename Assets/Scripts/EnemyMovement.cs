using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	Transform player;
	NavMeshAgent nav;

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent<NavMeshAgent> ();
	}

	//Navigate toward player
	void Update () {
		nav.SetDestination (player.position);

	}
}
