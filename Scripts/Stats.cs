using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Stats : MonoBehaviour
{
    public static int money = 0, Q01price = 5;
    public static byte currentState = 0, onTrigger = 0, currentQuest = 0, subQuest02 = 1, currentScene = 0; //default 0, shop 1, receiving-quest 2, death 3, endOfQuest 4
    public static float[] stats = new float[shop.n];
    public static byte[] Quest_id = new byte[] {3, 4, 5};
    public static int[] prices = new int[] {1};
    private static string stats_path = @"stats.txt", scene_path = @"game_scene.txt";

    public static void ReadPlayerPos(GameObject player)
    {
        if (!File.Exists(scene_path))
            File.Create(scene_path);
        else
            using(StreamReader sr = File.OpenText(scene_path))
        {
            float x = float.Parse(sr.ReadLine());
            float y = float.Parse(sr.ReadLine());
            float z = float.Parse(sr.ReadLine());
            player.transform.position = new Vector3(x, y, z);
            sr.Close();
        }
    }

    public static void SavePlayerPos(GameObject player)
    {
        using(StreamWriter sw = File.CreateText(scene_path))
        {
            sw.WriteLine(player.transform.position.x.ToString());
            sw.WriteLine(player.transform.position.y.ToString());
            sw.WriteLine(player.transform.position.z.ToString());
            sw.Close();
        }
    }

    public static void ReadAllStats()
    {
        if (!File.Exists(stats_path))
            File.Create(stats_path);
        else
        {
            using(StreamReader sr = File.OpenText(stats_path))
            {
                money = int.Parse(sr.ReadLine());
                currentQuest = byte.Parse(sr.ReadLine());
                stats[0] = float.Parse(sr.ReadLine());
                prices[0] = int.Parse(sr.ReadLine());
                sr.Close();
            }
        }
    }

    public static void SaveAllStats()
    {
        using(StreamWriter sw = File.CreateText(stats_path))
        {
            sw.WriteLine(money.ToString());
            sw.WriteLine(currentQuest.ToString());
            sw.WriteLine(stats[0].ToString());
            sw.WriteLine(prices[0].ToString());
            sw.Close();
        }
    }
}