using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 17;
	public float jump_factor = 1f;
	public float rotSpeed = 150;
	private Vector3 moveDirection;
	private Vector3 rotDirection;
	private Rigidbody rb;
	int jumpcount = 0;
	public GameObject light;
	int batterycount = 0;
	private int add;
	private string[] ind = {"Metal","Water","Ice","Wood","Fire"};

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


		if (gameObject.GetComponentInChildren<Light> ().enabled & batterycount<241) {
			batterycount++;
		}
		if (!gameObject.GetComponentInChildren<Light> ().enabled & batterycount>0) {
			batterycount--;
		}
		if (batterycount == 240) {
			gameObject.GetComponentInChildren<Light> ().enabled = false;
		}
		// Flashlight end

	}
	
	void FixedUpdate() {
	
		rb.MoveRotation (rb.rotation * Quaternion.Euler (rotDirection * Time.deltaTime * rotSpeed));
		rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);

		if(Input.GetKey(KeyCode.Space) & jumpcount<81){
			rb.AddRelativeForce (Vector3.up * 500 * Time.deltaTime * jump_factor);


			jumpcount++;

		}
	}

	void OnCollisionStay(UnityEngine.Collision other) {

		if (other.gameObject.tag.Equals("Item")){
			Destroy(other.gameObject);
			int which = Random.Range(0, 5);
			switch (which) {
			case 0: GameControl.control.metal+=10;break;
			case 1: GameControl.control.water+=10;break;
			case 2: GameControl.control.ice+=10;break;
			case 3: GameControl.control.wood+=10;break;
			case 4: GameControl.control.fire+=10;break;
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



	public Texture2D fullProgressBar; // Set this in inspector.


	public Texture2D fullBattertyBar;
	
	void OnGUI() {


		GUI.DrawTexture(new Rect(25, 10, 2*(80-jumpcount), 25), fullProgressBar);
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUI.Label(new Rect(25, 10, (80)*2, 25), string.Format("Fuel"));

		GUI.DrawTexture(new Rect(25, 50, (0.666f*(240-batterycount)), 25), fullBattertyBar);
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUI.Label(new Rect(25, 50, (240* 0.666f), 25), string.Format("Battery"));
	}

}
