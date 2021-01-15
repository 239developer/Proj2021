using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speedX, speedZ, rotationSpeed;
    private Rigidbody rb;

    void Start()
    {
    	rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
    	float vx = Input.GetAxis("Horizontal") * speedZ;
    	float vy = 0f;
    	float vz = Input.GetAxis("Vertical") * speedX;
    	Vector3 velocity = new Vector3(vx, vy, vz);
    	rb.velocity = transform.TransformVector(velocity);

    	float rotY = Input.GetAxis("Mouse X") * rotationSpeed;
    	transform.Rotate(0f, rotY, 0f);
    }
}
