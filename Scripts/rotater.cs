using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotater : MonoBehaviour
{
    public bool x, y, z;
    public float rotationSpeed;
    private float sX = 0f, sY = 0f, sZ = 0f;
    private Vector3 rotation;

    void Start()
    {
        if (x)
            sX = rotationSpeed;
        if (y)
            sY = rotationSpeed;
        if (y)
            sY = rotationSpeed;
        rotation = new Vector3(sX, sY, sZ);
    }

    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
}
