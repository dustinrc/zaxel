using UnityEngine;
using System.Collections;

public class EnemyKiloMovement : MonoBehaviour
{

	public float maxSpeed = 1.0f;
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
		transform.LookAt (target);
		rb.AddForce (transform.forward * 0.3f, ForceMode.Impulse);

		if (rb.velocity.magnitude > maxSpeed)
			rb.velocity = rb.velocity.normalized * maxSpeed;
	}
}
