using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour
{
	public byte typeOfDisplay;
	public GameObject buttonEnterToShop;
	public Text textDisplayMoney1, textDisplayMoney2;

    void Update()
    {
    	textDisplayMoney1.text = "Money: " + Stats.money;
		textDisplayMoney2.text = "Money: " + Stats.money;
    	buttonEnterToShop.SetActive(Stats.onShopTrigger);
    }
}
