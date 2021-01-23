using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    static public int n = 1;
    public Text[] texts;
    public int[] startPrices;
    public float[] factors;
    private List<item> items;

    public class item
    {
        public Text namePrice;
        public string name = "unknown name";
        public int price;
        public float factor;

        public item(Text np, int p, float f)
        {
            namePrice = np;
            price = p;
        }

        public void DisplayPrice()
        {
            namePrice.text = name + ": " + price;
        }

        public void Buy(int id)
        {
            Stats.stats[id] += factor;
            price *= 2;
        }
    }

    void Start()
    {
        items = new List<item>();

        for(int i = 0; i < n; i++)
        {
            var newItem = new item(texts[i], startPrices[i], factors[i]);
            items.Add(newItem);
        }

        items[0].name = "Speed";
    }

    void Update()
    {
        foreach (var i in items)
        {
            i.DisplayPrice();     
        }
    }
}
