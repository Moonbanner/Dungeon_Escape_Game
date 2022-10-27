using System.Collections;
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

    public Text playerGemCountText;
    public Image selectionImg;
    public Image[] healthBars;
    public Text gemCountText;

    private void Awake()
    {
        _instance = this;
    }

    public void OpenShop(int gemsCount)
    {
        playerGemCountText.text = "" + gemsCount + "G";
    }

    public void UpdateShopSelection(int yPos)
    {
        selectionImg.rectTransform.anchoredPosition = new Vector2(selectionImg.rectTransform.anchoredPosition.x, yPos);
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

    public void UpdateGemCount(int count)
    {
        gemCountText.text = "" + count;
    }
}
