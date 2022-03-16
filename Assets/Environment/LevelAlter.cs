using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAlter : MonoBehaviour
{
    public GameObject interact;

    [SerializeField]private Collider2D chestCol;
    private bool playerInFront;

    private void Awake()
    {
        playerInFront = false;
        interact.SetActive(false);
    }

    private void Update()
    {
        if(playerInFront)
        {
            if(Input.GetButtonDown("Interact"))
            {
                GameObject.FindWithTag("Player").GetComponent<PlayerStats>().LevelUp();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            interact.SetActive(true);
            playerInFront = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        interact.SetActive(false);
        playerInFront = false;
    }
}
