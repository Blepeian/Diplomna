using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;

    void Start ()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    
    void LateUpdate () 
    {
        Vector3 temp = transform.position;

        temp.x = player.position.x;
        temp.y = player.position.y;

        transform.position = temp;
    }
}
