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
       if(Input.GetKeyDown(KeyCode.E))
       {
         switch(Stats.currentState)
         {
            case 0:
                if(Stats.onShopTrigger)
                {
                    Stats.currentState = 1;
                    Time.timeScale = 0f;
                }
                break;
            case 1:
                Stats.currentState = 0;
                Time.timeScale = 1f;
                break;
         }
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
