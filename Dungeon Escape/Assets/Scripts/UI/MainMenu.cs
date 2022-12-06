using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _menuSelect;
    public GameObject PlayTutorialNotification;
    public void StartButton()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.PlayOneShot(_menuSelect);
        PlayTutorialNotification.SetActive(true);
         
    }
    public void YesButtonClick()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.PlayOneShot(_menuSelect);
        SceneManager.LoadScene("TutorialScene");
    }
    public void NoButtonClick()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.PlayOneShot(_menuSelect);
        SceneManager.LoadScene("GameScene");
    }
    public void QuitButton()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.PlayOneShot(_menuSelect);
        Application.Quit();
    }
}
