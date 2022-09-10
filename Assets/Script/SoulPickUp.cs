using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulPickUp : MonoBehaviour
{
    public int scoreGive;
    public int soulsGive;
    private ScoreAndGoldManager scoreManager;

    private AudioSource SoulSound;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreAndGoldManager>();
        SoulSound = GameObject.Find("SoulAbosord").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            scoreManager.addscore(scoreGive);
            scoreManager.addsouls(soulsGive);
            gameObject.SetActive(false);

            if (SoulSound.isPlaying)
            {
                SoulSound.Stop();
                SoulSound.Play();
            }
            else
            {
                SoulSound.Play();
            }
            
        }
    }
}
