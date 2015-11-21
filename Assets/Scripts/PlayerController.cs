using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 17;
	public float jump_factor = 1f;
	public float rotSpeed = 150;
	private Vector3 moveDirection;
	private Vector3 rotDirection;
	private Rigidbody rb;
	int jumpcount = 10;


	void Start () {

		rb = GetComponent<Rigidbody> ();
	}

	void Update() {

		moveDirection = new Vector3(Input.GetAxisRaw("Vertical"),0,0/*Input.GetAxisRaw("Vertical")*/).normalized;

		rotDirection = new Vector3(0,Input.GetAxisRaw("Horizontal"),0).normalized;

	}
	
	void FixedUpdate() {
	
		rb.MoveRotation (rb.rotation * Quaternion.Euler (rotDirection * Time.deltaTime * rotSpeed));
		rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);

		if(Input.GetKeyDown(KeyCode.Space) & jumpcount<3){
			rb.AddForce (rb.position.normalized * Time.deltaTime * 500 * jump_factor);

			jumpcount++;
		}
	}

	void OnCollisionEnter(UnityEngine.Collision other) {

		if (other.gameObject.CompareTag ("Item")){

			Destroy(other.gameObject);
		}

		if (other.gameObject.CompareTag ("Planet")){

			jumpcount=0;
		}
	}

}
