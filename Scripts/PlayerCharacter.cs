using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour
{
    public Canvas[] ui;

    void Update()
    {
    	if(Stats.onShopTrigger && Input.GetKeyDown(KeyCode.E))
    	{
    		Stats.currentState = 1;
    		Time.timeScale = 0f;
    	}

    	foreach(Canvas c in ui) //Set active canvas
    	{
    		c.gameObject.SetActive(false);
    	}
    	ui[Stats.currentState].gameObject.SetActive(true);
    }
}
