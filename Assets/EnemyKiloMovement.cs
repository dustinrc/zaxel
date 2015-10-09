using UnityEngine;
using System.Collections;

public class EnemyKiloMovement : MonoBehaviour
{

	private float maxSpeed = 3.0f;
	private float pursuitStrength = 2.0f;
	private Transform target;
	private Rigidbody rb;

	void Awake ()
	{
		rb = GetComponent<Rigidbody> ();
		rb.useGravity = false;
	}

	void Start ()
	{
		target = GameObject.FindWithTag ("Player").transform;
	}
	
	void Update ()
	{
		// TODO: slower, more realistic rotation
		transform.LookAt (target);

		// strong thrust from further out, correct direction as get closer
		float pursuitForce = Vector3.Distance (transform.position, target.position) * pursuitStrength;
		rb.AddForce (transform.forward * pursuitForce - rb.velocity);

		if (rb.velocity.magnitude > maxSpeed)
			rb.velocity = rb.velocity.normalized * maxSpeed;

		print (rb.velocity.magnitude);
	}
}
