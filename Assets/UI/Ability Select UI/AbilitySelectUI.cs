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

    private void Awake()
    {
        GameObject.Find("LevelManager").GetComponent<LevelManager>().abUI = this;
        gameObject.SetActive(false);
    }

    public void GetAbility(AbilityItem abItem)
    {
        ability = abItem.ability;
        abIcon.sprite = abItem.gameObject.GetComponent<SpriteRenderer>().sprite;
        abName.text = abItem.itemName;
        abDescription.text = abItem.description;
        gameObject.SetActive(true);
    }

    public void SetAbility(int slot)
    {
        GameObject.Find("Player").GetComponentInChildren<PlayerAbilities>().SetAbility(slot, ability);
    }
}
