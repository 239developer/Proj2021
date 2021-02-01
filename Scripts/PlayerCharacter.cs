using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Stats;

public class PlayerCharacter : MonoBehaviour
{
    public Canvas[] ui;
    public Slider healtBar;
    public int health = 5;

    void Start()
    {
       stats[0] = 1;
       healtBar.maxValue = health;
    }

    void Update()
    {
        switch(Stats.currentState)
        {
           case 0:
               switch(Stats.onTrigger)
               {
                   case 0:
                        Stats.currentState = 0;
                        Time.timeScale = 1f;
                        break;
                   case 1:
                       if(Input.GetKeyDown(KeyCode.E))
                       {
                           Stats.currentState = 1;
                           Time.timeScale = 0f;
                       }
                       break;
                   case 2:
                       Stats.currentState = 2;
                       Time.timeScale = 0.9f;
                       break;
               }
               break;
           case 1:
               if(Input.GetKeyDown(KeyCode.E))
               {
                   Stats.currentState = 0;
                   Time.timeScale = 1f;
               }
               break;
            case 2:
                if(Stats.onTrigger == 0)
                {
                    Stats.currentState = 0;
                    Time.timeScale = 1f;
                }
                else if(Input.GetKeyDown(KeyCode.E))
                    Buttons.LoadScene(Stats.Quest_id[0]);
                break;
        }

        foreach(Canvas c in ui) //Set active canvas
        {
           c.gameObject.SetActive(false);
        }
        ui[Stats.currentState].gameObject.SetActive(true);

        healtBar.value = health;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemyAttack") //Is player on enemy knife?
        {
            if(health > 0)
                health--;
            else
                Stats.currentState = 3;
        }
    }
}
