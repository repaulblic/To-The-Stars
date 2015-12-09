using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	Transform player;
	NavMeshAgent nav;
	Transform enemy;
	int moveSpeed = 3;
	int rotationSpeed = 3;

	void Awake () {
		enemy = GetComponent<Transform>();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent<NavMeshAgent> ();
	}
		
	//Navigate toward player
	void Update () {
		//nav.SetDestination (player.position);
		enemy.rotation = Quaternion.Slerp (enemy.rotation, Quaternion.LookRotation (player.position - enemy.position), rotationSpeed* Time.deltaTime);
		enemy.position += enemy.forward * moveSpeed * Time.deltaTime;
	}
}
