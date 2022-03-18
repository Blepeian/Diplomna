using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyItem : Item
{
    public PlayerStats stats;
    public GameObject interact = null;

    private bool playerInFront;
    private float coinBuff;

    private void Awake()
    {
        coinBuff = 1.2f;
        playerInFront = false;
        if(interact != null)
        {
            interact.SetActive(false);
        }
        icon = Resources.Load<Sprite>("coin_item_placeholder");
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
        stats.equippedItem = (Item)stats.gameObject.AddComponent(System.Type.GetType("CurrencyItem"));
        stats.coinBuff = coinBuff;
        Destroy(this.gameObject);
    }

    public override void Unequip()
    {
        stats.coinBuff = 1;
    }
}
