using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAbility : MonoBehaviour
{
    string id = "00";
    string name = "test";
    public GameObject player;

    void Awake()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Cast();
    }

    public void Cast()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            player.GetComponent<PlayerMovement>().Flip();
        }
    }
}
