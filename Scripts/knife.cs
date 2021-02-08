using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{
	public float speed = 10.0f;
	public int damage = 1;
	public float a = 0;
	public float maxa = 10;
	void Update() {
		transform.Translate(0, 0, speed * Time.deltaTime);
		a = a + 1;
		if (a == maxa) {
			Destroy(this.gameObject);
		}
	}

}
