using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 17;
	public float jump_factor = 1f;
	public float rotSpeed = 150;
	private Vector3 moveDirection;
	private Vector3 rotDirection;
	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> ();

	}

	void Update() {

		moveDirection = new Vector3(0,0,Input.GetAxisRaw("Vertical")).normalized;

		rotDirection = new Vector3(0,Input.GetAxisRaw("Horizontal"),0).normalized;


	}

	void FixedUpdate() {


		//rb.AddForce (moveDirection * moveSpeed * Time.deltaTime,ForceMode.Impulse);
		rb.MoveRotation (rb.rotation * Quaternion.Euler (rotDirection * Time.deltaTime * rotSpeed));
		rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);

	}

	void OnCollisionEnter(UnityEngine.Collision other) 
	{
		if (other.gameObject.CompareTag ("Item"))
		{
			other.gameObject.SetActive (false);
		}
	}


}
