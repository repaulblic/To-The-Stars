using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static PlayerController Access;

	public float moveSpeed = 17;
	public float jump_factor = 1f;
	public float rotSpeed = 150;
	private Vector3 moveDirection;
	private Vector3 rotDirection;
	public int batteryMax = 240;
	public int jumpMax = 80;
	private Rigidbody rb;
	int jumpcount = 0;
	public GameObject light;
	int batterycount = 0;
	private int add;
	private string[] ind = {"Metal","Water","Ice","Wood","Fire", "Health"};
	public int healthMax = 150;
	public int healthLost = 0;

	public float lightrange = 25;
	public float lightangle = 360;



	void Start () {

		rb = GetComponent<Rigidbody> ();
	}

	void Update() {



		moveDirection = new Vector3(Input.GetAxisRaw("Vertical"),0,0/*Input.GetAxisRaw("Vertical")*/).normalized;

		rotDirection = new Vector3(0,Input.GetAxisRaw("Horizontal"),0).normalized;


		// Press L to turn on flashlight begin
		if (Input.GetKeyDown (KeyCode.L)) {
			gameObject.GetComponentInChildren<Light>().enabled= !gameObject.GetComponentInChildren<Light>().enabled;
		}


		if (gameObject.GetComponentInChildren<Light> ().enabled & batterycount<batteryMax) {
			batterycount++;
			HitEnemies(lightrange,lightangle);
		}
		if (!gameObject.GetComponentInChildren<Light> ().enabled & batterycount>0) {
			batterycount--;
		}
		if (batterycount == batteryMax) {
			gameObject.GetComponentInChildren<Light> ().enabled = false;
		}
		// Flashlight end

		if (Input.GetKeyDown (KeyCode.P)) {
			GameControl.control.Save ();
		}

	}
	
	void FixedUpdate() {
	
		rb.MoveRotation (rb.rotation * Quaternion.Euler (rotDirection * Time.deltaTime * rotSpeed));
		rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);

		if(Input.GetKey(KeyCode.Space) & jumpcount<jumpMax){
			rb.AddRelativeForce (Vector3.up * 500 * Time.deltaTime * jump_factor);


			jumpcount++;

		}
	}

	void OnCollisionStay(UnityEngine.Collision other) {

		if (other.gameObject.tag.Equals("Item")){
			Destroy(other.gameObject);
//			StartCoroutine(ShowMessage("Abc", 2));

			int which = Random.Range(0, 6);
			switch (which) {
			case 0: GameControl.control.metal+=10;break;
			case 1: GameControl.control.water+=10;break;
			case 2: GameControl.control.ice+=10;break;
			case 3: GameControl.control.wood+=10;break;
			case 4: GameControl.control.fire+=10;break;
			case 5: if (healthLost>0){healthLost=healthLost-10;};break;
			}
			//TODO should draw and print on the screen: ind[which] Resources +1

		}


		/*
		switch (other.gameObject.tag) {
		case "Metal":
			Destroy(other.gameObject);
			GameControl.control.metal+=10;break;
		case "Water":
			Destroy(other.gameObject);
			GameControl.control.water+=10;break;
		case "Ice":
			Destroy(other.gameObject);
			GameControl.control.ice+=10;break;
		case "Wood":
			Destroy(other.gameObject);
			GameControl.control.wood+=10;break;
		case "Fire":
			Destroy(other.gameObject);
			GameControl.control.fire+=10;break;
		}
		*/

		if (other.gameObject.CompareTag ("Planet") & jumpcount>0){

			jumpcount--;
		}


	}



	void OnCollisionEnter(UnityEngine.Collision other) {

		
		if (other.gameObject.tag.Equals ("enemy")) {
			healthLost = healthLost + 10;
			isdead();
			
		}
	}

	void isdead(){
		if ((healthMax - healthLost) <= 0) {
			Destroy(GameObject.FindGameObjectWithTag("Planet"));
			Application.LoadLevel(2);
		}
	}


	public Texture2D fullProgressBar; // Set this in inspector.


	public Texture2D fullBattertyBar;

	public Texture2D fullHealthBar;
	
	void OnGUI() {


		GUI.DrawTexture(new Rect(25, 10, (160f/jumpMax)*(jumpMax-jumpcount), 25), fullProgressBar);
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUI.Label(new Rect(25, 10, (80)*2, 25), string.Format("Fuel"));

		GUI.DrawTexture(new Rect(25, 50, ((160f/batteryMax)*(batteryMax-batterycount)), 25), fullBattertyBar);
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUI.Label(new Rect(25, 50, (240* 0.666f), 25), string.Format("Battery"));

		GUI.DrawTexture(new Rect(25, 90, ((160f/healthMax)*(healthMax-healthLost)), 25), fullHealthBar);
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUI.Label(new Rect(25, 90, 160, 25), string.Format("Health: "+ (healthMax-healthLost).ToString()));
	}






	void HitEnemies(float range, float angle){
		Vector3 here = transform.position; // get player/weapon position...
		//Debug.Log (here);
		Vector3 forward = transform.right; // and forward direction
		// get colliders inside range:
		Collider[] cols = Physics.OverlapSphere(here, range);
		foreach (Collider col in cols) { // check them all
			if (col && col.gameObject.CompareTag("enemy")){ // if it's an enemy...
				Debug.Log("Sensing enemies...");
				Vector3 dir = col.transform.position - here; // find enemy direction
				if (Vector3.Angle(dir, forward) <= angle/2){ // if inside the angle...
					// try to get the enemy script (generic way is faster):
					//col.gameObject.GetComponent<EnemyHealth>();
					Debug.Log("Hurting enemies...");
					EnemyHealth eh = col.gameObject.GetComponent<EnemyHealth>();
					//eh.TakeDamage(1, col.transform.position);
					// if script found, apply the damage
					eh.currentHealth = eh.currentHealth - 1;
				}
			}
		}
	}
















}
