using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Gates : MonoBehaviour
{
    public GameObject HasKeyNotification;
    public GameObject NoKeyNotification;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (GameManager.Instance.HasKeyToCave)
            {
                HasKeyNotification.SetActive(true);
            }
            else
            {
                NoKeyNotification.SetActive(true);
            }          
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            HasKeyNotification.SetActive(false);
            NoKeyNotification.SetActive(false);
        }
    }

    public void YesButtonClick()
    {
        StartCoroutine(SetGateState());
        HasKeyNotification.SetActive(false);
    }
    public void NoButtonClick()
    { 
        HasKeyNotification.SetActive(false);
    }

    IEnumerator SetGateState()
    {      
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameScene2");
    }
}
