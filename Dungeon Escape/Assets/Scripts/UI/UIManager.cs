﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("UI Manager is null!");
            }
            return _instance;
        }
    }

    public Image[] healthBars;

    private void Awake()
    {
        _instance = this;
    }

    public void UpdateLife(int livesRemaining)
    {
        for(int i = 0; i <= livesRemaining; i++)
        {
            if(i == livesRemaining)
            {
                healthBars[i].enabled = false;
            }
        }
    }
    public void UpdateLife_Spike(int livesRemaining)
    {
        for (int i = 0; i <= livesRemaining; i++)
        {           
                healthBars[i].enabled = false;
        }
    }
}