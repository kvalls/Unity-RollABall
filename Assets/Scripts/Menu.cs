using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    public static bool Singleplayer = false;
    public GameObject pauseMenu, optionsMenu, playMenu;

    public GameObject pauseFirstButton, optionsFirstButton, optionsClosedButton, travelFirstButton, travelClosedButton, P2Controls;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetButtonDown("Fire3")){
            PauseUnpause();
        }

        if (Singleplayer)
        {
            P2Controls.SetActive(false);
        }

    }

    public void PlayLevel1()
    {
        Time.timeScale = 1f;
        optionsMenu.SetActive(false);
        playMenu.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void PlayLevel2()
    {
        Time.timeScale = 1f;
        optionsMenu.SetActive(false);
        playMenu.SetActive(false);
        SceneManager.LoadScene(2);
    }

    public void PlayLevel3()
    {
        Time.timeScale = 1f;
        optionsMenu.SetActive(false);
        playMenu.SetActive(false);
        SceneManager.LoadScene(3);
    }
    public void PlayLevel4()
    {
        Time.timeScale = 1f;
        optionsMenu.SetActive(false);
        playMenu.SetActive(false);
        SceneManager.LoadScene(4);
    }

    public void MainMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        optionsMenu.SetActive(false);
        SceneManager.LoadScene(0);

    }

    public void PauseUnpause()
    {
        if (!pauseMenu.activeInHierarchy && !optionsMenu.activeInHierarchy && !playMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;

            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //set a new selected object
            EventSystem.current.SetSelectedGameObject(pauseFirstButton);
        }
        else 
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            optionsMenu.SetActive(false);
            playMenu.SetActive(false);
        }
    }

    public void OpenTravel()
    {
        //optionsMenu.SetActive(true);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(travelFirstButton);
    }

    public void CloseTravel()
    {
        //optionsMenu.SetActive(false);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(travelClosedButton);
    }

    public void OpenOptions()
    {
        //optionsMenu.SetActive(true);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(optionsFirstButton);
    }

    public void CloseOptions()
    {
        //optionsMenu.SetActive(false);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(optionsClosedButton);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
