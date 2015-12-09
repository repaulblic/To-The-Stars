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
	bool att = false;

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		//playerHealth = player.getComponent<PlayerHealth>();
		enemyHealth = GetComponent<EnemyHealth>();
		a = GetComponent<Animator> ();

	}
	

	void OnCollisionEnter (UnityEngine.Collision other) {
		if (other.gameObject == player) {
			//Debug.Log("ENTER");
			playerInRange = true;}
	
	}
	

	void onCollisionExit (UnityEngine.Collision other){
		if (other.gameObject == player) {
			//Debug.Log("RESET");
			playerInRange = false;
			a.Play("monster2WalkkForward");
		}
	}

	// Update is called once per frame
	void Update(){
		timer += Time.deltaTime;

		if(timer>= attackSpeed & playerInRange & enemyHealth.currentHealth>0){
			// Attack ();
			a.Play ("monster2Attack1");


		}

		/*if (playerHealth.current <= 0) {
			a.setTrigger ("PlayerDead");
		}*/
	}



	void Attack(){

		timer = 0f;
		a.SetTrigger ("Attack");



		/*if (player.currentHealth > 0) {
			player.takeDamage (power);}*/
	}

}
