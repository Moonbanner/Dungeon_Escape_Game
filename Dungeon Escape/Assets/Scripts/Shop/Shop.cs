using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    public int currentSelectedItem = 2;
    public int currentItemCost = 5;
    private Player _player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _player = other.GetComponent<Player>();

            if(_player != null)
            {
                UIManager.Instance.OpenShop(_player.diamonds);
            }

            shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        // select item
        // max health = 0
        // sword arc = 1 
        // gate key = 2
        //Debug.Log("select item " + item);

        switch(item)
        {
            case 0:
                UIManager.Instance.UpdateShopSelection(132);
                currentSelectedItem = 0;
                currentItemCost = 15 ;
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(28);
                currentSelectedItem = 1;
                currentItemCost = 10 ;
                break;
            case 2:
                UIManager.Instance.UpdateShopSelection(-76);
                currentSelectedItem = 2;
                currentItemCost = 5;
                break;
        }
    }

    public void BuyItem()
    {
        if(_player.diamonds >= currentItemCost)
        {
            if(currentSelectedItem == 0)
            {
                _player.MaxHealth++;
                _player.Health = _player.MaxHealth;
                UIManager.Instance.UpdateMaxHealth(_player.MaxHealth);
            }

            if(currentSelectedItem == 1)
            {
                _player.haveSwordArc = true;
            }

            if(currentSelectedItem == 2)
            {
                GameManager.Instance.HasKeyToCave = true;
            }
            _player.diamonds -= currentItemCost;
            shopPanel.SetActive(false);
        }
        else
        {
            Debug.Log("You dont have enough gems!!");
            shopPanel.SetActive(false);
        }
    }
}
