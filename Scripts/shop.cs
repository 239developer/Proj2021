using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    static public int n = 1;
    public Text[] buttonTexts, nameTexts;
    public float[] factors;
    public List<item> items;

    public class item
    {
        public Text[] text;
        public string name = "unknown name";
        public int price;
        public float factor;

        public item(Text[] txt, int p, float f)
        {
            text = txt;
            price = p;
            factor = f;
        }

        public void Display(int id)
        {
            text[0].text = name + ": " + Stats.stats[id];
            text[1].text = "Buy (" + price + ")";
        }

        public void Buy(int id)
        {
            if (Stats.money >= price)
            {
                Stats.stats[id] += factor;
                Stats.money -= price;
                Stats.prices[id] = ++price;
            }
        }
    }

    void Start()
    {
        items = new List<item>();

        for (int i = 0; i < n; i++)
        {
            var newItem = new item(new Text[] {nameTexts[i], buttonTexts[i]}, Stats.prices[i], factors[i]);
            items.Add(newItem);
        }

        items[0].name = "Speed";
    }

    void Update()
    {
        for (int i = 0; i < n; i++)
        {
            items[i].Display(i);
        }
    }
}
