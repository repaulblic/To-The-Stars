using UnityEngine;
using System.Collections;

public class enemyPatrol : MonoBehaviour {
	public Transform[] Waypoints;
	public float speed;
	public int curWayPoint;
	public bool doPatrol = true;
	public Vector3 Target;
	public Vector3 MoveDirection;
	public Vector3 Velocity;

	void Update(){
		if (curWayPoint < Waypoints.Length) {
			Target = Waypoints [curWayPoint].position;
			MoveDirection = Target-transform.position;
			Velocity = GetComponent<Rigidbody>().velocity;

			if (MoveDirection.magnitude < 1) {
				curWayPoint++;
			} else {
				Velocity = MoveDirection.normalized * speed;
			}
		} else {
			if (doPatrol == false) {
				curWayPoint = 0;
			} else {
				Velocity = Vector3.zero;
			}
		}
		GetComponent<Rigidbody>().velocity = Velocity;
		transform.LookAt (Target);
	}
}
