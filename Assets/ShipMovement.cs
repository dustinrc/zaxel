using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour
{
	public float hMaxSpeed = 15.0f;
	public float vMaxSpeed = 15.0f;
	public float hAcceleration = 45.0f;
	public float hDeceleration = 4.5f;
	public float vAcceleration = 45.0f;
	public float vDeceleration = 4.5f;
	public float hBoundaryMin = -15.0f;
	public float hBoundaryMax = 15.0f;
	public float vBoundaryMin = 0.0f;
	public float vBoundaryMax = 25.0f;
	private float hSpeed = 0.0f;
	private float vSpeed = 0.0f;

	void Update ()
	{
		float hAxis = Input.GetAxis ("Horizontal");
		float vAxis = Input.GetAxis ("Vertical");
		float dt = Time.deltaTime;
		if (hAxis != 0.0f) {
			hSpeed = hSpeed + hAxis * hAcceleration * dt;
		} else {
			hSpeed = Mathf.LerpUnclamped (hSpeed, 0.0f, hDeceleration * dt);
			if (Mathf.Abs (hSpeed) <= 0.01f)
				hSpeed = 0.0f;
		}
		hSpeed = Mathf.Clamp (hSpeed, -hMaxSpeed, hMaxSpeed);
		if (vAxis != 0.0f) {
			vSpeed = vSpeed + vAxis * vAcceleration * dt;
		} else {
			vSpeed = Mathf.LerpUnclamped (vSpeed, 0.0f, vDeceleration * dt);
			if (Mathf.Abs (vSpeed) <= 0.01f)
				vSpeed = 0.0f;
		}
		vSpeed = Mathf.Clamp (vSpeed, -vMaxSpeed, vMaxSpeed);
		print ("hSpeed: " + hSpeed + ", vSpeed: " + vSpeed);
		float hTranslation = hSpeed * dt;
		float vTranslation = vSpeed * dt;
		Vector3 pos = transform.position;
		pos.x = Mathf.Clamp (pos.x + hTranslation, hBoundaryMin, hBoundaryMax);
		pos.z = Mathf.Clamp (pos.z + vTranslation, vBoundaryMin, vBoundaryMax);
		transform.position = pos;
	}
}
