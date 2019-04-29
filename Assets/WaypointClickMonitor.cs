using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointClickMonitor : MonoBehaviour {

	public GameObject waypointObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			var playfield = GameObject.Find("Plane").GetComponent<Collider>();
			RaycastHit hitPoint;
			if (playfield.Raycast(ray,out hitPoint,float.MaxValue)) {
				Vector3 newWaypoint = hitPoint.point;
				Debug.Log ("Waypoint position: " + newWaypoint.ToString());
				var playerWaypointList = GameObject.Find ("free_male_1").GetComponent<WaypointMovement>().waypoints;
				Vector3 waypointObjectPoint = newWaypoint;
				waypointObjectPoint.y = 0.5f;
				Instantiate (waypointObject, waypointObjectPoint,new Quaternion());
				playerWaypointList.Enqueue (newWaypoint);
				Debug.Log("New waypoint list: ");
				foreach (Vector3 i in playerWaypointList) {
					Debug.Log (i.ToString ());
				}
			}
		}
	}
}
