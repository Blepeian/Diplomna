using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaidChestScript : MonoBehaviour
{
    public GameObject abItemPrefab;
    public GameObject abItem;
    public GameObject interact;
    public int price;
    public TextMesh priceText;

    [SerializeField]private Collider2D chestCol;
    private bool playerInFront;

    private void Awake()
    {
        playerInFront = false;
        interact.SetActive(false);
        priceText.text = "" + price;
    }

    private void Update()
    {
        if(playerInFront)
        {
            if(Input.GetButtonDown("Interact"))
            {
                SpawnItem();
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

    private void SpawnItem()
    {
        if(GameObject.FindWithTag("Player").GetComponent<PlayerStats>().currency >= price)
        {
            abItem = Instantiate(abItemPrefab, gameObject.transform.position, Quaternion.identity);
            abItem.name = "AbilityItem";
            chestCol.enabled = false;
            interact.SetActive(false);
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
            GameObject.FindWithTag("Player").GetComponent<PlayerStats>().currency -= price;
        }
    }
}
