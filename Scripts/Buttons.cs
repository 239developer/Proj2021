using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public static void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ChangeScene(int scene)
    {
        LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BuySomething(int id)
    {
        GameObject.Find("Shop").GetComponent<shop>().items[id].Buy(id);
    }

    void Start()
    {
        Stats.ReadAllStats();
    }
}
