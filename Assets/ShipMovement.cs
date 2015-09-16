using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour
{
	public float hSpeed = 15.0f;
	public float vSpeed = 15.0f;
	public float hBoundaryMin = -15.0f;
	public float hBoundaryMax = 15.0f;
	public float vBoundaryMin = 0.0f;
	public float vBoundaryMax = 25.0f;

	void Update ()
	{
		float hTranslation = Input.GetAxis ("Horizontal") * hSpeed * Time.deltaTime;
		float vTranslation = Input.GetAxis ("Vertical") * vSpeed * Time.deltaTime;
		Vector3 pos = transform.position;
		pos.x = Mathf.Clamp (pos.x + hTranslation, hBoundaryMin, hBoundaryMax);
		pos.z = Mathf.Clamp (pos.z + vTranslation, vBoundaryMin, vBoundaryMax);
		transform.position = pos;
	}
}
