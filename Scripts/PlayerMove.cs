using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speedX, speedZ, rotationSpeed;
    public GameObject _camera;
    private Rigidbody rb;
    private Vector3 VectorConst, velocity;

    public Vector3 TransformVector(Vector3 vector)
    {
    	Vector3 answer = transform.TransformVector(vector);
    	return answer;
    }

    void Start()
    {
    	rb = GetComponent<Rigidbody>();
        VectorConst = _camera.transform.position;
    }

    void Update()
    {
    	float vx = Input.GetAxis("Horizontal") * speedX;
    	float vy = 0f;
    	float vz = Input.GetAxis("Vertical") * speedZ;
    	rb.velocity -= new Vector3(rb.velocity.x, 0f, rb.velocity.z);
    	velocity = transform.TransformVector(vx, vy, vz);
    	rb.velocity += velocity;

    	float rotY = Input.GetAxis("Mouse X") * rotationSpeed;
    	transform.Rotate(0f, rotY, 0f);
        _camera.transform.position = transform.position + transform.TransformVector(VectorConst);
    }

    void OnTriggerEnter(Collider other)
    {
    	if(other.tag == "coin")
    	{
    		Stats.money++;
    		Destroy(other.gameObject);
    	}
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "shop")
        {
            Stats.onShopTrigger = true;
        }
    }

    void OnTriggerExit()
    {
        Stats.onShopTrigger = false;
    }
}
