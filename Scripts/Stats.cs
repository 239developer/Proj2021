using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public static int money = 0, Q01price = 5;
    public static byte currentState = 0, onTrigger = 0, currentQuest = 0; //default 0, shop 1, receiving-quest 2, death 3, endOfQuest 4
    public static float[] stats = new float[shop.n];
    public static byte[] Quest_id = new byte[]{3, 4};
}