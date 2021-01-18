﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIweapon : MonoBehaviour
{
	public float speed = 3.0f; 
	public float obstacleRange = 5.0f;
	[SerializeField] private GameObject fireballPrefab; 
	private GameObject _fireball;
	void Update() {
		transform.Rotate(0, 100 * Time.deltaTime, 0);
		Ray ray = new Ray(transform.position, transform.forward); 
		RaycastHit hit;
		if (Physics.SphereCast(ray, 0.75f, out hit)) {
			GameObject hitObject = hit.transform.gameObject;
			if (hitObject.GetComponent<PlayerCharacter>()) { 
					_fireball = Instantiate(fireballPrefab) as GameObject;
					_fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
					_fireball.transform.rotation = transform.rotation;
			}

		}
	}
}
