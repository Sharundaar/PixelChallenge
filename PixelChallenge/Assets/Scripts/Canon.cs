﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Canon : MonoBehaviour {

	private Animator animator;
	private AudioSource audioSource;

	[SerializeField]
	private Bullet bulletPrefab;

	[SerializeField]
	public Transform BarrelPivot;

	[SerializeField]
	public Transform CanonPivot;

	public ParticleSystem shotParticle;

	public float power = 0;

	public bool canFire = false;

	float startAngle = 0;

	public float Angle
	{
		get
		{
			return CanonPivot.localEulerAngles.y;
		}
		set
		{
			var angles = CanonPivot.localEulerAngles;
			angles.y = value;
			CanonPivot.localEulerAngles = angles;
		}
	}

	public float Hazimut {
		get
		{
			return BarrelPivot.localEulerAngles.x;
		}
		set
		{
			var angles = BarrelPivot.localEulerAngles;

			float valAbs = Mathf.Abs(value);
			if (Mathf.Abs(value) < 20)
				value = Mathf.Sign(value) * 20;
			else if (Mathf.Abs(value) > 45)
				value = Mathf.Sign(value) * 45;

			angles.x = value;
			BarrelPivot.localEulerAngles = angles;
		}
	}

	[SerializeField]
	private float cooldown = 2.0f;
	private bool onCooldown = false;

	void Start()
	{
		animator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
		startAngle = transform.localEulerAngles.y;
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

		shotParticle.Play(true);
		var bullet = GameObject.Instantiate<Bullet>(bulletPrefab, BarrelPivot.position, Quaternion.identity);
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
			AudioManager.instance.PlaySound ("reloadCanon");
		}
	}
}
