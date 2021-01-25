using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShot : MonoBehaviour
{
    public Vector3 movement;

    void Update()
    {
        transform.Translate(movement * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Player" && other.isTrigger == false)
        {
            Destroy(gameObject);
        }
    }
}
