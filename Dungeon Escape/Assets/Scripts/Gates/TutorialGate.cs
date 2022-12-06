using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialGate : MonoBehaviour
{
    public GameObject EndTutorialNotification;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            EndTutorialNotification.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            EndTutorialNotification.SetActive(false);
        }
    }
    public void YesButtonClick()
    {
        StartCoroutine(SetGateState());
        EndTutorialNotification.SetActive(false);
    }
    public void NoButtonClick()
    {
        EndTutorialNotification.SetActive(false);
    }

    IEnumerator SetGateState()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameScene");
    }
}
