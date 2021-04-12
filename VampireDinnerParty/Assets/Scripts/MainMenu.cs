using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject titleObject;
    public GameObject startButton;
    public GameObject creditsButton;
    public GameObject quitButton;
    public GameObject controlsButton;

    public GameObject mainScreen;
    public GameObject creditsScreen;
    public GameObject controlsScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreditsButton()
    {
        creditsScreen.SetActive(true);
        mainScreen.SetActive(false);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(2);
    }

    public void BackButtonCredits()
    {
        creditsScreen.SetActive(false);
        mainScreen.SetActive(true);
    }

    public void BackButtonControls()
    {
        controlsScreen.SetActive(false);
        mainScreen.SetActive(true);
    }

    public void ControlsButton()
    {
        controlsScreen.SetActive(true);
        mainScreen.SetActive(false);
    }

    public void ClickSound()
    {

    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
