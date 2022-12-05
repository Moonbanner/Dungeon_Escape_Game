using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGameGate : MonoBehaviour
{
    public GameObject EndGameNotification;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            EndGameNotification.SetActive(true);
            StartCoroutine(SetGateState());
        }
    }

    IEnumerator SetGateState()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Menu");
    }
}
