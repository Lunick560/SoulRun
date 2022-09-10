using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class PreGameSceneManager : MonoBehaviour
{
    public GameObject descriptionPanel;
    public Text CurrentSoulAmount;
    public Text CurrentSorbRate;
    public Text SPSText;
    public Text SPSPrice;
    public Text SorbPrice;
    public Text SoulText;
    public Text SoulPrice;
    public GameObject NotEnoughMoneyPanel;
    public Text HorkiText;
    public Text HorkiShade;

    
 
    //public GameObject PlayerModel;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Souls"))
        {
            CurrentSoulAmount.GetComponent<Text>().text = "Current Souls: " + PlayerPrefs.GetInt("Souls");
        }
        else
        {
            PlayerPrefs.SetInt("Souls", 0);
            CurrentSoulAmount.GetComponent<Text>().text = "Current Souls: 0";
        }

        if (PlayerPrefs.HasKey("SoulPerSecond"))
        {
            SPSText.GetComponent<Text>().text = "Increase horki you collect" +"\n"+ "Current horki per second: " + PlayerPrefs.GetInt("SoulPerSecond");
            SPSPrice.GetComponent<Text>().text = (PlayerPrefs.GetInt("SoulPerSecond") * 100).ToString();
        }
        else
        {
            PlayerPrefs.SetInt("SoulPerSecond", 1);
            SPSText.GetComponent<Text>().text = "Increase horki you collect" + "\n" + "Current horki per second: "+ PlayerPrefs.GetInt("SoulPerSecond");
            SPSPrice.GetComponent<Text>().text = (PlayerPrefs.GetInt("SoulPerSecond") * 100).ToString();
        }
        if (PlayerPrefs.HasKey("SorbRate"))
        {
            CurrentSorbRate.GetComponent<Text>().text = "Increase the sorb appear rates" + "\n" + " Current sorb appear rate: " + PlayerPrefs.GetFloat("SorbRate")+"%";
            SorbPrice.GetComponent<Text>().text = (PlayerPrefs.GetFloat("SorbRate") / 5 * 50).ToString();
        }
        else
        {
            PlayerPrefs.SetFloat("SorbRate", 10f);
            CurrentSorbRate.GetComponent<Text>().text = "Increase the sorb appear rates" + "\n" + "Current sorb appear rate: " + PlayerPrefs.GetFloat("SorbRate")+"%";
            SorbPrice.GetComponent<Text>().text = (PlayerPrefs.GetFloat("SorbRate") / 5 * 50).ToString();
        }

        if (PlayerPrefs.HasKey("SoulRate"))
        {
            SoulText.GetComponent<Text>().text = "Increase the soul appear rates" + "\n" + "Current soul appear rate: " + PlayerPrefs.GetFloat("SoulRate")+ "%";
            SoulPrice.GetComponent<Text>().text = (PlayerPrefs.GetFloat("SoulRate") / 5 * 50).ToString();
        }
        else
        {
            PlayerPrefs.SetFloat("SoulRate", 30f);
            SoulText.GetComponent<Text>().text = "Increase the soul appear rates" + "\n" + "Current soul appear rate: " + PlayerPrefs.GetFloat("SoulRate")+"%";
            SoulPrice.GetComponent<Text>().text = (PlayerPrefs.GetFloat("SoulRate") /5 * 50).ToString();
        }
        if (PlayerPrefs.HasKey("Hornki"))
        {
            HorkiText.GetComponent<Text>().text = "Most Horki Got so far: " + Mathf.Round(PlayerPrefs.GetFloat("Hornki"));
            HorkiShade.GetComponent<Text>().text = "Most Horki Got so far: " + Mathf.Round(PlayerPrefs.GetFloat("Hornki"));

        }
        else
        {
            PlayerPrefs.SetFloat("Hornki", 0f);
            HorkiText.GetComponent<Text>().text = "Most Horki Got so far: " + Mathf.Round(PlayerPrefs.GetFloat("Hornki"));
            HorkiShade.GetComponent<Text>().text = "Most Horki Got so far: " + Mathf.Round(PlayerPrefs.GetFloat("Hornki"));


        }


    }

    // Update is called once per frame
    void Update()
    {
        CurrentSorbRate.GetComponent<Text>().text = "Increase the sorb appear rates" + "\n" + " Current sorb appear rate: " + PlayerPrefs.GetFloat("SorbRate") + "%";
        SPSText.GetComponent<Text>().text = "Increase horki you collect" + "\n" + "Current horki per second: " + PlayerPrefs.GetInt("SoulPerSecond");
        CurrentSoulAmount.GetComponent<Text>().text = "Current Souls: " + PlayerPrefs.GetInt("Souls");
        SPSPrice.GetComponent<Text>().text = (PlayerPrefs.GetInt("SoulPerSecond") * 100).ToString();
        SorbPrice.GetComponent<Text>().text = (PlayerPrefs.GetFloat("SorbRate") / 5 * 50).ToString();
        SoulPrice.GetComponent<Text>().text = (PlayerPrefs.GetFloat("SoulRate") / 5 * 50).ToString();



    }

    public void togglePanel(GameObject d)
    {
        if (!d.activeInHierarchy)
        {
            d.SetActive(true);
        }
        



    }
    public void goBack(GameObject h)
    {
        if (h.activeInHierarchy)
        {
            h.SetActive(false);
            
        }
  
    }
    public void toggleAllButtons(GameObject b)
    {
        if (b.activeInHierarchy)
        {
            b.SetActive(false);
        }else if (!b.activeInHierarchy)
        {
            b.SetActive(true);
        }

    }
    public void shopSystem(int i)
    {
        switch (i)
        {
            case (0)://Soul per sec
                if (PlayerPrefs.GetInt("Souls")>=PlayerPrefs.GetInt("SoulPerSecond") * 100)
                {
                   int Temp = PlayerPrefs.GetInt("SoulPerSecond");
                    PlayerPrefs.SetInt("SoulPerSecond", Temp + 1) ;
                   int SoulTemp = PlayerPrefs.GetInt("Souls");
                    PlayerPrefs.SetInt("Souls", SoulTemp - Temp * 1000);
                }
                else if(PlayerPrefs.GetInt("Souls") < PlayerPrefs.GetInt("SoulPerSecond") * 100)
                {
                    NotEnoughMoneyPanel.SetActive(true);
                }
                break;
            case (1)://Sorb rate
                if (PlayerPrefs.GetInt("Souls") >= PlayerPrefs.GetFloat("SorbRate") / 5 * 50 && PlayerPrefs.GetFloat("SorbRate")!=100f)
                {
                    float Temp = Mathf.Round(PlayerPrefs.GetFloat("SorbRate"));
                    PlayerPrefs.SetFloat("SorbRate", Temp + 5f);
                    int SoulTemp = PlayerPrefs.GetInt("Souls");
                    //float remainTemp = SoulTemp - Temp / 5 * 500
                    PlayerPrefs.SetInt("Souls", Mathf.RoundToInt(SoulTemp - Temp / 5 * 50));
                }
                else if (PlayerPrefs.GetInt("Souls") < PlayerPrefs.GetFloat("SorbRate") * 100)
                {
                    NotEnoughMoneyPanel.SetActive(true);
                }else if(PlayerPrefs.GetFloat("SorbRate") == 100f)
                {
                    this.gameObject.SetActive(false);
                }
                break;
            case (2)://Soul Rate
                if (PlayerPrefs.GetInt("Souls") >= PlayerPrefs.GetFloat("SoulRate") / 5 * 50 && PlayerPrefs.GetFloat("SoulRate") != 100f)
                {
                    float Temp = Mathf.Round(PlayerPrefs.GetFloat("SoulRate"));
                    PlayerPrefs.SetFloat("SoulRate", Temp + 5f);
                    int SoulTemp = PlayerPrefs.GetInt("Souls");
                    //float remainTemp = SoulTemp - Temp / 5 * 500
                    PlayerPrefs.SetInt("Souls", Mathf.RoundToInt(SoulTemp - Temp / 5 * 50));
                }
                else if (PlayerPrefs.GetInt("Souls") < PlayerPrefs.GetFloat("SoulRate") * 100)
                {
                    NotEnoughMoneyPanel.SetActive(true);
                }
                else if (PlayerPrefs.GetFloat("SoulRate") == 100f)
                {
                    this.gameObject.SetActive(false);
                }
                break;
        }
    }
    public void loadMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ToGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void playStory(int i)
    {
        switch (i)
        {
            case 0:
                SceneManager.LoadScene("IntroStory");
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }
}
