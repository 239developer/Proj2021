﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{
	public float speed = 10.0f;
	public int damage = 1;
	void Update() {
		transform.Translate(0, 0, speed * Time.deltaTime);	
		transform.Rotate(0, speed * Time.deltaTime, 0, Space.Self);
	}

}