using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotater : MonoBehaviour
{
    public bool x, y, z;
    public float rotationSpeed;
    private float sX = 0f, sY = 0f, sZ = 0f;

    void Start()
    {
        if(x)
            sX = rotationSpeed;
        if(y)
            sY = rotationSpeed;
        if(y)
            sY = rotationSpeed;
    }

    void Update()
    {
        transform.Rotate(sX, sY, sZ);
    }
}
