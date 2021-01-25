using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, Random.value * 360, 0f);
        gameObject.tag = "coin";
    }
}
