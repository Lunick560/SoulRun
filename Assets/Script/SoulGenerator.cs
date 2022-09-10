using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulGenerator : MonoBehaviour
{
    public ObjectPoll Soulpool;

    public float distanceBetweenSoul;
  
    public void spawnSouls (Vector3 startPosition)
    {
        GameObject soul1 = Soulpool.GetPooledObject();
        soul1.transform.position = startPosition;
        soul1.SetActive(true);

        GameObject soul2 = Soulpool.GetPooledObject();
        soul2.transform.position = new Vector3(startPosition.x - distanceBetweenSoul,startPosition.y,startPosition.z);
        soul2.SetActive(true);

        GameObject soul3 = Soulpool.GetPooledObject();
        soul3.transform.position = new Vector3(startPosition.x + distanceBetweenSoul, startPosition.y, startPosition.z);
        soul3.SetActive(true);

        /*
        GameObject soul4 = Soulpool.GetPooledObject();
        soul4.transform.position = new Vector3(startPosition.x + distanceBetweenSoul*2, startPosition.y, startPosition.z);
        soul4.SetActive(true);

        GameObject soul5 = Soulpool.GetPooledObject();
        soul5.transform.position = new Vector3(startPosition.x + distanceBetweenSoul*3, startPosition.y, startPosition.z);
        soul5.SetActive(true);
    */
    }
}
