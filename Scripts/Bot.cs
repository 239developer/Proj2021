using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public GameObject player;
    public float speed, rotSpeed;
    private Rigidbody rb;

    float FindRotation()
    {
        Vector3 v1 = new Vector3(0f, 0f, 0f);//transform.rotation.eulerAngles;
        Vector3 v2 = player.transform.position - transform.position;
        float tag = v2.z / v2.x;
        float angle;
        switch(Math.Sign(v2.x))
        {
            case -1:
                switch(Math.Sign(v2.z))
                {
                    case -1:
                        angle = -(float)Math.Atan(tag) * 360f / (float)Math.PI - 90f;
                        break;
                    default:
                        angle = -(float)Math.Atan(tag) * 360f / (float)Math.PI;
                        break;
                }
                break;
            default:
                switch(Math.Sign(v2.z))
                {
                    case -1:
                        angle = (float)Math.Atan(tag) * 360f / (float)Math.PI + 90f;
                        break;
                    default:
                        angle = (float)Math.Atan(tag) * 360f / (float)Math.PI;
                        break;
                }
                break;
        }
        Debug.Log(angle);
        return angle;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0f, FindRotation(), 0f);
        Vector3 v = transform.TransformVector(0f, 0f, speed);
        rb.velocity = new Vector3(v.x, rb.velocity.y, v.z);
    }
}
