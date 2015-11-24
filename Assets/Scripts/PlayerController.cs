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


	void Start () {

		rb = GetComponent<Rigidbody> ();
	}

	void Update() {

		moveDirection = new Vector3(Input.GetAxisRaw("Vertical"),0,0/*Input.GetAxisRaw("Vertical")*/).normalized;

		rotDirection = new Vector3(0,Input.GetAxisRaw("Horizontal"),0).normalized;

		// Press P to save
		if (Input.GetKeyDown (KeyCode.P)) {
			GameControl.control.Save ();
		}
		// Press L to turn on flashlight
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

		if (other.gameObject.CompareTag ("Item")){

			Destroy(other.gameObject);
			GameControl.control.experience+=10;
		}

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
