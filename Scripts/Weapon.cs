using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Slider reloading;
    public byte id;
    public GameObject arrow;
    public float arrowSpeed, arrowShootingSpeed, lifeTime = 5f;
    private float lastShotTime;

    void Display()
    {
        float r = (Time.time - lastShotTime) * arrowShootingSpeed;
        if(r < 1)
            reloading.value = r;
        else
            reloading.value = 1;
    }

    void BowUpdate()
    {
        if (Input.GetMouseButtonDown(0) && Time.time - lastShotTime >= 1f / arrowShootingSpeed)
        {
            lastShotTime = Time.time;
            GameObject shot = GameObject.Instantiate(arrow, transform.position, arrow.transform.rotation);
            shot.transform.Rotate(0f, 0f, transform.rotation.eulerAngles.y);
            shot.GetComponent<moveShot>().movement = new Vector3(0f, -arrowSpeed, 0f);
            Destroy(shot, lifeTime);
        }
    }

    void Update()
    {
        if (Stats.currentState == 0)
        {
            switch (id)
            {
            case 0:
                BowUpdate();
                break;
            }
        }
        Display();
    }
}
