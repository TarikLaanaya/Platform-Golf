using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject postProcessingVolume;
    public Toggle postProcessingToggle;
    bool postProcessingOn;
    public AddForceToBall addForceToBall;
    public GameObject[] hideWhenPaused;
    public GameObject[] showWhenPaused;

    public GameObject pauseMenu;
    public GameObject optionsMenu;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        
        postProcessingVolume.SetActive(true);

        for (int i = 0; i < hideWhenPaused.Length; i++)
        {
            hideWhenPaused[i].SetActive(true);
        }

        for (int i = 0; i < showWhenPaused.Length; i++)
        {
            showWhenPaused[i].SetActive(false);
        }

        optionsMenu.SetActive(false);

        //Post Processing

        postProcessingOn = PlayerPrefs.GetInt("postProcessingOn") == 1 ? true : false;

        if (postProcessingOn)
        {
            postProcessingToggle.isOn = true;
            postProcessingVolume.SetActive(true);
        }
        else
        {
            postProcessingToggle.isOn = false;
            postProcessingVolume.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        addForceToBall.canMove = false;
        Time.timeScale = 0f;
        for (int i = 0; i < showWhenPaused.Length; i++)
        {
            showWhenPaused[i].SetActive(true);
        }

        for (int i = 0; i < hideWhenPaused.Length; i++)
        {
            hideWhenPaused[i].SetActive(false);
        }
    }

    public void UnPause()
    {
        addForceToBall.canMove = true;
        Time.timeScale = 1f;
        for (int i = 0; i < hideWhenPaused.Length; i++)
        {
            hideWhenPaused[i].SetActive(true);
        }

        for (int i = 0; i < showWhenPaused.Length; i++)
        {
            showWhenPaused[i].SetActive(false);
        }
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Options()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void BackFromOptions()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
    
    public void OnToggleClicked()
    {
        if (postProcessingToggle.isOn)
        {
            postProcessingOn = true;
            PlayerPrefs.SetInt("postProcessingOn", postProcessingOn ? 1 : 0);
            PlayerPrefs.Save();
            postProcessingVolume.SetActive(true);
        }
        else
        {
            postProcessingOn = false;
            PlayerPrefs.SetInt("postProcessingOn", postProcessingOn ? 1 : 0);
            PlayerPrefs.Save();
            postProcessingVolume.SetActive(false);
        }
    }
}
