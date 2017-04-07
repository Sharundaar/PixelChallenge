using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class SnapToFloor : MonoBehaviour
{
	private const float OFFSET = 10.0f;

	[SerializeField]
	private LayerMask snapLayer = 512;
	
	void FixedUpdate()
	{
		RaycastHit hit;
		Vector3 rayStart = transform.position + Vector3.up * OFFSET;
		if (Physics.Raycast(rayStart, -Vector3.up, out hit, float.MaxValue, snapLayer))
		{
			Debug.DrawLine(transform.position, hit.point, Color.green);

			var pos = transform.position;
			pos.y = hit.point.y;
			transform.position = pos;

		}
		else
		{
			Debug.DrawLine(transform.position, transform.position - transform.up * 5.0f, Color.red);
		}
	}
}
