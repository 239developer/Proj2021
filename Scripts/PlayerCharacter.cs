﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Stats;

public class PlayerCharacter : MonoBehaviour
{
  public bool quest = false;
  public Canvas[] ui = new Canvas[5], questCanvases;
  public Canvas endOfTask;
  public Slider healtBar;
  public int health = 5;

  void Start()
  {
    stats[0] = 1;
    healtBar.maxValue = health;
    Canvas canvas;
    if (!quest)
    {
      canvas = GameObject.Instantiate(questCanvases[currentQuest]);
      ui[2] = canvas;
    }
    ui[4] = endOfTask;
  }

  void Update()
  {
    if (currentScene > 2)
      Quests.OnQuest();

    switch (currentState)
    {
    case 0:
      switch (onTrigger)
      {
      case 0:
        currentState = 0;
        Time.timeScale = 1f;
        break;
      case 1:
        if (Input.GetKeyDown(KeyCode.E))
        {
          currentState = 1;
          Time.timeScale = 0f;
        }
        break;
      case 2:
        currentState = 2;
        Time.timeScale = 0.9f;
        break;
      case 4:
        currentState = 4;
        Time.timeScale = 1f;
        break;
      }
      break;
    case 1:
      if (Input.GetKeyDown(KeyCode.E))
      {
        currentState = 0;
        Time.timeScale = 1f;
      }
      break;
    case 2:
      if (onTrigger == 0)
      {
        currentState = 0;
        Time.timeScale = 1f;
      }
      else if (Input.GetKeyDown(KeyCode.E))
      {
        if (Stats.currentScene == 2)
          Stats.SavePlayerPos(gameObject);
        Buttons.LoadScene(Quest_id[currentQuest]);
      }
      break;
    case 4:
      if (currentQuest >= 1)
        Quests.OnQuest();

      if (onTrigger == 0)
      {
        currentState = 0;
        Time.timeScale = 1f;
      }
      break;
    }

    foreach (Canvas c in ui) //Set active canvas
    {
      c.gameObject.SetActive(false);
    }
    ui[currentState].gameObject.SetActive(true);

    healtBar.value = health;

    if (Input.GetKey(KeyCode.Escape))   //exit to menu
    {
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
      if (Stats.currentScene == 2)
        Stats.SavePlayerPos(gameObject);
      SaveAllStats();
      Buttons.LoadScene(0);
    }
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.tag == "enemyAttack") //Is player on enemy knife?
    {
      if (health-- <= 0)
        currentState = 3;
      else
        health++;
    }
  }
}
