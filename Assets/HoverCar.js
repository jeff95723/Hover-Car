var driveForce: float;

var hoverHeight: float;
var thrustForce: float;
var steerForce: float;
var steerPosZ: float;
var damping: float;

var thrusters: Vector3[];




function FixedUpdate () {
	var hit: RaycastHit;
	
	for (i = 0; i < thrusters.Length; i++) {
		var wdThruster: Vector3 = transform.TransformPoint(thrusters[i]);
		
		if (Physics.Raycast(wdThruster, -transform.up, hit)) {
			var discrep: float = hoverHeight - hit.distance;
			var upVel: float = rigidbody.GetRelativePointVelocity(wdThruster).y;
			rigidbody.AddForceAtPosition(transform.up * (thrustForce * discrep - upVel * damping), wdThruster);
		}
	}
	
	var fwd: float = Input.GetAxis("Vertical");
	rigidbody.AddForce(transform.forward * (driveForce * fwd));
	
	var steer: float = -Input.GetAxis("Horizontal");
	rigidbody.AddForceAtPosition(transform.right * (steerForce * steer), transform.TransformPoint(Vector3.forward * steerPosZ));
}


function OnDrawGizmos() {
	for (i = 0; i < thrusters.Length; i++) {
		Gizmos.DrawWireSphere(transform.TransformPoint(thrusters[i]), 0.1);
	}
}