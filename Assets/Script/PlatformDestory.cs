using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestory : MonoBehaviour
{
    public GameObject platformDestoryPoint;
    // Start is called before the first frame update
    void Start()
    {
        platformDestoryPoint = GameObject.Find("PlatformDeletingPoint");
    }

    // Update is called once per frame
    void Update()
    {
        //If the position is smaller than the point we checking then we destory it
        if (transform.position.x<platformDestoryPoint.transform.position.x)
        {
            // Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
