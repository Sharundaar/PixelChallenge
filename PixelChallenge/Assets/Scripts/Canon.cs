using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
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

	[SerializeField]
	private float cooldown = 2.0f;
	private bool onCooldown = false;

	IEnumerator OnCooldown()
	{
		onCooldown = true;
		yield return new WaitForSeconds(cooldown);
		onCooldown = false;
		yield return null;
	}

	public void Fire()
	{
		if (! (!onCooldown && canFire))
			return;

		var bullet = GameObject.Instantiate<Bullet>(bulletPrefab, CanonPivot.position, Quaternion.identity);
		var follow = bullet.gameObject.AddComponent<FollowTrajectory>();
		follow.trajectory = GetComponent<CanonTrajectory>().CopyTrajectory();
		follow.stopFollowOnHit = true;

		StartCoroutine(OnCooldown());
	}
}
