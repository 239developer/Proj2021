using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
	public bool enterToShop;

    public void ChangeScene(int scene)
    {
    	SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
    	Application.Quit();
    }

    void Update()
    {
    	if(enterToShop && Input.GetKeyDown(KeyCode.E))
    	{
    		Time.timeScale = 0f;
    	}
    }
}
