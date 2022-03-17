using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : Item
{
    public PlayerStats stats;
    public GameObject interact = null;

    private bool playerInFront;

    private void Awake()
    {
        playerInFront = false;
        if(interact != null)
        {
            interact.SetActive(false);
        }
    }

    private void Start()
    {
        stats = (PlayerStats)GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if(playerInFront)
        {
            if(Input.GetButtonDown("Interact"))
            {
                Equip();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            if(interact != null)
            {
                interact.SetActive(true);
            }
            playerInFront = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(interact != null)
        {
            interact.SetActive(false);
        }
        playerInFront = false;
    }

    public override void Equip()
    {
        stats.equippedItem = (Item)stats.gameObject.AddComponent(System.Type.GetType("HealthItem"));
        stats.maxHealth += 0.20f * stats.maxHealth;
        stats.currHealth += 0.20f * stats.currHealth;
        stats.UpdateHealthBar();

        Destroy(this.gameObject);
    }

    public override void Unequip()
    {
        stats.maxHealth -= 0.20f * stats.maxHealth;
        stats.currHealth -= 0.20f * stats.currHealth;
    }
}
