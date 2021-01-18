using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject player;
    private Vector3 rotationConst;

    void Start()
    {
        rotationConst = transform.rotation.eulerAngles;
    }

    void Update()
    {
        Vector3 rotConst = player.GetComponent<PlayerMove>().TransformVector(rotationConst);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(rotConst) * player.transform.rotation, rotationSpeed * Time.deltaTime);
    }
}
