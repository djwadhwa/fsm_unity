using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour {

	public Queue<Vector3> waypoints;
	private bool isWalking;
	public float speed = 0.0f;

	// Use this for initialization
	void Start () {
		waypoints = new Queue<Vector3> ();
		isWalking = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		var anim = this.GetComponent<Animator> ();
		if (waypoints.Count > 0) {
			if (!isWalking) {
				anim.Play ("walk");
			}
			if (Vector3.Distance (this.transform.position, waypoints.Peek ()) > 0.1f) {
				this.transform.position = Vector3.MoveTowards (this.transform.position, waypoints.Peek (), speed * Time.deltaTime);
			} else {
				waypoints.Dequeue ();
			}

		} else {
			anim.Play ("idle");
		}
	}
}
