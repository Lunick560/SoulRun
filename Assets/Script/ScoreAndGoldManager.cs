using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndGoldManager : MonoBehaviour
{
    public Text scoreText;
    public Text soulText;

    public float scoreCount;
    public float bestscoreCount;

    public int soulsCount;
    public int totalSouls;

    public float scorePerSecond;
    public bool scoreIncreasing;

    public bool showDouble;

    public Text hiscoreText;
    // Start is called before the first frame update
    void OnEnable()
    {
        if (PlayerPrefs.HasKey("Hornki"))
        {
            bestscoreCount = PlayerPrefs.GetFloat("Hornki");
        }
        if (PlayerPrefs.HasKey("Souls"))
        {
            soulsCount = PlayerPrefs.GetInt("Souls");
        }
        //deathMenu = FindObjectOfType<DeathMenu>();
        if (PlayerPrefs.HasKey("SoulPerSecond"))
        {
            scorePerSecond = PlayerPrefs.GetInt("SoulPerSecond");
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        if (scoreIncreasing)
        {
            scoreCount += scorePerSecond * Time.deltaTime;

        }
        if (scoreCount > bestscoreCount)
        {
            bestscoreCount = scoreCount;
            PlayerPrefs.SetFloat("Hornki",bestscoreCount);
        }

        hiscoreText.text = "Most Horki Collect:" + Mathf.Round(bestscoreCount);
        scoreText.text = "Horki:" + Mathf.Round(scoreCount);
        soulText.text = "Souls:" + soulsCount;

    }
    public void addscore(int socreGive)
    {
        if (showDouble)
        {
            socreGive = socreGive * 2;
        }
        scoreCount += socreGive;
    }

    public void addsouls(int soulGive)
    {
        soulsCount += soulGive;
        PlayerPrefs.SetInt("Souls", soulGive+soulsCount);

    }
}
