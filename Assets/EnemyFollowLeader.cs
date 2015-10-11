using UnityEngine;
using System.Collections;

public class EnemyFollowLeader : MonoBehaviour
{
	public float size = 2.0f;
	private float maxSpeed = 5.0f;
	private float pursuitStrength = 2.0f;
	private float turnStrenth = 2.0f;
	public GameObject targetObject;
	private Transform target;
	private Rigidbody rb;
	
	void Awake ()
	{
		rb = GetComponent<Rigidbody> ();
		rb.useGravity = false;
	}
	
	void Start ()
	{
		target = targetObject.transform;
	}
	
	void Update ()
	{
		// better turning at lower speeds
		Vector3 lookDirection = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation (lookDirection);
		float turnSpeed = maxSpeed - (rb.velocity.magnitude / Mathf.Clamp (turnStrenth, 2.0f, Mathf.Infinity));
		transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
		
		// strong thrust from further out, slow to correct direction as get closer
		float pursuitForce = Vector3.Distance (transform.position, target.position) * pursuitStrength;
		rb.AddForce (transform.forward * pursuitForce - rb.velocity);
		
		if (rb.velocity.magnitude > maxSpeed)
			rb.velocity = rb.velocity.normalized * maxSpeed;
		
//		print (rb.velocity.magnitude);
	}
}
