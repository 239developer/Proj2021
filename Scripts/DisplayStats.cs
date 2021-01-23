using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour
{
	public byte typeOfDisplay;
	public GameObject buttonEnterToShop;
	public Text textDisplayMoney;

    void Update()
    {
    	textDisplayMoney.text = "Money: " + Stats.money;
    	buttonEnterToShop.SetActive(Stats.onShopTrigger);
    }
}
