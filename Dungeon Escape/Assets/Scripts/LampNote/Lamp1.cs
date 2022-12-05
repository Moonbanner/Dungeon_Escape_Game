using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp1 : MonoBehaviour
{
    public GameObject Note;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Note.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Note.SetActive(false);
        }
    }
}
