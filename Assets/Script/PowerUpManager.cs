using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private bool doublePoits;
    private bool safeMode;

    private bool powerupActive;
    private float powerupLengthCounter;

    private ScoreAndGoldManager scoreManager;
    private PlatfromGenerator platformGenerator;

    private float normalPointsPerSecond;
    private float spikeRate = 35;

    private PlatformDestory[] spikeList;

    private GameManager gameManger;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreAndGoldManager>();
        platformGenerator = FindObjectOfType<PlatfromGenerator>();
        gameManger = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (powerupActive)
        {
            powerupLengthCounter -= Time.deltaTime;

            if (gameManger.powerupReset)
            {
                powerupLengthCounter = 0f;
                gameManger.powerupReset = false;
            }
            if (doublePoits)
            {
                scoreManager.scorePerSecond = normalPointsPerSecond * 2;
                scoreManager.showDouble = true;
            }
            if (safeMode)
            {
                platformGenerator.randomSpikeThreshold = 0f;
            }

            if (powerupLengthCounter <= 0)
            {
                scoreManager.scorePerSecond = normalPointsPerSecond;
                platformGenerator.randomSpikeThreshold = spikeRate;
                scoreManager.showDouble = false;
                powerupActive = false;
            }
        }

    }
    public void ActivatePowerup(bool points,bool safe, float time)
    {
        doublePoits = points;
        safeMode = safe;
        powerupLengthCounter = time;

        if (!powerupActive)
        {
            normalPointsPerSecond = scoreManager.scorePerSecond;
            spikeRate = platformGenerator.randomSpikeThreshold;
        }

        //powerupActive = true;
    
    

        powerupActive = true;

        if (safeMode)
        {

            spikeList = FindObjectsOfType<PlatformDestory>();
            for (int i = 0; i < spikeList.Length; i++)
            {
                if (spikeList[i].gameObject.name.Contains("Spike"))
                {
                    spikeList[i].gameObject.SetActive(false);

                }
            }
        }
    }
}
