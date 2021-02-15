using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radar : MonoBehaviour
{
    static public GameObject aim;

    void Update()
    {
    	transform.position = GameObject.Find("Main Camera").transform.position;
    	transform.LookAt(aim.transform.position);
    }
}
