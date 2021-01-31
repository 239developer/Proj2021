using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIForEnemyWithSword : MonoBehaviour
{
	public float speed = 10.0f;
	public float speedd = 20.0f; 
	public float shootdistase = 3.0f;
	void Update() { 
		transform.Rotate(0, speedd * Time.deltaTime, 0);
		Ray ray = new Ray(transform.position, transform.forward); 
		RaycastHit hit;
		if (Physics.SphereCast(ray, 0.75f, out hit)) { 
			GameObject hitObject = hit.transform.gameObject;
			if (hitObject.GetComponent<PlayerCharacter>()) {
				speedd = 0.0f;
				if (hit.distance > shootdistase) { 
					transform.Translate(0, 0, speed * Time.deltaTime);
				}
			}else{
				speedd = 20.0f;
			}	
		}
	}
}
