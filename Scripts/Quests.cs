using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Stats;

public class Quests : MonoBehaviour
{
	public static Collider col;

	public static void SubQuests02(int n)
	{
		GameObject player = GameObject.Find("Player");
		GameObject[] flags = new GameObject[n + 1];
		for (int i = 0; i < n; i++)
		{
			flags[i] = GameObject.Find("flag" + i.ToString());
		}
		flags[n] = GameObject.Find("waypoint");

		if (col != null)
		{
			if (col.name == "flag" + subQuest02.ToString())
				Stats.subQuest02++;
			else
				Debug.Log(col.name);

			if (subQuest02 == n && col.name == "waypoint")
			{
				currentQuest++;
				Buttons.LoadScene(2);
			}
		}

		radar.aim = flags[subQuest02];
	}

	public static void OnQuest()
	{
		switch (currentQuest)
		{
		case 1:
			if (money >= 5)
			{
				currentQuest++;
				Buttons.LoadScene(2);
			}
			break;
		case 2:
			SubQuests02(8);
			break;
		}
		Debug.Log("Current quest: " + currentQuest + "  Subquest02: " + subQuest02);
	}
}
