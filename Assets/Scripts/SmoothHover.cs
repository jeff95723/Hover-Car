using UnityEngine;
using System.Collections;

public class SmoothHover : MonoBehaviour {
	
	public float driveforce;
	
	public float hoverheight;
	public float thrustForce;
	public float steerForce;
	public float steerPosZ;
	public float damping;
	
	public Vector3[] thrusters;

	void FixedUpdate () {
		RaycastHit hit;
		for (int i = 0; i< thrusters.Length; i++){
			Vector3 wdThruster = transform.TransformPoint(thrusters[i]);
			if (Physics.Raycast(wdThruster, -transform.up, out hit)){
				float discrep = hoverheight - hit.distance;
				float upVel = rigidbody.GetRelativePointVelocity(wdThruster).y;
				rigidbody.AddForceAtPosition(transform.up * (thrustForce * discrep - upVel * damping), wdThruster);
			}
		}
		
		float fwd = Input.GetAxis("Vertical");
		rigidbody.AddRelativeForce(transform.forward * (driveforce * fwd));
		
		float steer = -Input.GetAxis("Horizontal");
		rigidbody.AddForceAtPosition(transform.right * (steerForce * steer), transform.TransformPoint(Vector3.forward * steerPosZ));
	
	}
	
	private void OnDrawGizmos(){
		for (int i = 0; i<thrusters.Length; i++){
			Gizmos.DrawWireSphere(transform.TransformPoint(thrusters[i]), 0.1f);
		}
	}
}
