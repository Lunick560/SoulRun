using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController player;

    private Vector3 LastplayerPosition;
    private float distanceBeoforeMoving;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        LastplayerPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Camera follow
        distanceBeoforeMoving = player.transform.position.x - LastplayerPosition.x;
        transform.position = new Vector3(transform.position.x + distanceBeoforeMoving,transform.position.y,transform.position.z);
        LastplayerPosition = player.transform.position;
    }
}
