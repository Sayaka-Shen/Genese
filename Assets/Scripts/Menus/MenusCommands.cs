using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusCommands : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Canvas mainMenu;
    [SerializeField] private Canvas pauseMenu;
    [SerializeField] private Canvas settingsMenu;

    public void PlayGame()
    {
        mainMenu.gameObject.SetActive(false);
        AudioManager.Instance.PlayMusic("Game_Music");
    }

    public void QuitGame()
    {
        Debug.Log("Tu quittes le jeu.");
        Application.Quit();
    }

    public void ClosePauseMenu()
    {
        pauseMenu.gameObject.SetActive(false);
    }

    public void OpenOptions()
    {
        settingsMenu.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
    }
    
    public void CloseOptions()
    {
        settingsMenu.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
