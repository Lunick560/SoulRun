using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class BlinkText : MonoBehaviour
{
    //public GameObject blinkText;
    //public GameObject blinkText2;
    //public AudioSource BGM;

    public GameObject continueButton;
    // Start is called before the first frame update
    void Start()
    {
        //  InvokeRepeating("ToFlashText", 0f, 0.5f);
        //InvokeRepeating("TouchToStartText (1)", 0f, 0.5f);
        if (!PlayerPrefs.HasKey("Hornki"))
        {
            continueButton.SetActive(false);
        }
        else
        {
            continueButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
       /*
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Descripting Page");
        }
       */
    }
    /*
    void ToFlashText()
    {
        if (blinkText.activeInHierarchy)
        {
            blinkText.SetActive(false);
            blinkText2.SetActive(false); 
        }
        else
        {
            blinkText.SetActive(true);
            blinkText2.SetActive(true);
        }
    }
    */
    public void showPanelOrHidePanel(GameObject g)
    {
        if (g.activeInHierarchy)
        {
            g.SetActive(false);
        }else if (!g.activeInHierarchy)
        {
            g.SetActive(true);
        }
    }
    public void ContinueTheGame()
    {
        SceneManager.LoadScene("Descripting Page");

    }
    public void NewGame()
    {
        if (PlayerPrefs.HasKey("SorbRate"))
        {
           PlayerPrefs.SetFloat("SorbRate",10f);
        }
        else
        {
           PlayerPrefs.SetFloat("SorbRate", 10f);
        }

        if (PlayerPrefs.HasKey("SoulRate"))
        {
            PlayerPrefs.SetFloat("SorbRate", 30f);
        }
        else
        {
            PlayerPrefs.SetFloat("SorbRate", 30f);
        }
        if (PlayerPrefs.HasKey("Hornki"))
        {
            PlayerPrefs.SetFloat("Hornki",0f);
        }
        else
        {
            PlayerPrefs.SetFloat("Hornki", 0f);

        }
        if (PlayerPrefs.HasKey("Souls"))
        {
            PlayerPrefs.SetInt("Souls",0);
        }
        else
        {
            PlayerPrefs.SetInt("Souls", 0);

        }


        //deathMenu = FindObjectOfType<DeathMenu>();
        if (PlayerPrefs.HasKey("SoulPerSecond"))
        {
            PlayerPrefs.SetInt("SoulPerSecond",1);
        }
        else
        {
            PlayerPrefs.SetInt("SoulPerSecond", 1);

        }
        SceneManager.LoadScene("IntroStory");

    }

}
