﻿using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour
{
    public GameObject settings;
    public void StartGame()
    {
        Application.LoadLevel(1);
    }

    public void LoadGame()
    {
        
    }

    public void Settings()
    {
        settings.SetActive(!settings.activeSelf);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void setMusic(float value)
    {
        Global.music = value;
    }

    public void setSound(float value)
    {
        Global.sound = value;
    }
}