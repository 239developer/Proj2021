using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speedX, speedZ, rotationSpeed;
    public GameObject _camera;
    private Rigidbody rb;
    private Vector3 VectorConst;

    void Start()
    {
    	rb = GetComponent<Rigidbody>();
        VectorConst = _camera.transform.position;
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
        _camera.transform.position = transform.position + transform.TransformVector(VectorConst);
    }
}
