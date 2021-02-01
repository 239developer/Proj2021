﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Stats;

public class PlayerCharacter : MonoBehaviour
{
    public Canvas[] ui, questDescription;
    public Slider healtBar;
    public int health = 5;

    void Start()
    {
       stats[0] = 1;
       healtBar.maxValue = health;
    }

    void Update()
    {
        switch(currentState)
        {
           case 0:
               switch(onTrigger)
               {
                   case 0:
                        currentState = 0;
                        Time.timeScale = 1f;
                        break;
                   case 1:
                       if(Input.GetKeyDown(KeyCode.E))
                       {
                           currentState = 1;
                           Time.timeScale = 0f;
                       }
                       break;
                   case 2:
                       currentState = 2;
                       Time.timeScale = 0.9f;
                       break;
               }
               break;
           case 1:
               if(Input.GetKeyDown(KeyCode.E))
               {
                   currentState = 0;
                   Time.timeScale = 1f;
               }
               break;
            case 2:
                if(onTrigger == 0)
                {
                    currentState = 0;
                    Time.timeScale = 1f;
                }
                else if(Input.GetKeyDown(KeyCode.E))
                    Buttons.LoadScene(Quest_id[currentQuest]);
                break;
        }

        foreach(Canvas c in ui) //Set active canvas
        {
           c.gameObject.SetActive(false);
        }
        if(currentState != 2)
            ui[currentState].gameObject.SetActive(true);
        else
            questDescription[currentQuest].SetActive(true);

        healtBar.value = health;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemyAttack") //Is player on enemy knife?
        {
            if(health > 0)
                health--;
            else
                currentState = 3;
        }
    }
}
