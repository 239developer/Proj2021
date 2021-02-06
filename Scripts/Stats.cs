using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Stats : MonoBehaviour
{
    public static int money = 0, Q01price = 5;
    public static byte currentState = 0, onTrigger = 0, currentQuest = 0; //default 0, shop 1, receiving-quest 2, death 3, endOfQuest 4
    public static float[] stats = new float[shop.n];
    public static byte[] Quest_id = new byte[]{3, 4};
    private static string path = @"stats.txt";

    public static void ReadAllStats()
    {
        if(!File.Exists(path))
            File.Create(path);
        else
        {
            using(StreamReader sr = File.OpenText(path))
            {
                money = int.Parse(sr.ReadLine());
                currentQuest = byte.Parse(sr.ReadLine());
                stats[0] = float.Parse(sr.ReadLine());
            }
        }
    }

    public static void SaveAllStats()
    {
        using(StreamWriter sw = File.CreateText(path))
        {
            sw.WriteLine(money.ToString());
            sw.WriteLine(currentQuest.ToString());
            sw.WriteLine(stats[0].ToString());
        }
    }
}