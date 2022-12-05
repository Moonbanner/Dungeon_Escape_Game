using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject buyKeyNotification;
    public GameObject noGemsNotification;
    public int currentSelectedItem = 2;
    public int currentItemCost = 5;
    private Player _player;

    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _itemSelectClip;
    [SerializeField]
    private AudioClip _itemBoughtClip;
    [SerializeField]
    private AudioClip _healthGainedClip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        _audioSource = GetComponent<AudioSource>();
        if (other.tag == "Player")
        {
            _player = other.GetComponent<Player>();

            if(_player != null)
            {
                UIManager.Instance.OpenShop(_player.diamonds);
            }

            shopPanel.SetActive(true);
            _player.shopping = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopPanel.SetActive(false);
            noGemsNotification.SetActive(false);
            buyKeyNotification.SetActive(false);
            _player.shopping = false;
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
                _audioSource.PlayOneShot(_itemSelectClip);
                UIManager.Instance.UpdateShopSelection(132);
                currentSelectedItem = 0;
                currentItemCost = 15 ;
                break;
            case 1:
                _audioSource.PlayOneShot(_itemSelectClip);
                UIManager.Instance.UpdateShopSelection(28);
                currentSelectedItem = 1;
                currentItemCost = 10 ;
                break;
            case 2:
                _audioSource.PlayOneShot(_itemSelectClip);
                UIManager.Instance.UpdateShopSelection(-76);
                currentSelectedItem = 2;
                currentItemCost = 5;
                break;
        }
    }

    public void BuyItem()
    {
        if (_player.diamonds >= currentItemCost)
        {
            if (currentSelectedItem == 0)
            {
                if (GameManager.Instance.HasKeyToCave == false)
                {
                    buyKeyNotification.SetActive(true);
                    return;
                }
                _audioSource.PlayOneShot(_itemBoughtClip);
                _player.MaxHealth++;
                _player.Health = _player.MaxHealth;
                _audioSource.PlayOneShot(_healthGainedClip);
                UIManager.Instance.UpdateMaxHealth(_player.MaxHealth);
            }

            if(currentSelectedItem == 1)
            {
                if (GameManager.Instance.HasKeyToCave == false)
                {
                    buyKeyNotification.SetActive(true);
                    return;
                }
                _audioSource.PlayOneShot(_itemBoughtClip);
                _player.haveSwordArc = true;
            }

            if(currentSelectedItem == 2)
            {
                GameManager.Instance.HasKeyToCave = true;
                _audioSource.PlayOneShot(_itemBoughtClip);
            }
            _player.diamonds -= currentItemCost;
            UIManager.Instance.UpdateGemCount(_player.diamonds);
            shopPanel.SetActive(false);
        }
        else
        {
            //Debug.Log("You dont have enough gems!!");
            noGemsNotification.SetActive(true);
            shopPanel.SetActive(false);
        }
    }
}
