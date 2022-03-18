using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityItem : Item
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
        icon = Resources.Load<Sprite>("iframe_item_placeholder");
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
                stats.EquipItem(this);
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
        stats.equippedItem = (Item)stats.gameObject.AddComponent(System.Type.GetType("InvincibilityItem"));
        stats.totalIFrameTime = 2.7f;
        Destroy(this.gameObject);
    }

    public override void Unequip()
    {
        stats.totalIFrameTime -= 0.7f;
    }
}
