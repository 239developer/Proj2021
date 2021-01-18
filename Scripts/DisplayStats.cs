using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour
{
	public byte typeOfDisplay;
	public GameObject buttonEnterToShop;

    void Update()
    {
    	switch(typeOfDisplay)
    	{
    		case 0:
    			GetComponent<Text>().text = "Money: " + Stats.money;
    			break;
    		case 1:
    			buttonEnterToShop.SetActive(Stats.onShopTrigger);
    			break;
    	}
    }
}
