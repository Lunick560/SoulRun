﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoll : MonoBehaviour
{
    public GameObject pooledObject;
    public int pooledAmount;

    List<GameObject> pooledObjects;
    // Start is called before the first frame update
    void OnEnable()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledAmount; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        GameObject obj = Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
}
