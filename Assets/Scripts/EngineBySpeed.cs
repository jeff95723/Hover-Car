using UnityEngine;
using System.Collections;

public class EngineBySpeed : MonoBehaviour {
	
	public GameObject obj;
	public GameObject engine;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float speed = obj.rigidbody.velocity.magnitude;
		ParticleEmitter pe = engine.GetComponent<ParticleEmitter>();
		pe.maxEnergy = (speed/100) * 1.5f;
		 }
}
