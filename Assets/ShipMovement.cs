using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour
{
	public float maxSpeed = 15.0f;
	public float hAcceleration = 1000.0f;
	public float vAcceleration = 1000.0f;
	public float hBoundaryMin = -15.0f;
	public float hBoundaryMax = 15.0f;
	public float vBoundaryMin = 0.0f;
	public float vBoundaryMax = 25.0f;
	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		rb.useGravity = false;
		rb.drag = 1.0f;
	}

	void Update ()
	{
		float hAxis = Input.GetAxis ("Horizontal");
		float vAxis = Input.GetAxis ("Vertical");
		float dt = Time.deltaTime;

		float hForce = hAxis * hAcceleration * dt;
		float vForce = vAxis * vAcceleration * dt;
		rb.AddForce (new Vector3 (hForce, 0.0f, vForce));

		if (rb.velocity.magnitude > maxSpeed)
			rb.velocity = rb.velocity.normalized * maxSpeed;

		// TODO: fence with other rigidbodies
		Vector3 pos = transform.position;
		pos.x = Mathf.Clamp (pos.x, hBoundaryMin, hBoundaryMax);
		pos.z = Mathf.Clamp (pos.z, vBoundaryMin, vBoundaryMax);
		transform.position = pos;

		print ("h: " + rb.velocity.x + ", v: " + rb.velocity.z);
	}
}
