using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour {

	[SerializeField]
	private Bullet bulletPrefab;

	[SerializeField]
	public Transform CanonPivot;

	public float power = 0;

	public bool canFire = false;

	public float Angle
	{
		get
		{
			return transform.localEulerAngles.y;
		}
		set
		{
			var angles = transform.localEulerAngles;
			angles.y = value;
			transform.localEulerAngles = angles;
		}
	}

	public float Hazimut {
		get
		{
			return CanonPivot.localEulerAngles.x;
		}
		set
		{
			var angles = CanonPivot.localEulerAngles;
			angles.x = value;
			CanonPivot.localEulerAngles = angles;
		}
	}

	public void Fire()
	{
		if (!canFire)
			return;

		var bullet = GameObject.Instantiate<Bullet>(bulletPrefab, CanonPivot.position, Quaternion.identity);
		var follow = bullet.gameObject.AddComponent<FollowTrajectory>();
		follow.trajectory = GetComponent<CanonTrajectory>().CopyTrajectory();
		follow.stopFollowOnHit = true;
	}
}
