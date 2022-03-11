using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySelectUI : MonoBehaviour
{
    public Text abName;
    public Image abIcon;
    public Text abDescription;

    private Ability ability;
    private AbilityItem currItem;

    private void Awake()
    {
        GameObject.Find("LevelManager").GetComponent<LevelManager>().abUI = this;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            SetAbility(1);
        }

        if(Input.GetKeyDown("2"))
        {
            SetAbility(2);
        }

        if(Input.GetKeyDown("3"))
        {
            SetAbility(3);
        }

        if(Input.GetButtonDown("Cancel"))
        {
            gameObject.SetActive(false);
        }
    }

    public void GetAbility(AbilityItem abItem)
    {
        currItem = abItem;
        ability = abItem.ability;
        abIcon.sprite = abItem.gameObject.GetComponent<SpriteRenderer>().sprite;
        abName.text = abItem.itemName;
        abDescription.text = abItem.description;
        gameObject.SetActive(true);
    }

    public void SetAbility(int slot)
    {
        GameObject.Find("Player").GetComponentInChildren<PlayerAbilities>().SetAbility(slot, ability);
        Destroy(currItem.gameObject);
        gameObject.SetActive(false);
    }
}
