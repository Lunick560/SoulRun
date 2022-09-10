using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool doublePoits;
    public bool safeMode;

    public float powerupLength;
    private PowerUpManager powerupManager;
    private AudioSource getPowerUpSound;

    // Start is called before the first frame update
    void Start()
    {
        getPowerUpSound = GameObject.Find("SoulAbosord").GetComponent<AudioSource>();

        powerupManager = FindObjectOfType<PowerUpManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            powerupManager.ActivatePowerup(doublePoits, safeMode, powerupLength);
            if (getPowerUpSound.isPlaying)
            {
                getPowerUpSound.Stop();
                getPowerUpSound.Play();
            }
            else
            {
                getPowerUpSound.Play();
            }
        }
        if (!collision.name.Contains("Background")){
            gameObject.SetActive(false);

        }

    }

        }
