using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromGenerator : MonoBehaviour
{
    public GameObject platfrom;
    public Transform generateingPoint;
    private float distanceInBetween;

    public float[] platfromWidth;

    public float distanceInBetweenMin;
    public float distanceInBetweenMax;

    //public GameObject[] platformSet;
    private int platformSelector;

    public ObjectPoll[] objectpolls;
    //Jumping height
    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    private float heightChange;
    //Generate souls
    private SoulGenerator soulGenerator;
    private float randomSoulThreshold;
    // Start is called before the first frame update

    public float randomSpikeThreshold;
    public ObjectPoll spikepool;
    public float powerupHeight;
    private ObjectPoll powerupPool;
    public ObjectPoll SafePowerupPool;
    public float powerupThreshold = 10f;
    public float SafepowerupThreshold = 10f;

    void Start()
    {
        //platfromWidth = platfrom.GetComponent<BoxCollider2D>().size.x;
        platfromWidth = new float[objectpolls.Length];

        for (int i = 0;i< platfromWidth.Length;i++)
        {
            platfromWidth[i] = objectpolls[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;

        maxHeight = maxHeightPoint.position.y;

        soulGenerator = FindObjectOfType<SoulGenerator>();


        if (PlayerPrefs.HasKey("SorbRate"))
        {
            powerupThreshold = PlayerPrefs.GetFloat("SorbRate");
        }
        if (PlayerPrefs.HasKey("SoulRate"))
        {
            randomSoulThreshold = PlayerPrefs.GetFloat("SoulRate");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generateingPoint.position.x)
        {
            distanceInBetween = Random.Range(distanceInBetweenMin, distanceInBetweenMax);

            platformSelector = Random.Range(0, objectpolls.Length);

            heightChange = transform.position.y + Random.Range(maxHeight, -maxHeight);

            if(heightChange>maxHeight||heightChange< minHeight)
            {
                heightChange = maxHeight;
    
            }else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }
            //Powerup genreates
            if (Random.Range(0f,100f) < powerupThreshold)
            {
                if (platfromWidth[platformSelector] > 4)
                {
                    GameObject newPowerup = powerupPool.GetPooledObject();
                    //(-platfromWidth[platformSelector] / 2)+1f, (platfromWidth[platformSelector] / 2)-1f
                    //float powerupXposition = Random.Range(-0.5f, 0.5f);
                    newPowerup.transform.position = transform.position + new Vector3(-2f, 0.8f, 0f);
                    newPowerup.transform.rotation = transform.rotation;

                    newPowerup.SetActive(true);
                }
            }
            //safeup generates
            if (Random.Range(0f, 100f) < SafepowerupThreshold)
            {
                GameObject newSafePowerup = SafePowerupPool.GetPooledObject();

                newSafePowerup.transform.position = transform.position + new Vector3(distanceInBetween / 2f+2f, Random.Range(powerupHeight/2, powerupHeight), 0f);
                newSafePowerup.SetActive(true);
            }


            transform.position = new Vector3(transform.position.x + platfromWidth[platformSelector]/2*1.75f + distanceInBetween, heightChange, transform.position.z);

            

            //Instantiate(platformSet[platformSelector], transform.position, transform.rotation);
            GameObject newPlatform = objectpolls[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
            //Random Soul
            if (Random.Range(0f, 100f) < randomSoulThreshold)
            {
                soulGenerator.spawnSouls(new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z));

            }

            if (Random.Range(0f, 100f) < randomSpikeThreshold)
            {
                if (platfromWidth[platformSelector] >= 4)
                {
                    GameObject newSpike = spikepool.GetPooledObject();
                    //(-platfromWidth[platformSelector] / 2f)+1, (platfromWidth[platformSelector] / 2f)-1
                    float spikeXposition = Random.Range(-0.5f,0.5f);
                    Vector3 spikePosition = new Vector3(spikeXposition, 0.8f, 0f);
                    newSpike.transform.position = transform.position + spikePosition;
                    newSpike.transform.rotation = transform.rotation;
                    newSpike.SetActive(true);
                }
            }




            transform.position = new Vector3(transform.position.x + platfromWidth[platformSelector] / 2, transform.position.y, transform.position.z);

        }
    }
}
