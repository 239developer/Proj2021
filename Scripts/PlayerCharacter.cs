using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour
{
    public Canvas[] ui;

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
    }
}
