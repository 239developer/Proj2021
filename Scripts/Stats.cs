﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public static int money = 0;
    public static bool onShopTrigger = false;
    public static byte currentState = 0; //default 0, shop 1, receiving-quest 2, death 3
    public static float[] stats = new float[shop.n];
}