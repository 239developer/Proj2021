using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] text1;
    private byte counter = 0;
    private float lastAction = 0f;

    void SwitchArray(GameObject[] array, bool state)
    {
        for(int i = 0; i < array.Length; i++)
            array.SetActive(state);
    }

    void Start()
    {
        SwitchArray(text1, true);
    }

    void Update()
    {
        if(Time.time - lastAction > 0.5f)
            switch(counter)
            {
                case 0:
                    SwitchArray(text1, false);
                    break;
            }
    }
}
