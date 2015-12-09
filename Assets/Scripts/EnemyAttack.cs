using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public float attackSpeed;
	public int power;

	Animator a;
	GameObject player;
	//PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	bool playerInRange;
	float timer;

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		//playerHealth = player.getComponent<PlayerHealth>();
		enemyHealth = GetComponent<EnemyHealth>();
		a = GetComponent<Animator> ();

	}
	

	void OnTriggerEnter (Collider other) {
		if (other.gameObject == player) {
			playerInRange = true;}
	
	}

	void onTriggerExit (Collider other){
		if (other.gameObject == player) {
			playerInRange = false;}
	}

	// Update is called once per frame
	void Update(){
		timer += Time.deltaTime;

		if(timer>= attackSpeed && playerInRange && enemyHealth.currentHealth>0){
			Attack ();
		}

		/*if (playerHealth.current <= 0) {
			a.setTrigger ("PlayerDead");
		}*/
	}



	void Attack(){

		a.SetTrigger ("Attack");
		timer = 0f;

		/*if (player.currentHealth > 0) {
			player.takeDamage (power);}*/
	}
}
