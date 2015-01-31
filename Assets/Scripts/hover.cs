using UnityEngine;
using System.Collections.Generic;

public class hover : MonoBehaviour {

	public List<Transform> HoverPoints = new List<Transform>();
	public float HoverHeight = 7;
    public float HoverForceFront = 200;
    public float HoverForceBack = 400;
	public GameObject obj;
	public int speed;
	public int steerSpeed;
	private bool isGrounded;
	private Vector3 Force;
    void FixedUpdate ()
    {
       
		//Lift
		isGrounded = false;
       for(int i=0; i < 4; i++)
       {
         RaycastHit Hit;
         if(i >1)
         {
          if(Physics.Raycast(HoverPoints[i].position, HoverPoints[i].TransformDirection(Vector3.down), out Hit, HoverHeight))
              obj.rigidbody.AddForceAtPosition((Vector3.up * HoverForceBack * Time.deltaTime)* Mathf.Abs(1-(Vector3.Distance(Hit.point, HoverPoints[i].position)/ HoverHeight)), HoverPoints[i].position);
          if(Hit.point != Vector3.zero)
              Debug.DrawLine(HoverPoints[i].position, Hit.point, Color.blue);
         }else
         {
          if(Physics.Raycast(HoverPoints[i].position, HoverPoints[i].TransformDirection(Vector3.down), out Hit, HoverHeight))
              obj.rigidbody.AddForceAtPosition((Vector3.up * HoverForceFront * Time.deltaTime)* Mathf.Abs(1-(Vector3.Distance(Hit.point, HoverPoints[i].position)/ HoverHeight)), HoverPoints[i].position);
          if(Hit.point != Vector3.zero)
              Debug.DrawLine(HoverPoints[i].position, Hit.point, Color.red);
         }
         if(Hit.point != Vector3.zero)
          isGrounded = true;
         //else
          
       }
	
		if(isGrounded){
		float moveVertical = Input.GetAxis("Vertical");
		float moveHorizontal = Input.GetAxis("Horizontal");
		obj.rigidbody.AddRelativeForce(0,0,moveVertical * speed * Time.deltaTime);
		rigidbody.AddRelativeTorque (0,(Input.GetAxis("Horizontal"))*steerSpeed,0);
		Vector3 relForce = new Vector3 (0, 0, (moveVertical * speed * Time.deltaTime));
		Vector3 dir = new Vector3 (1,0,1);
		Force = obj.transform.TransformDirection(relForce);
		Force.y = 0;
		}else{
		float moveVertical = Input.GetAxis("Vertical");
		float moveHorizontal = Input.GetAxis("Horizontal");
		obj.rigidbody.AddForce(Force);
		rigidbody.AddForce(9.5f * Physics.gravity * rigidbody.mass);
		}
    
	}
}
