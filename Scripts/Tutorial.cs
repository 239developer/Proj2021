using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] text1, obj1, text2;
    private byte counter = 0;
    private float lastAction = 0f;

    void SwitchArray(GameObject[] array, bool state)
    {
        for(int i = 0; i < array.Length; i++)
            if(array[i] != null)
                array[i].SetActive(state);
    }

    void Start()
    {
        SwitchArray(text1, true);
        SwitchArray(obj1, false);
        SwitchArray(text2, false);
    }

    void Update()
    {
        if(Time.time - lastAction > 0.5f && Input.GetKeyDown(KeyCode.E))
        {
            switch(counter)
            {
                case 0:
                    SwitchArray(text1, false);
                    SwitchArray(obj1, true);
                    counter++;
                    lastAction = Time.time;
                    break;
                case 1:
                    SwitchArray(obj1, false);
                    SwitchArray(text2, true);
                    counter++;
                    lastAction = Time.time;
                    break;
                case 2:
                    if(Time.time - lastAction > 1f && counter == 2)
                    {
                        Stats.currentQuest++;
                        Buttons.LoadScene(2);
                    }
                    break;
            }
        }
    }
}
