using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void ChangeScene(int scene)
    {
    	SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
    	Application.Quit();
    }

    public void BuySomething(int id)
    {
        GameObject.Find("Shop").GetComponent<shop>().Buy(id);
    }
}
