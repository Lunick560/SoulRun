using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DeathMenu : MonoBehaviour
{
    public Text hiscoreText;
    //public string mainMenuLevel;
    public GameObject pauseMenu;
    public void RestartGame()
    {
        Time.timeScale = 1f;
        FindObjectOfType<GameManager>().Reset();
        pauseMenu.SetActive(false);

    }
    public void QuitToMain()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);

        SceneManager.LoadScene("Descripting Page");
    }
    public void PauseGame()
    {
        //Stop game time
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
}
