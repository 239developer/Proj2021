using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
	public float speed = 10.0f;
	public float a = 0;	 
	void Update()
	{
		transform.Translate(0, speed * Time.deltaTime, 0);
		a = a + 1;
		if (a == 10){
			Destroy(this.gameObject);
		}        
	}
}
