using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if(player != null)
            {
                UIManager.Instance.OpenShop(player.diamonds);
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
        Debug.Log("select item " + item);

        switch(item)
        {
            case 0:
                UIManager.Instance.UpdateShopSelection(132);
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(28);
                break;
            case 2:
                UIManager.Instance.UpdateShopSelection(-76);
                break;
        }
    }
}
