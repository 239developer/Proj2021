using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour
{
	public byte typeOfDisplay;

    void Update()
    {
    	GetComponent<Text>().text = "Money: " + Stats.money;
    }
}
