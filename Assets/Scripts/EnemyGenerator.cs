﻿using UnityEngine;
using System.Collections;

public class EnemyGenerator: MonoBehaviour
{
	//public PlayerHealth playerHealth;       
	public GameObject enemy;                
	public float spawnTime = 3f;            
	public Transform[] spawnPoints;         


	void Start ()
	{
		
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}


	void Spawn ()
	{
		// If the player has no health left...
		/*if(playerHealth.currentHealth <= 0f)
		{
			// ... exit the function.
			return;
		}*/


		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}