using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController Player;
    private Vector3 playerStartingPoint;

    private PlatformDestory[] platformList;

    private ScoreAndGoldManager scoreManager;

    public DeathMenu deathMenu;
    public bool powerupReset;

    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartingPoint = Player.transform.position;

        scoreManager = FindObjectOfType<ScoreAndGoldManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RestartGames()
    {
        scoreManager.scoreIncreasing = false;
        Player.gameObject.SetActive(false);

        deathMenu.gameObject.SetActive(true);
        //StartCoroutine("RestartGameCo");
    }

    public void Reset()
    {
        deathMenu.gameObject.SetActive(false);

        platformList = FindObjectsOfType<PlatformDestory>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        Player.transform.position = playerStartingPoint;
        platformGenerator.position = platformStartPoint;
        Player.gameObject.SetActive(true);
        scoreManager.scoreCount = 0;
        scoreManager.scoreIncreasing = true;

        powerupReset = true;
    }
    /*public IEnumerator RestartGameCo()
    {
        scoreManager.scoreIncreasing = false;
        Player.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        platformList = FindObjectsOfType<PlatformDestory>();
        for (int i = 0; i < platformList.Length; i++) {
            platformList[i].gameObject.SetActive(false);
        }
        Player.transform.position = playerStartingPoint;
        platformGenerator.position = platformStartPoint;
        Player.gameObject.SetActive(true);
        scoreManager.scoreCount = 0;
        scoreManager.scoreIncreasing = true;
    }*/
}
