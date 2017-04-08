using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Canon : MonoBehaviour {

	private Animator animator;
	private AudioSource audioSource;

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

			float valAbs = Mathf.Abs(value);
			if (Mathf.Abs(value) < 20)
				value = Mathf.Sign(value) * 20;
			else if (Mathf.Abs(value) > 70)
				value = Mathf.Sign(value) * 70;

			angles.x = value;
			CanonPivot.localEulerAngles = angles;
		}
	}

	[SerializeField]
	private float cooldown = 2.0f;
	private bool onCooldown = false;

	void Start()
	{
		animator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
	}

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
		follow.timeMultiplicator = 2.0f;

		canFire = false;

		StartCoroutine(OnCooldown());
	}

	void Update()
	{
		var colliders = Physics.OverlapSphere(transform.position, 5.0f);
		CarriedObject carried = null;
		for(int i=0; i<colliders.Length; ++i)
		{
			carried = colliders[i].GetComponent<CarriedObject>();
			if (carried)
				break;
		}

		if(carried && carried.GetComponent<CanonAmmunition>())
		{
			var control = carried.carryPoint.gameObject.GetComponentInParent<CarryController>();
			var carriedGo = carried.gameObject;
			control.LetGo();
			Destroy(carriedGo);
			animator.SetTrigger("Load");
			canFire = true;
		}
	}
}
