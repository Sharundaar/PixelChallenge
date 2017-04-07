using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryController : MonoBehaviour {

	[SerializeField]
	Transform indicationSphere = null;

	[SerializeField]
	float carryRadius = 5;

	[SerializeField]
	LayerMask carryLayer = 0;

	[SerializeField]
	LayerMask placeLayer = 0;

	private CarriedObject carriedObject = null;

	private PlayerInputMap inputMap;

	[SerializeField]
	Transform carryPivot = null;
	Transform carryPoint; // carry pivot first point

	[SerializeField]
	private float throwForce = 2.0f;

	void Start()
	{
		inputMap = GetComponent<PlayerInputMap>();
		carryPoint = carryPivot.GetChild(0);
	}

	private void RotateCarryPivot()
	{
		float xaxis = Input.GetAxis(inputMap.RotateXAxis);
		float yaxis = -Input.GetAxis(inputMap.RotateYAxis);
		if (Mathf.Abs(xaxis) - float.Epsilon <= 0 && Mathf.Abs(yaxis) - float.Epsilon <= 0)
			return;

		Vector3 targetOrientVect = new Vector3(xaxis, 0, yaxis).normalized;

		carryPivot.forward = Vector3.RotateTowards(carryPivot.forward, targetOrientVect, 10.0f, 0.0f);
	}

	void Update () {

		RotateCarryPivot();

		if (carriedObject)
		{
			indicationSphere.position = carriedObject.transform.position + Vector3.up * 5.0f;
			if (Input.GetButtonDown(inputMap.Carry))
				LetGo();
			return;
		}

		var objects = Physics.OverlapSphere(transform.position, carryRadius, carryLayer);
		float closestDist = float.MaxValue;
		Transform closest = null;

		for(int i=0; i<objects.Length; ++i)
		{
			if (objects[i].GetComponent<CarriedObject>() != null) // skip already carried objects
				continue;

			float dist = Vector3.Distance(transform.position, objects[i].transform.position);
			if(dist < closestDist)
			{
				closestDist = dist;
				closest = objects[i].transform;
			}
		}

		if (closest == null)
		{
			indicationSphere.gameObject.SetActive(false);
			return;
		}

		indicationSphere.position = closest.position + Vector3.up * 5.0f;
		indicationSphere.gameObject.SetActive(true);

		if( Input.GetButtonDown(inputMap.Carry) )
			Carry(closest);
	}

	void Carry(Transform obj)
	{
		/*while( obj.parent != null )
			obj = obj.parent;*/
		carryPivot.forward = Vector3.ProjectOnPlane((obj.position - transform.position), Vector3.up).normalized;

		// obj.GetComponent<SnapToFloor>().enabled = false;
		var carried = obj.gameObject.AddComponent<CarriedObject>();
		carried.carryPoint = carryPoint;

		carriedObject = carried;
	}

	void LetGo()
	{
		// carriedObject.GetComponent<SnapToFloor>().enabled = true;
		var carriedTransform = carriedObject.transform;
		Destroy(carriedObject);
		carriedObject = null;

		RaycastHit hit;
		if (Physics.SphereCast(new Ray(carriedTransform.position + Vector3.up * 200.0f, Vector3.down), 0.5f, out hit, 200.0f + 5.0f, placeLayer))
			carriedTransform.position = hit.point;
	}
}
