using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchController : MonoBehaviour {

	private PlayerInputMap inputMap;
	private SimpleTestController playerController;
	private float currentTime = 0;
	public float punchResetCooldownDuration = 4.0f;
	public float punchForce = 300.0f;

	void Start()
	{
		inputMap = GetComponent<PlayerInputMap>();
		playerController = GetComponent<SimpleTestController> ();
	}

	void Update () {
		if (currentTime > 0) {
			currentTime -= Time.deltaTime;
		}
		else if (Input.GetButtonDown (inputMap.Punch)) {
			Punch ();
		}
	}

	private void Punch()
	{
		currentTime = punchResetCooldownDuration;

		Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5.0f);
		int i = 0;
		Collider collider;
		while (i < hitColliders.Length)
		{
			collider = hitColliders [i];
			if (collider.transform.root == transform) {
				// it's me, continue;
				i++;
				continue;
			}
			Rigidbody rigidBody = collider.GetComponentInParent<Rigidbody> ();
			if (rigidBody) {
				Vector3 direction = rigidBody.position - transform.position;
				direction.Normalize ();

				SimpleTestController controller = collider.GetComponentInParent<SimpleTestController> ();
				if(controller)
				{
					
					ImpulseForce force = controller.gameObject.AddComponent<ImpulseForce> ();
					force.SetForceAndDuration (direction * 15, 1.5f);
				}
				else if(collider.GetComponentInParent<CollectibleObject> ())
				{
					if(!collider.GetComponentInParent<CollectibleObject> ().IsInPlayerArea())
						rigidBody.AddForce (direction * punchForce, ForceMode.Impulse);
				}
			}
			i++;
		}
	}

	public bool CanPunch()
	{
		return currentTime <= 0;
	}
}
