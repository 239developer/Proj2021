using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /*--- VARIABLES ---*/
    public float speedX, speedZ, rotationSpeed;
    public GameObject _camera;
    private Rigidbody rb;
    private Vector3 VectorConst = new Vector3(0f, 5.29f, -6.47f), velocity;

    /*--- function used for camera rotation ---*/
    public Vector3 TransformVector(Vector3 vector)
    {
        Vector3 answer = transform.TransformVector(vector);
        return answer;
    }

    /*--- start ---*/
    void Start()
    {
        Stats.onTrigger = 0;
        Stats.currentState = 0;
        rb = GetComponent<Rigidbody>();
        VectorConst = _camera.transform.position;
    }

    /*--- movement ---*/
    void FixedUpdate()
    {
        float vx = Input.GetAxis("Horizontal") * speedX;   //x velocity
        float vy = 0f;                                     //y velocity
        float vz = Input.GetAxis("Vertical") * speedZ;     //z velocity
        velocity = transform.TransformVector(vx, vy, vz) * Stats.stats[0];  //summary
        rb.velocity -= new Vector3(rb.velocity.x, 0f, rb.velocity.z);  //velocity(x & z) of this rigidbody is 0(but it can still move down)
        rb.velocity += velocity;   //adding velocity to rb
    }

    void Update()
    {
        if(Stats.currentState == 0)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;

        float rotY = Input.GetAxis("Mouse X") * rotationSpeed; //y rotation
        Vector3 rotation = new Vector3(0f, rotY, 0f) * Time.timeScale;
        transform.Rotate(rotation);
        _camera.transform.position = transform.position + transform.TransformVector(VectorConst);   //move camera to rotaion
    }

    /*--- have you grab coin? ---*/
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "coin")
        {
            Stats.money++;
            Destroy(other.gameObject);
        }
    }

    /*--- can you enter to shop? ---*/
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "shop" || other.tag == "newTask" || other.tag == "endOfQuest")
            Stats.onTrigger = 0;
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "shop")
            Stats.onTrigger = 1;
        else if(other.tag == "newTask")
            Stats.onTrigger = 2;
        else if(other.tag == "endOfQuest")
            Stats.onTrigger = 4;
        else
            Stats.onTrigger = 0;
    }
}
